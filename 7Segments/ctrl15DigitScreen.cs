using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7Segments
{
    public partial class ctrl15DigitScreen : UserControl
    {
        public ctrl15DigitScreen()
        {
            InitializeComponent();
        }


        private Color _DigitsColor;
        private Color _ScreenColor;
        private double _LCDValue;
        
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
                this.BackColor = ScreenColor;
            }
        }

        [Category("Screen Properties")]
        public bool ContainDot
        {
            get
            {
                return (
                    Digit0.DotExist || Digit1.DotExist ||
                    Digit2.DotExist || Digit3.DotExist ||
                    Digit4.DotExist || Digit5.DotExist ||
                    Digit6.DotExist || Digit7.DotExist ||
                    Digit8.DotExist || Digit9.DotExist ||
                    Digit10.DotExist || Digit11.DotExist ||
                    Digit12.DotExist || Digit13.DotExist ||
                    Digit14.DotExist
                      );
            }
        }


        [Category("Screen Properties")]
        public double LCDValue
        {
            get
            {
                StringBuilder sbGetLCDValue = new StringBuilder();


                sbGetLCDValue.Append(Digit14.Digit);
                if (Digit14.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit13.Digit);
                if (Digit13.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit12.Digit);
                if (Digit12.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit11.Digit);
                if (Digit11.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit10.Digit);
                if (Digit10.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit9.Digit);
                if (Digit9.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit8.Digit);
                if (Digit8.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit7.Digit);
                if (Digit7.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit6.Digit);
                if (Digit6.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit5.Digit);
                if (Digit5.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit4.Digit);
                if (Digit4.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit3.Digit);
                if (Digit3.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit2.Digit);
                if (Digit2.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit1.Digit);
                if (Digit1.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(Digit0.Digit);
                
                _LCDValue = Convert.ToDouble(sbGetLCDValue.ToString());


                return _LCDValue;
            }
            set
            {
                _LCDValue = value;
                
                StringBuilder LCDasString = new StringBuilder("000000000000000");
                LCDasString.Append(_LCDValue);
                if (!LCDasString.ToString().Contains("."))
                {
                   
                    _ClearDots();
                    _DisplayLCDValue(LCDasString);
                }
                else
                {
                    _ClearDots();
                    
                    int DotIndex = LCDasString.ToString().IndexOf(".");
                    int DotPosition = LCDasString.Length - DotIndex;
                    StringBuilder LCDStringWithOutDot = new StringBuilder(LCDasString.ToString().Remove(DotIndex, 1));
                    _DisplayLCDValue(LCDStringWithOutDot);
                    _DisplayDot(DotPosition);

                    //sbGetDotIndex.Length - sbGetDotIndex.ToString().IndexOf(".")
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

                default:
                    break;
            }

        }

        void _DisplayLCDValue(StringBuilder LCDasString)
        {
            Digit0.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 1].ToString());
            Digit1.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 2].ToString());
            Digit2.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 3].ToString());
            Digit3.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 4].ToString());
            Digit4.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 5].ToString());
            Digit5.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 6].ToString());
            Digit6.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 7].ToString());
            Digit7.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 8].ToString());
            Digit8.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 9].ToString());
            Digit9.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 10].ToString());
            Digit10.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 11].ToString());
            Digit11.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 12].ToString());
            Digit12.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 13].ToString());
            Digit13.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 14].ToString());
            Digit14.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 15].ToString());
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
        void LoadDefaultScreenValue()
        {
            Digit0.Digit = 0;
            Digit1.Digit = 0;
            Digit2.Digit = 0;
            Digit3.Digit = 0;
            Digit4.Digit = 0;
            Digit5.Digit = 0;
            Digit6.Digit = 0;
            Digit7.Digit = 0;
            Digit8.Digit = 0;
            Digit9.Digit = 0;
            Digit10.Digit = 0;
            Digit11.Digit = 0;
            Digit12.Digit = 0;
            Digit13.Digit = 0;
            Digit14.Digit = 0;
            
        }
        private void ctrl15DigitScreen_Load(object sender, EventArgs e)
        {
            LoadDefaultScreenValue();
            _ClearDots();


        }
    }
}
