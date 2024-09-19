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
    public partial class frmTestLCD : Form
    {
        public frmTestLCD()
        {
            InitializeComponent();
        }
        StringBuilder _sbInPut = new StringBuilder();
        byte _InputTimes = 0;
        bool _ContainsDot = false;
        enum _enOperation { Start = 0, Add = 1, Sub = 2, Multipe = 3, Divide = 4, Equals = 5, Clear = 6 }
        _enOperation _Operation = _enOperation.Start;
        _enOperation _PreviousOperation = _enOperation.Equals;
        _enOperation _LastOperation = _enOperation.Equals;
        double _Number1 = 0;
        double _Number2 = 0;
        double _Result = 0;
        double _TempResult = 0;
        double _PreviousNumber = 0;

        void FinalResult()
        {

            switch (_LastOperation)
            {
                case _enOperation.Start:
                    _Result = 0;
                    _Number1 = 0;
                    _Number2 = 0;
                    _TempResult = 0;

                    _Number1 = ctrlLCDScreen1.LCDValue;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Add:
                    _Number2 = ctrlLCDScreen1.LCDValue;
                    _Result = _Number1 + _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Sub:
                    _Number2 = ctrlLCDScreen1.LCDValue;
                    _Result = _Number1 - _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Multipe:
                    _Number2 = ctrlLCDScreen1.LCDValue;
                    _Result = _Number1 * _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Divide:
                    _Number2 = ctrlLCDScreen1.LCDValue;
                    try
                    {
                        _Result = _Number1 / _Number2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
            }
        }
        void DoOperations()
        {


            switch (_Operation)
            {
                case _enOperation.Start:
                    _Result = 0;
                    _Number1 = 0;
                    _Number2 = 0;
                    _TempResult = 0;

                    _Number1 = ctrlLCDScreen1.LCDValue;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;
                case _enOperation.Add:
                    _Number2 = ctrlLCDScreen1.LCDValue;
                    _TempResult = _Number1 + _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtTempResult.Text = _TempResult.ToString();
                    break;
                case _enOperation.Sub:
                    _Number2 = ctrlLCDScreen1.LCDValue;
                    _TempResult = _Number1 - _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtTempResult.Text = _TempResult.ToString();
                    break;
                case _enOperation.Multipe:
                    _Number2 = ctrlLCDScreen1.LCDValue;
                    _TempResult = _Number1 * _Number2;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtTempResult.Text = _TempResult.ToString();
                    break;
                case _enOperation.Divide:
                    _Number2 = ctrlLCDScreen1.LCDValue;
                    try
                    {
                        _TempResult = _Number1 / _Number2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtTempResult.Text = _TempResult.ToString();
                    break;
                case _enOperation.Equals:
                    FinalResult();
                    ctrlLCDScreen1.LCDValue = _Result;

                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    //  _SetOperation(_PreviousOperation);
                    //_Operation = _PreviousOperation;
                    break;
                default:
                    _Result = 0;
                    _Number1 = 0;
                    _Number2 = 0;

                    _Number1 = ctrlLCDScreen1.LCDValue;
                    txtNumber1.Text = _Number1.ToString();
                    txtNumber2.Text = _Number2.ToString();
                    txtResult.Text = _Result.ToString();
                    break;

            }
        }
        void _SetOperation(_enOperation Operation)
        {
            if (_LastOperation != _enOperation.Equals)
                _PreviousOperation = _LastOperation;
            _LastOperation = _Operation;
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

            btnDot.Enabled = !ctrlLCDScreen1.ContainsDot;
        }
        void _GetInPut(string input)
        {

            if (input.Equals(".") && _InputTimes == 0)
            {
                btnBack.Enabled = true;
            }

            if (input.Equals(string.Empty))
            {
                _sbInPut.Remove(_sbInPut.Length - 1, 1);
                ctrlLCDScreen1.LCDValue = Convert.ToDouble(_sbInPut.ToString());
                DoOperations();
                _InputTimes--;
                if (/*_InputTimes == 0 ||*/ Convert.ToDouble(_sbInPut.ToString()) == 0)
                {
                    btnBack.Enabled = false;
                    btnDot.Enabled = true;
                }

                return;
            }

            _sbInPut.Append(input);
            if (Convert.ToDouble(_sbInPut.ToString()) != 0 || input.Equals("."))
                _InputTimes++;

            txtInputTimes.Text = _InputTimes.ToString();
            if (_InputTimes == 16)
                _InActiveNumbers();

            ctrlLCDScreen1.LCDValue = Convert.ToDouble(_sbInPut.ToString());
            if (_InputTimes == 0 || ctrlLCDScreen1.LCDValue == 0)
            {
                btnBack.Enabled = false;

            }
            else
            {
                btnBack.Enabled = Enabled;
            }
        }
        void DoCalculation()
        {

            switch (_PreviousOperation)
            {
                case _enOperation.Add:
                    _Result += _Number2;
                    ctrlLCDScreen1.LCDValue = _Result;
                    txtResult.Text = _Result.ToString();
                    btnDot.Enabled = !ctrlLCDScreen1.ContainsDot;
                    break;

                case _enOperation.Sub:
                    _Result -= _Number2;
                    ctrlLCDScreen1.LCDValue = _Result;
                    txtResult.Text = _Result.ToString();
                    btnDot.Enabled = !ctrlLCDScreen1.ContainsDot;
                    break;

                case _enOperation.Multipe:
                    _Result *= _Number2;
                    ctrlLCDScreen1.LCDValue = _Result;
                    txtResult.Text = _Result.ToString();
                    btnDot.Enabled = !ctrlLCDScreen1.ContainsDot;
                    break;

                case _enOperation.Divide:
                    _Result /= _Number2;
                    ctrlLCDScreen1.LCDValue = _Result;
                    txtResult.Text = _Result.ToString();
                    btnDot.Enabled = !ctrlLCDScreen1.ContainsDot;
                    break;
            }

        }
        private void frmTestLCD_Load(object sender, EventArgs e)
        {
            //ctrlLCDScreen1.LCDValue = -1.23456789E+123;
            ctrlLCDScreen1.LCDValue = 0;
            _sbInPut.Append("0000000000000000");
            _InputTimes = 0;
            ctrlLCDScreen1.LCDValue = 0;
            btnBack.Enabled = false;
            ctrlLCDScreen1.LCDValue = 0;
            _Operation = _enOperation.Start;
            DoOperations();
        }

        private void btnShowLCDValue_Click(object sender, EventArgs e)
        {
            txtLCDValue.Text = ctrlLCDScreen1.LCDValue.ToString();
        }

        private void ctrlLCDScreen1_Load(object sender, EventArgs e)
        {
            ctrlLCDScreen1.LCDValue = 0;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            _GetInPut("9");
            DoOperations();
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            _GetInPut("8");
            DoOperations();
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            _GetInPut("7");
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
        void BackSpace()
        {
            StringBuilder sbCurrentLCDValue = new StringBuilder(ctrlLCDScreen1.LCDValue.ToString());
            sbCurrentLCDValue.Remove(sbCurrentLCDValue.Length - 1, 1);
            ctrlLCDScreen1.LCDValue = Convert.ToDouble(sbCurrentLCDValue.ToString());
            _Number2 = ctrlLCDScreen1.LCDValue;
            txtNumber2.Text = _Number2.ToString();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            //_GetInPut("");
            //DoOperations();
            BackSpace();
            if (ctrlLCDScreen1.LCDValue == 0)
            {
                // _ActiveNumbers();
                btnBack.Enabled = false;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _SetOperation(_enOperation.Add);

            ctrlLCDScreen1.LCDValue = 0;
            _sbInPut.Clear();
            _sbInPut.Append("0000000000000000");
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
            ctrlLCDScreen1.LCDValue = 0;
            _sbInPut.Clear();
            _sbInPut.Append("0000000000000000");
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

            ctrlLCDScreen1.LCDValue = 0;
            _sbInPut.Clear();
            _sbInPut.Append("0000000000000000");
            _InputTimes = 0;
            _ActiveNumbers();
            if (_Result != 0)
            {
                _Number1 = _Result;
                _Result = 0;
            }
            DoOperations();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            _SetOperation(_enOperation.Divide);
            ctrlLCDScreen1.LCDValue = 0;
            _sbInPut.Clear();
            _sbInPut.Append("0000000000000000");
            _InputTimes = 0;
            _ActiveNumbers();
            if (_Result != 0)
            {
                _Number1 = _Result;
                _Result = 0;
            }
            DoOperations();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            _SetOperation(_enOperation.Clear);
            ctrlLCDScreen1.LCDValue = 0;
            
            _sbInPut.Clear();
            _sbInPut.Append("0000000000000000");
            _InputTimes = 0;
            _ActiveNumbers();
            _Operation = _enOperation.Clear;
            //_Operation = _enOperation.Start;
            DoOperations();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {

            _SetOperation(_enOperation.Equals);
            if (_LastOperation != _Operation)
                DoOperations();
            else
            {
                DoCalculation();
            }
           
            _sbInPut.Clear();

            _sbInPut.Append("0000000000000000");
            _InputTimes = 0;
            _ActiveNumbers();
            if (_Result != 0)
            {
                _PreviousNumber = _Number2;
                _Number1 = _Result;

            }
            //DoOperations();
        }
    }
}
