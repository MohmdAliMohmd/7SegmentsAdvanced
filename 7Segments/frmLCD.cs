using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _7Segments
{
    public partial class frmLCD : Form
    {
        public frmLCD()
        {
            InitializeComponent();
        }

      

        StringBuilder _sbInPut = new StringBuilder();
        byte _InputTimes = 0;
        bool _ContainsDot = false;
        enum _enOperation { Start =0,Add =1,Sub =2, Multipe =3,Divide =4,Equals =5}
        _enOperation _Operation = _enOperation.Start;
        double _Number1 = 0;
        double _Number2 = 0;
        double _Result = 0;

        double _Calculate(double number1, double number2)
        {
            double Result = 0;
            switch (_Operation)
            {
                case _enOperation.Add:
                    Result = _Number1+ number2;
                    return Result;
                case _enOperation.Sub:
                    Result = _Number1- number2;
                    return Result;
                case _enOperation.Multipe:
                    Result = _Number1 * number2;
                    return Result;
                case _enOperation.Divide:
                    try 
                    {
                        Result = _Number1 / _Number2;
                        return Result;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return Result;
                    }
                    default:
                    return Result;
            }
        }

        void DoOperations()
        {
            //if (_Operation == _enOperation.Start)
            //{
            //    _Result = 0;
            //    _Number1 = 0;
            //    _Number2 = 0;
                
            //    _Number1 = ctrLCD1.LCDValue;
            //    txtNumber1.Text = _Number1.ToString();
            //    txtNumber2.Text = _Number2.ToString();
            //    txtResult.Text = _Result.ToString();
            //}
            //if(_Operation == _enOperation.Sub)
            //{
                
            //    _Number2 = ctrLCD1.LCDValue;
            //    _Result = _Number1 - _Number2;
            //    txtNumber1.Text = _Number1.ToString();
            //    txtNumber2.Text = _Number2.ToString();
            //    txtResult.Text = _Result.ToString();
            //}
            //if(_Operation == _enOperation.Equals)
            //{
            //    ctrLCD1.LCDValue = _Result;
            //    txtNumber1.Text = _Number1.ToString();
            //    txtNumber2.Text = _Number2.ToString();
            //    txtResult.Text = _Result.ToString();
            //}

            switch(_Operation)
            {
                case _enOperation.Start:
                    _Result = 0;
                    _Number1 = 0;
                    _Number2 = 0;

                    _Number1 = ctrLCD1.LCDValue;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Add:
                    _Number2 = ctrLCD1.LCDValue;
                    _Result = _Number1 + _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Sub:
                    _Number2 = ctrLCD1.LCDValue;
                    _Result = _Number1 - _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Multipe:
                    _Number2 = ctrLCD1.LCDValue;
                    _Result = _Number1 * _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Divide:
                    _Number2 = ctrLCD1.LCDValue;
                    try
                    {
                        _Result = _Number1 / _Number2;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    }
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Equals:
                    ctrLCD1.LCDValue = _Result;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                default:
                    _Result = 0;
                    _Number1 = 0;
                    _Number2 = 0;

                    _Number1 = ctrLCD1.LCDValue;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;

            }    
        }
        void _SetOperation(_enOperation Operation)
        {
            _Operation = Operation;
           

            txtOperation.Text = _Operation.ToString();
        }


        void _InActiveNumbers()
        {
            btnOne.Enabled = false;
            btnTwo.Enabled = false;
            btnThree.Enabled = false;
            btnFour.Enabled = false;
            btnFive.Enabled = false;
            btnSix.Enabled = false;
            btnSeven.Enabled = false;
            btnEight.Enabled = false;
            btnNine.Enabled = false;
            btnZero.Enabled = false;
            btnDot.Enabled = false;
        }
        void _ActiveNumbers()
        {
            btnOne.Enabled = true;
            btnTwo.Enabled = true;
            btnThree.Enabled = true;
            btnFour.Enabled = true;
            btnFive.Enabled = true;
            btnSix.Enabled = true;
            btnSeven.Enabled = true;
            btnEight.Enabled = true;
            btnNine.Enabled = true;
            btnZero.Enabled = true;
            btnDot.Enabled = true;
        }
        void _GetInPut(string input)
        {
            if (_InputTimes == 0)
            {
                btnBack.Enabled = false;
            }
            else
            {
                btnBack.Enabled = Enabled;
            }

            if (input.Equals( string.Empty))
            {
                _sbInPut.Remove(_sbInPut.Length - 1, 1);
                ctrLCD1.LCDValue = Convert.ToDouble(_sbInPut.ToString());
                DoOperations();
                _InputTimes--;
                if(_InputTimes ==0)
                {
                    btnBack.Enabled = false;
                }
                
                return;
            }
            
            _sbInPut.Append(input);
            if(Convert.ToDouble( _sbInPut.ToString())!=0 && !input.Equals("."))
             _InputTimes++;
            txtInputTimes.Text = _InputTimes.ToString();
            if (_InputTimes == 8)
                _InActiveNumbers();

            ctrLCD1.LCDValue = Convert.ToDouble(_sbInPut.ToString());
           
        }
        private void btnGetValue_Click(object sender, EventArgs e)
        {
            txtScreen.Text = ctrLCD1.LCDValue.ToString();
        }

        private void btnSetLCDValue_Click(object sender, EventArgs e)
        {
            ctrLCD1.LCDValue = 12.12365d;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ctrLCD1.LCDValue = 0;
            _sbInPut.Clear();
            _sbInPut.Append("00000000");
            _InputTimes = 0;
            _ActiveNumbers();
            _Operation = _enOperation.Start;
            DoOperations();
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            _GetInPut("7");
            DoOperations();
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            _GetInPut("8");
            DoOperations();
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            _GetInPut("9");
            DoOperations();
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            _GetInPut("4");
            DoOperations();
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            _GetInPut("5");
            DoOperations();
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            _GetInPut("6");
            DoOperations();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            _GetInPut("1");
            DoOperations();
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            _GetInPut("2");
            DoOperations();

        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            _GetInPut("3");
            DoOperations();

        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            _GetInPut("0");
            DoOperations();

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            _GetInPut(".");
            _ContainsDot = true;
            btnDot.Enabled = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            _SetOperation(_enOperation.Divide);
            ctrLCD1.LCDValue = 0;
            _sbInPut.Clear();
            _InputTimes = 0;
            _ActiveNumbers();
            if (_Result != 0)
            {
                _Number1 = _Result;
                _Result = 0;
            }
            DoOperations();
        }

        private void btnMultip_Click(object sender, EventArgs e)
        {
            _SetOperation(_enOperation.Multipe);

            ctrLCD1.LCDValue = 0;
            _sbInPut.Clear();
            _InputTimes = 0;
            _ActiveNumbers();
            if (_Result != 0)
            {
                _Number1 = _Result;
                _Result = 0;
            }
            DoOperations();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            _SetOperation(_enOperation.Sub);
            ctrLCD1.LCDValue = 0;
            _sbInPut.Clear();
            _InputTimes = 0;
            _ActiveNumbers();
            if(_Result != 0)
            { _Number1 = _Result;
                _Result = 0;
            }
            DoOperations();


            
          
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _SetOperation(_enOperation.Add);
            ctrLCD1.LCDValue = 0;
            _sbInPut.Clear();
            _InputTimes = 0;
            _ActiveNumbers();
            if (_Result != 0)
            {
                _Number1 = _Result;
                _Result = 0;
            }
            DoOperations();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            
            _SetOperation(_enOperation.Equals);
            DoOperations();
        }

        private void frmLCD_Load(object sender, EventArgs e)
        {
            _sbInPut.Append("00000000");
            _InputTimes = 0;
            btnBack.Enabled = false;
            ctrLCD1.LCDValue = 0;
            _Operation = _enOperation.Start;
            DoOperations();
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _GetInPut("");
        }
    }
}
