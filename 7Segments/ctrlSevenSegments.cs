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
    public partial class ctrlSevenSegments : UserControl
    {
        public ctrlSevenSegments()
        {
            InitializeComponent();
        }

        private Color _BackgroundColor;
        private Color _FrontColor;
        private byte _Digit;
        private bool _DotExist;

        #region
        [Category("Segments Properties")]
        public Color BackGroundColor
        {
            get { return _BackgroundColor; }
            set { _BackgroundColor = value; 
            this.BackColor = _BackgroundColor;
            }
        }


        [Category("Segments Properties")]
        public Color FrontColor
        {
            get { return _FrontColor; }
            set { _FrontColor = value;
                
                btn1.BackColor = _FrontColor;
                btn2.BackColor = _FrontColor;
                btn3.BackColor = _FrontColor;
                btn4.BackColor = _FrontColor;
                btn5.BackColor = _FrontColor;
                btn6.BackColor = _FrontColor;
                btn7.BackColor = _FrontColor;
                btnDot.BackColor = _FrontColor;
            }
        }

        [Category("Segments Properties")]
        public byte Digit
        {
            get { return _Digit; }
            set { _Digit = value;
            
                switch(_Digit)
                {
                    case 0:
                       btn1.BackColor = FrontColor;
                       btn2.BackColor = FrontColor;
                       btn3.BackColor = BackGroundColor;
                       btn4.BackColor = FrontColor;
                       btn5.BackColor = FrontColor;
                       btn6.BackColor = FrontColor;
                       btn7.BackColor = FrontColor;
                        break;
                    case (1):
                        
                        btn1.BackColor = BackGroundColor;
                        btn2.BackColor = FrontColor;
                        btn3.BackColor = BackGroundColor;
                        btn4.BackColor = BackGroundColor;
                        btn5.BackColor = BackGroundColor;
                        btn6.BackColor = FrontColor;
                        btn7.BackColor = BackGroundColor;
                        break;
                    case 2:
                        btn1.BackColor = FrontColor;
                        btn2.BackColor = FrontColor;
                        btn3.BackColor = FrontColor;
                        btn4.BackColor = BackGroundColor;
                        btn5.BackColor = FrontColor;
                        btn6.BackColor = BackGroundColor;
                        btn7.BackColor = FrontColor;
                        break;
                    case 3:
                        btn1.BackColor = FrontColor;
                        btn2.BackColor = FrontColor;
                        btn3.BackColor = FrontColor;
                        btn4.BackColor = BackGroundColor;
                        btn5.BackColor = BackGroundColor;
                        btn6.BackColor = FrontColor;
                        btn7.BackColor = FrontColor;
                        break;
                    case 4:
                        btn1.BackColor = BackGroundColor;
                        btn2.BackColor = FrontColor;
                        btn3.BackColor = FrontColor;
                        btn4.BackColor = FrontColor;
                        btn5.BackColor = BackGroundColor;
                        btn6.BackColor = FrontColor;
                        btn7.BackColor = BackGroundColor;
                        break;
                    case 5:
                       btn1.BackColor = FrontColor;
                       btn2.BackColor = BackGroundColor;
                       btn3.BackColor = FrontColor;
                       btn4.BackColor = FrontColor;
                       btn5.BackColor = BackGroundColor;
                       btn6.BackColor = FrontColor;
                       btn7.BackColor = FrontColor;
                        break;
                    case 6:
                        btn1.BackColor = FrontColor;
                        btn2.BackColor = BackGroundColor;
                        btn3.BackColor = FrontColor;
                        btn4.BackColor = FrontColor;
                        btn5.BackColor = FrontColor;
                        btn6.BackColor = FrontColor;
                        btn7.BackColor = FrontColor;
                        break;
                    case 7:
                        btn1.BackColor = FrontColor;
                        btn2.BackColor = FrontColor;
                        btn3.BackColor = BackGroundColor;
                        btn4.BackColor = BackGroundColor;
                        btn5.BackColor = BackGroundColor;
                        btn6.BackColor = FrontColor;
                        btn7.BackColor = BackGroundColor;
                        break;
                    case 9:
                        btn1.BackColor = FrontColor;
                        btn2.BackColor = FrontColor;
                        btn3.BackColor = FrontColor;
                        btn4.BackColor = FrontColor;
                        btn5.BackColor = BackGroundColor;
                        btn6.BackColor = FrontColor;
                        btn7.BackColor = FrontColor;
                        break;
                    case 10:// mreans E
                        btn1.BackColor = FrontColor;
                        btn2.BackColor = BackGroundColor;
                        btn3.BackColor = FrontColor;
                        btn4.BackColor = FrontColor;
                        btn5.BackColor = FrontColor;
                        btn6.BackColor = BackGroundColor;
                        btn7.BackColor = FrontColor;
                        break;
                    default:
                        btn1.BackColor = FrontColor;
                        btn2.BackColor = FrontColor;
                        btn3.BackColor = FrontColor;
                        btn4.BackColor = FrontColor;
                        btn5.BackColor = FrontColor;
                        btn6.BackColor = FrontColor;
                        btn7.BackColor = FrontColor;
                        break;

                }
            
            }
        }



        [Category("Segments Properties")]
        public bool DotExist
        {
            get { return _DotExist; }
            set { _DotExist = value;
                if (_DotExist)
                    btnDot.BackColor = FrontColor;
                else
                    btnDot.BackColor = BackGroundColor;
            }
        }
        #endregion
        private void ctrlSevenSegments_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            DotExist = false;


        }

       
    }
}
