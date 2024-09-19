using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics.Eventing.Reader;
namespace _7Segments
{
    public partial class ctrLCD : UserControl
    {
        public ctrLCD()
        {
            InitializeComponent();
        }

        private Color _ScreenColor;

        public Color ScreenColor
        {
            get { return _ScreenColor; }
            set
            {
                _ScreenColor = value;

                ctrlOnes.BackGroundColor = ScreenColor;
                ctrlTens.BackGroundColor = ScreenColor;
                ctrlHundreds.BackGroundColor = ScreenColor;
                ctrlThousands.BackGroundColor = ScreenColor;
                ctrlTensOfThousands.BackGroundColor = ScreenColor;
                ctrlHundredsOfThousands.BackGroundColor = ScreenColor;
                ctrlMillions.BackGroundColor = ScreenColor;
                ctrlTensOfMillions.BackGroundColor = ScreenColor;
                this.BackColor = ScreenColor;
            }
        }

        private Color _DigitsColor;

        public Color DigitsColor
        {
            get { return _DigitsColor; }
            set
            {
                _DigitsColor = value;
                ctrlOnes.FrontColor = _DigitsColor;
                ctrlTens.FrontColor = _DigitsColor;
                ctrlHundreds.FrontColor = _DigitsColor;
                ctrlThousands.FrontColor = _DigitsColor;
                ctrlTensOfThousands.FrontColor = _DigitsColor;
                ctrlHundredsOfThousands.FrontColor = _DigitsColor;
                ctrlMillions.FrontColor = _DigitsColor;
                ctrlTensOfMillions.FrontColor = _DigitsColor;

            }
        }


        private bool _ContainsDot;

        public bool ContainsDot
        {
            get { return _ContainsDot; }
            set
            {
                _ContainsDot = value;
                if (_ContainsDot)
                    DotValue = _GetDotValue();
                else
                    DotValue = 1;
            }
        }
        double DotValue;
        double _GetDotValue()
        {
            if (ctrlOnes.DotExist)
                return 1;

            if (ctrlTens.DotExist)
                return Math.Pow(10, -1);
            if (ctrlHundreds.DotExist)
                return Math.Pow(10, -2);
            if (ctrlThousands.DotExist)
                return Math.Pow(10, -3);
            if (ctrlTensOfThousands.DotExist)
                return Math.Pow(10, -4);
            if (ctrlHundredsOfThousands.DotExist)
                return Math.Pow(10, -5);
            if (ctrlMillions.DotExist)
                return Math.Pow(10, -6);
            if (ctrlTensOfMillions.DotExist)
                return Math.Pow(10, -7);
            else
                return 1;
        }

        double _Ones = Math.Pow(10, 0);
        double _Tens = Math.Pow(10, 1);
        double _Hundreds = Math.Pow(10, 2);
        double _Thusands = Math.Pow(10, 3);
        double _TensOfThusands = Math.Pow(10, 4);
        double _HundresOfThusand = Math.Pow(10, 5);
        double _Millions = Math.Pow(10, 6);
        double _TensOfMillions = Math.Pow(10, 7);

        void _SetDigitsWight()
        {
            _Ones = _GetDotValue();
            _Tens *= _GetDotValue();
            _Hundreds *= _GetDotValue();
            _Thusands *= _GetDotValue();
            _TensOfThusands *= _GetDotValue();
            _HundresOfThusand *= _GetDotValue();
            _Millions *= _GetDotValue();
            _TensOfMillions *= _GetDotValue();


        }

