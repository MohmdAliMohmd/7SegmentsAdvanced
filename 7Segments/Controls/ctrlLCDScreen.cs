using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7Segments.Controls
{
    public partial class ctrlLCDScreen : UserControl
    {
        public ctrlLCDScreen()
        {
            InitializeComponent();
        }
        private Color _DigitsColor;
        private Color _ScreenColor;
        private double _LCDValue = 0;

        int _GetNumberDigitsCount(double numWithOutDots)
        {
            byte Count = 0;
            double number = numWithOutDots;

            while (number > 1)
            {
                number = number / 10;
                Count++;
                if (number < 1)
                    break;
            }
            return Count;
        }
        #region
        [Category("Screen Properties")]
        public Color DigitsColor
        {
            get { return _DigitsColor; }
            set
            {
                _DigitsColor = value;
                Digit0.FrontColor = _DigitsColor;
                Digit1.FrontColor = _DigitsColor;
                Digit2.FrontColor = _DigitsColor;
                Digit3.FrontColor = _DigitsColor;
                Digit4.FrontColor = _DigitsColor;
                Digit5.FrontColor = _DigitsColor;
                Digit6.FrontColor = _DigitsColor;
                Digit7.FrontColor = _DigitsColor;
                Digit8.FrontColor = _DigitsColor;
                Digit9.FrontColor = _DigitsColor;
                Digit10.FrontColor = _DigitsColor;
                Digit11.FrontColor = _DigitsColor;
                Digit12.FrontColor = _DigitsColor;
                Digit13.FrontColor = _DigitsColor;
                Digit14.FrontColor = _DigitsColor;
                Digit15.FrontColor = _DigitsColor;
            }
        }

        [Category("Screen Properties")]
        public Color ScreenColor
        {
            get { return _ScreenColor; }
            set
            {
                _ScreenColor = value;

                Digit0.BackGroundColor = ScreenColor;
                Digit1.BackGroundColor = ScreenColor;
                Digit2.BackGroundColor = ScreenColor;
                Digit3.BackGroundColor = ScreenColor;
                Digit4.BackGroundColor = ScreenColor;
                Digit5.BackGroundColor = ScreenColor;
                Digit6.BackGroundColor = ScreenColor;
                Digit7.BackGroundColor = ScreenColor;
                Digit8.BackGroundColor = ScreenColor;
                Digit9.BackGroundColor = ScreenColor;
                Digit10.BackGroundColor = ScreenColor;
                Digit11.BackGroundColor = ScreenColor;
                Digit12.BackGroundColor = ScreenColor;
                Digit13.BackGroundColor = ScreenColor;
                Digit14.BackGroundColor = ScreenColor;
                Digit15.BackGroundColor = ScreenColor;
                this.BackColor = ScreenColor;
            }
        }

        [Category("Screen Properties")]
        public bool ContainsDot
        {
            get
            {
                return (
                    Digit0.DotExist || Digit1.DotExist || Digit2.DotExist ||
                    Digit3.DotExist || Digit4.DotExist || Digit5.DotExist ||
                    Digit6.DotExist || Digit7.DotExist || Digit8.DotExist ||
                    Digit9.DotExist || Digit10.DotExist || Digit11.DotExist ||
                    Digit12.DotExist || Digit13.DotExist || Digit14.DotExist ||
                    Digit15.DotExist
                      );
            }
        }
        void _DisplayNumberContainsE(double _LCDValue)
        {
            int DotIndex = 0;
            int DotPosition = 0;
            int CountOfShrinkingDigits = 0;
            int NumberDefaultLength = 12;
            int EPlusPartNumber = 0;


            int NumberLength = 0;
            StringBuilder sbLCDValue = new StringBuilder(_LCDValue.ToString());
            int EIndex = sbLCDValue.ToString().IndexOf("E");
            StringBuilder sbNumberPart = new StringBuilder(sbLCDValue.ToString().Remove(EIndex));//Substring(0, sbLCDValue.Length-EIndex));
            StringBuilder sbEPart = new StringBuilder(sbLCDValue.ToString().Substring(EIndex));

            StringBuilder sbEPower = new StringBuilder(sbEPart.ToString().Substring(1));
            int ENUMBER = Convert.ToInt32(sbEPower.ToString());
            if (sbNumberPart.ToString().Contains('.'))
            {
                DotIndex = sbNumberPart.ToString().IndexOf(".");
                DotPosition = sbNumberPart.Length - DotIndex;
                sbNumberPart = new StringBuilder(sbNumberPart.ToString().Remove(DotIndex, 1));
                NumberLength = sbNumberPart.Length;

                if (sbNumberPart.Length > NumberDefaultLength)
                {
                    CountOfShrinkingDigits = NumberLength - NumberDefaultLength;


                    sbNumberPart = sbNumberPart.Insert(1, '.');
                    double Num = Convert.ToDouble(sbNumberPart.ToString());
                    sbNumberPart.Clear();
                    sbNumberPart = new StringBuilder(Num.ToString("0.00000000000"));
                    sbNumberPart.Remove(1, 1);
                    DotPosition = 16;
                }


                EPlusPartNumber = ENUMBER;
                sbEPower.Clear();
                if (ENUMBER > 0)
                    sbEPower = new StringBuilder("E+" + EPlusPartNumber.ToString());
                else
                    sbEPower = new StringBuilder("E" + EPlusPartNumber.ToString());

                DotPosition = sbNumberPart.Length + sbEPower.Length;
                sbNumberPart.Append(sbEPower.ToString());
                sbLCDValue.Clear();
                sbLCDValue.Append("0000000000000000");
                //sbLCDValue.ToString().Remove( 4);
                sbLCDValue.Append(sbNumberPart);
                _DisplayLCDValue(sbLCDValue);
                _ClearDots();
                _DisplayDot(DotPosition);
                return;
            }
        }
        void _DisplayNumberContainsDot(double _LCDValue)
        {

            int DotIndex = 0;
            int DotPosition = 0;
            int CountOfShrinkingDigits = 0;
            int NumberDefaultLength = 12;

            int DotPower = 0;
            double Number = 0;
            int NumberLength = 0;
            StringBuilder sbLCDValue = new StringBuilder(_LCDValue.ToString());
            if (sbLCDValue.ToString().Contains('.'))
            {

                NumberLength = sbLCDValue.Length - 1;//Dot increases length by 1
                DotIndex = sbLCDValue.ToString().IndexOf(".");
                DotPower = DotIndex - NumberLength;
                DotPosition = NumberLength - DotIndex + 1;

                StringBuilder sbPower;
                int Power = 0;
                if (NumberLength > NumberDefaultLength)
                {
                    CountOfShrinkingDigits = NumberLength - NumberDefaultLength; //E+CountOfShrinkingDigits
                    Power = CountOfShrinkingDigits + DotPower;
                    ////Power += (NumberDefaultLength - 1);

                    //CountOfShrinkingDigits += DotPosition - 1;
                    //StringBuilder sbEPower = new StringBuilder("E+" + CountOfShrinkingDigits.ToString());
                    sbLCDValue = sbLCDValue.Remove(DotIndex, 1);
                    sbLCDValue = sbLCDValue.Insert(1, '.');
                    Number = Convert.ToDouble(sbLCDValue.ToString());
                    sbLCDValue = new StringBuilder(Number.ToString("0.00000000000"));

                    //                       }
                    DotIndex = 1;
                    if (Power > 0)
                        sbPower = new StringBuilder("E+" + Power.ToString());
                    else
                        sbPower = new StringBuilder("E" + Power.ToString());
                    sbLCDValue = new StringBuilder(sbLCDValue.ToString().Remove(DotIndex, 1));
                    Number = Convert.ToDouble(sbLCDValue.ToString());
                    //DotPosition =16;
                    DotPosition = sbLCDValue.Length - 1;
                    sbLCDValue.Clear();
                    sbLCDValue.Append("0000000000000000");

                    //sbLCDValue.ToString().Remove( 4);
                    sbLCDValue.Append(Number);
                    sbLCDValue.Append(sbPower.ToString());
                }
                sbLCDValue.Clear();
                sbLCDValue.Append(_LCDValue);
                sbLCDValue = sbLCDValue.Remove(DotIndex, 1);
                _LCDValue = Convert.ToDouble(sbLCDValue.ToString());
                sbLCDValue.Clear();
                sbLCDValue.Append("0000000000000000");
                sbLCDValue.Append(_LCDValue);
                _DisplayLCDValue(sbLCDValue);
                _ClearDots();
                _DisplayDot(DotPosition);
                return;


            }
        }
        [Category("Screen Properties")]
        public double LCDValue
        {
            get
            {
                bool NegativeNumber = false;
                StringBuilder _LCDValuestr = new StringBuilder();


                _LCDValuestr.Append(Digit15.Digit);
                if (Digit15.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit14.Digit);
                if (Digit14.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit13.Digit);
                if (Digit13.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit12.Digit);
                if (Digit12.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit11.Digit);
                if (Digit11.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit10.Digit);
                if (Digit10.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit9.Digit);
                if (Digit9.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit8.Digit);
                if (Digit8.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit7.Digit);
                if (Digit7.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit6.Digit);
                if (Digit6.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit5.Digit);
                if (Digit5.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit4.Digit);
                if (Digit4.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit3.Digit);
                if (Digit3.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit2.Digit);
                if (Digit2.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit1.Digit);
                if (Digit1.DotExist)
                    _LCDValuestr.Append(".");

                _LCDValuestr.Append(Digit0.Digit);

                int eindex = _LCDValuestr.ToString().IndexOf('E');
                
                int MinusIndex = _LCDValuestr.ToString().IndexOf('-');
                if (_LCDValuestr.ToString().Contains('-') && 
                    _LCDValuestr.ToString().IndexOf('E') > MinusIndex && MinusIndex < 16 || _LCDValuestr.ToString().Contains('-') && _LCDValuestr.ToString().IndexOf('E')==-1)
                {
                    _LCDValuestr = _LCDValuestr.Remove(MinusIndex, 1);
                    NegativeNumber = true;
                }
                
                _LCDValue = Convert.ToDouble(_LCDValuestr.ToString());

                if (NegativeNumber)
                {
                    _LCDValue *= -1;
                }
                return _LCDValue;
            }


            set
            {

                _LCDValue = value;
                int NumberLength = 0;
                int Power = 0;
                int DotIndex = 0;
                int DotPosition = 0;
                int CountOfShrinkingDigits = 0;
                int NumberDefaultLength = 12;
                int EPlusPartNumber = 0;
                int DotPower = 0;
                int ExtraDigitsCount = 0;
                StringBuilder sbLCDValue = new StringBuilder(_LCDValue.ToString());
                NumberLength = sbLCDValue.Length;
                // NumberLength = sbLCDValue.Length;
                double Number = 0;
                if (_LCDValue > 0)
                {

                        if (sbLCDValue.ToString().Contains("E"))
                        {

                            int EIndex = sbLCDValue.ToString().IndexOf("E");
                            StringBuilder sbNumberPart = new StringBuilder(sbLCDValue.ToString().Remove(EIndex));//Substring(0, sbLCDValue.Length-EIndex));
                            StringBuilder sbEPart = new StringBuilder(sbLCDValue.ToString().Substring(EIndex));

                            StringBuilder sbEPower = new StringBuilder(sbEPart.ToString().Substring(1));
                            Power = Convert.ToInt32(sbEPower.ToString());

                            if (sbNumberPart.ToString().Contains('.'))
                            {
                                DotIndex = sbNumberPart.ToString().IndexOf(".");
                                DotPosition = sbNumberPart.Length - DotIndex;
                                sbNumberPart = new StringBuilder(sbNumberPart.ToString().Remove(DotIndex, 1));
                                NumberLength = sbNumberPart.Length;

                                if (sbNumberPart.Length > NumberDefaultLength)
                                {
                                    CountOfShrinkingDigits = NumberLength - NumberDefaultLength;
                                    sbNumberPart = sbNumberPart.Insert(1, '.');
                                    double Num = Convert.ToDouble(sbNumberPart.ToString());
                                    sbNumberPart.Clear();
                                    sbNumberPart = new StringBuilder(Num.ToString("0.0000000000"));
                                    sbNumberPart.Remove(1, 1);
                                    
                                }

                                EPlusPartNumber = Power;
                                sbEPower.Clear();
                                if (Power > 0)
                                    sbEPower = new StringBuilder("E+" + EPlusPartNumber.ToString());
                                else
                                    sbEPower = new StringBuilder("E" + EPlusPartNumber.ToString());

                                DotPosition = sbNumberPart.Length + sbEPower.Length;
                                sbNumberPart.Append(sbEPower.ToString());
                                sbLCDValue.Clear();
                                sbLCDValue.Append("0000000000000000");
                                sbLCDValue.Append(sbNumberPart);
                                _DisplayLCDValue(sbLCDValue);
                                _ClearDots();
                                _DisplayDot(DotPosition);
                                return;
                            }
                        }

                        if (sbLCDValue.ToString().Contains('.'))
                        {
                            DotIndex = sbLCDValue.ToString().IndexOf(".");
                            StringBuilder sbShrinkNumber = new StringBuilder("0000000000000000");
                            sbShrinkNumber.Insert(DotIndex, '.');
                           
                            Number = Convert.ToDouble(sbLCDValue.ToString());
                            sbLCDValue.Clear();
                            sbLCDValue = new StringBuilder(Number.ToString(sbShrinkNumber.ToString()));
                            sbLCDValue.Remove(DotIndex, 1);
                            StringBuilder sbTemp = new StringBuilder(sbLCDValue.ToString());
                            sbLCDValue.Clear();
                            sbLCDValue = new StringBuilder("00000000000000000");
                            sbLCDValue.Append(sbTemp.ToString());                           
                            DotPosition = 17 - DotIndex;
                            _DisplayLCDValue(sbLCDValue);
                            _ClearDots();
                            _DisplayDot(DotPosition);
                            return;
                        }

                        StringBuilder sbLCDasString = new StringBuilder("0000000000000000");
                        sbLCDasString.Append(sbLCDValue);
                        _DisplayLCDValue(sbLCDasString);
                        _ClearDots();
                        _DisplayDot(DotPosition);
                        return;

                }
                else /*if (_LCDValue < 0)*/
                {
                    _LCDValue *= -1;
                    NumberLength = sbLCDValue.Length;
                    sbLCDValue = new StringBuilder(_LCDValue.ToString());

                        if (sbLCDValue.ToString().Contains("E"))
                        {

                            int EIndex = sbLCDValue.ToString().IndexOf("E");
                            StringBuilder sbNumberPart = new StringBuilder(sbLCDValue.ToString().Remove(EIndex));//Substring(0, sbLCDValue.Length-EIndex));
                            StringBuilder sbEPart = new StringBuilder(sbLCDValue.ToString().Substring(EIndex));

                            StringBuilder sbEPower = new StringBuilder(sbEPart.ToString().Substring(1));
                            Power = Convert.ToInt32(sbEPower.ToString());

                            if (sbNumberPart.ToString().Contains('.'))
                            {
                                DotIndex = sbNumberPart.ToString().IndexOf(".");
                                DotPosition = sbNumberPart.Length - DotIndex;
                                sbNumberPart = new StringBuilder(sbNumberPart.ToString().Remove(DotIndex, 1));
                                NumberLength = sbNumberPart.Length;

                                if (sbNumberPart.Length > NumberDefaultLength-1)
                                {
                                    CountOfShrinkingDigits = NumberLength - NumberDefaultLength;
                                    sbNumberPart = sbNumberPart.Insert(1, '.');
                                    double Num = Convert.ToDouble(sbNumberPart.ToString());
                                    sbNumberPart.Clear();
                                    sbNumberPart = new StringBuilder(Num.ToString("0.000000000"));
                                    sbNumberPart.Remove(1, 1);
                                }


                                EPlusPartNumber = Power;
                                sbEPower.Clear();
                                if (Power > 0)
                                    sbEPower = new StringBuilder("E+" + EPlusPartNumber.ToString());
                                else
                                    sbEPower = new StringBuilder("E" + EPlusPartNumber.ToString());

                                DotPosition = sbNumberPart.Length + sbEPower.Length;
                                Number = Convert.ToDouble(sbNumberPart.ToString()) * -1;
                                sbNumberPart.Clear();
                                sbNumberPart.Append(Number);
                                sbNumberPart.Append(sbEPower.ToString());
                                sbLCDValue.Clear();
                                sbLCDValue.Append("0000000000000000");
                                sbLCDValue.Append(sbNumberPart);
                                _DisplayLCDValue(sbLCDValue);
                                _ClearDots();
                                _DisplayDot(DotPosition);
                                return;
                            }
                           

                        }
                        if (sbLCDValue.ToString().Contains('.'))
                        {
                            DotIndex = sbLCDValue.ToString().IndexOf(".");
                            StringBuilder sbShrinkNumber = new StringBuilder("000000000000000");
                            sbShrinkNumber.Insert(DotIndex, '.');
                            Number = Convert.ToDouble(sbLCDValue.ToString())*-1;
                            sbLCDValue.Clear();
                            sbLCDValue = new StringBuilder(Number.ToString(sbShrinkNumber.ToString()));
                            sbLCDValue.Remove(DotIndex+1, 1);
                            StringBuilder sbTemp = new StringBuilder(sbLCDValue.ToString());
                            sbLCDValue.Clear();
                            sbLCDValue = new StringBuilder("0000000000000000");
                            sbLCDValue.Append(sbTemp.ToString());

                            DotPosition = 16 - DotIndex;
                            _DisplayLCDValue(sbLCDValue);
                            _ClearDots();
                            _DisplayDot(DotPosition);
                            return;
                          
                        }

                        StringBuilder sbLCDasString = new StringBuilder("0000000000000000");
                        Number = Convert.ToDouble(sbLCDValue.ToString()) * -1;
                        sbLCDasString.Append(Number);
                        _DisplayLCDValue(sbLCDasString);
                        _ClearDots();
                        _DisplayDot(DotPosition);
                        return;
                   
                }
            }
        }



        #endregion



        void _ClearDots()
        {
            Digit0.DotExist = false;
            Digit1.DotExist = false;
            Digit2.DotExist = false;
            Digit3.DotExist = false;
            Digit4.DotExist = false;
            Digit5.DotExist = false;
            Digit6.DotExist = false;
            Digit7.DotExist = false;
            Digit8.DotExist = false;
            Digit9.DotExist = false;
            Digit10.DotExist = false;
            Digit11.DotExist = false;
            Digit12.DotExist = false;
            Digit13.DotExist = false;
            Digit14.DotExist = false;
            Digit15.DotExist = false;

        }
        void _DisplayDot(int DotPosition)
        {

            switch (DotPosition)
            {
                case 2:
                    Digit1.DotExist = true;
                    break;
                case 3:
                    Digit2.DotExist = true;
                    break;
                case 4:
                    Digit3.DotExist = true;
                    break;
                case 5:
                    Digit4.DotExist = true;
                    break;
                case 6:
                    Digit5.DotExist = true;
                    break;
                case 7:
                    Digit6.DotExist = true;
                    break;
                case 8:
                    Digit7.DotExist = true;
                    break;

                case 9:
                    Digit8.DotExist = true;
                    break;

                case 10:
                    Digit9.DotExist = true;
                    break;

                case 11:
                    Digit10.DotExist = true;
                    break;

                case 12:
                    Digit11.DotExist = true;
                    break;

                case 13:
                    Digit12.DotExist = true;
                    break;

                case 14:
                    Digit13.DotExist = true;
                    break;

                case 15:
                    Digit14.DotExist = true;
                    break;

                case 16:
                    Digit15.DotExist = true;
                    break;

                default:
                    break;
            }

        }

        void _DisplayLCDValue(StringBuilder LCDasString)
        {
            Digit0.Digit = LCDasString[LCDasString.Length - 1];
            Digit1.Digit = LCDasString[LCDasString.Length - 2];
            Digit2.Digit = LCDasString[LCDasString.Length - 3];
            Digit3.Digit = LCDasString[LCDasString.Length - 4];
            Digit4.Digit = LCDasString[LCDasString.Length - 5];
            Digit5.Digit = LCDasString[LCDasString.Length - 6];
            Digit6.Digit = LCDasString[LCDasString.Length - 7];
            Digit7.Digit = LCDasString[LCDasString.Length - 8];
            Digit8.Digit = LCDasString[LCDasString.Length - 9];
            Digit9.Digit = LCDasString[LCDasString.Length - 10];
            Digit10.Digit = LCDasString[LCDasString.Length - 11];
            Digit11.Digit = LCDasString[LCDasString.Length - 12];
            Digit12.Digit = LCDasString[LCDasString.Length - 13];
            Digit13.Digit = LCDasString[LCDasString.Length - 14];
            Digit14.Digit = LCDasString[LCDasString.Length - 15];
            Digit15.Digit = LCDasString[LCDasString.Length - 16];
        }



        void LoadDefaultScreenValue()
        {
            Digit0.Digit = '0';
            Digit1.Digit = '0';
            Digit2.Digit = '0';
            Digit3.Digit = '0';
            Digit4.Digit = '0';
            Digit5.Digit = '0';
            Digit6.Digit = '0';
            Digit7.Digit = '0';
            Digit8.Digit = '0';
            Digit9.Digit = '0';
            Digit10.Digit = '0';
            Digit11.Digit = '0';
            Digit12.Digit = '0';
            Digit13.Digit = '0';
            Digit14.Digit = '0';
            Digit15.Digit = '0';

        }
        public void ResetScreen()
        {
            StringBuilder start = new StringBuilder("000000000000000000");
            _DisplayLCDValue(start);
        }
        private void ctrlLCDScreen_Load(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void digitsColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            colorDialog1.AnyColor = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                DigitsColor = colorDialog1.Color;
        }

        private void screenColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            colorDialog1.AnyColor = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                ScreenColor = colorDialog1.Color;
        }
    }
}