        private double _LCDValue;
        void _DisplayLCDValue(StringBuilder LCDasString)
        {
            ctrlOnes.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 1].ToString());
            ctrlTens.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 2].ToString());
            ctrlHundreds.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 3].ToString());
            ctrlThousands.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 4].ToString());
            ctrlTensOfThousands.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 5].ToString());
            ctrlHundredsOfThousands.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 6].ToString());
            ctrlMillions.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 7].ToString());
            ctrlTensOfMillions.Digit = Convert.ToByte(LCDasString[LCDasString.Length - 8].ToString());
        }

        void ClearDots()
        {
            ctrlTens.DotExist                = false;
            ctrlHundreds.DotExist            = false;
            ctrlThousands.DotExist           = false;
            ctrlTensOfThousands.DotExist     = false;
            ctrlHundredsOfThousands.DotExist = false;
            ctrlMillions.DotExist            = false;
            ctrlTensOfMillions.DotExist      = false;
        }
        void _DisplayDot(int DotPosition)
        {

            switch (DotPosition)
            {
                case 2:
                    ctrlTens.DotExist = true;
                    break;
                case 3:
                    ctrlHundreds.DotExist = true;
                    break;
                case 4:
                    ctrlThousands.DotExist = true;
                    break;
                case 5:
                    ctrlTensOfThousands.DotExist = true;
                    break;
                case 6:
                    ctrlHundredsOfThousands.DotExist = true;
                    break;
                case 7:
                    ctrlMillions.DotExist = true;
                    break;
                case 8:
                    ctrlTensOfMillions.DotExist = true;
                    break;
                default:
                    break;
            }

        }

      
        

       

        public double LCDValue
        {
            get {
                StringBuilder sbGetLCDValue = new StringBuilder();


                    sbGetLCDValue.Append(ctrlTensOfMillions.Digit);
                if (ctrlTensOfMillions.DotExist)
                    sbGetLCDValue.Append(".");

                
                sbGetLCDValue.Append(ctrlMillions.Digit);
                if (ctrlMillions.DotExist)
                    sbGetLCDValue.Append(".");

               
                sbGetLCDValue.Append(ctrlHundredsOfThousands.Digit);
                if (ctrlHundredsOfThousands.DotExist)
                    sbGetLCDValue.Append(".");

                
                sbGetLCDValue.Append(ctrlTensOfThousands.Digit);
                if (ctrlTensOfMillions.DotExist)
                    sbGetLCDValue.Append(".");

                
                sbGetLCDValue.Append(ctrlThousands.Digit);
                if (ctrlThousands.DotExist)
                    sbGetLCDValue.Append(".");

                
                sbGetLCDValue.Append(ctrlHundreds.Digit);
                if (ctrlHundreds.DotExist)
                    sbGetLCDValue.Append(".");

                
                sbGetLCDValue.Append(ctrlTens.Digit);
                if (ctrlTens.DotExist)
                    sbGetLCDValue.Append(".");

                sbGetLCDValue.Append(ctrlOnes.Digit);
                _LCDValue = Convert.ToDouble(sbGetLCDValue.ToString());

                return _LCDValue; 
            }

            set
            {
                _LCDValue = value;

                StringBuilder LCDasString = new StringBuilder("00000000");
                LCDasString.Append(_LCDValue);
                if (!LCDasString.ToString().Contains("."))
                {
                    ClearDots();
                    _DisplayLCDValue(LCDasString);
                }
                else
                {
                    ClearDots();
                    int DotIndex = LCDasString.ToString().IndexOf(".");
                    int DotPosition = LCDasString.Length - DotIndex;
                    StringBuilder LCDStringWithOutDot = new StringBuilder(LCDasString.ToString().Remove(DotIndex, 1));
                    _DisplayLCDValue(LCDStringWithOutDot);
                    _DisplayDot(DotPosition);
                 
                    //sbGetDotIndex.Length - sbGetDotIndex.ToString().IndexOf(".")
                }



            }
        }





        private void ctrLCD_Load(object sender, EventArgs e)
        {
            ctrlThousands.DotExist = false;
            ctrlMillions.DotExist = false;
            ctrlOnes.DotExist = false;
            ctrlTens.DotExist = false;
            ctrlHundreds.DotExist = false;
            ctrlTensOfThousands.DotExist = false;
            ctrlHundredsOfThousands.DotExist = false;
            ctrlTensOfMillions.DotExist = false;
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
