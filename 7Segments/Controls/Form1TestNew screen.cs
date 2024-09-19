using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _7Segments.Controls
{
    public partial class Form1TestNew_screen : Form
    {
        public Form1TestNew_screen()
        {
            InitializeComponent();
        }
        byte digits = 0;
        private void txtInPut_TextChanged(object sender, EventArgs e)
        {
            digits++;
            lblInPutCount.Text = digits.ToString();
          
        }

        byte NumberDigitsCount(double numWithOutDots)
        {
            byte Count = 0;
            double number = numWithOutDots;

            while (number> 1)
            {
                number = number / 10;
                Count++;
                if (number < 1)
                    break;
            }
            return Count;
        }
        private void btnInPut_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Convert.ToDouble(txtInPut.Text).ToString();
            ctrlLCDScreen1.LCDValue = Convert.ToDouble(txtInPut.Text);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblNumberDigitsCount.Text = NumberDigitsCount(Convert.ToDouble(txtInPut.Text)).ToString();// NumberDigitsCount(Convert.ToDouble(txtInPut.Text)).ToString();
            //lblInPutCount.Text = Convert.ToString(Convert.ToDouble(txtInPut.Text) % 10);
        }

        private void Form1TestNew_screen_Load(object sender, EventArgs e)
        {
            double  digit = Math.Pow(10, -11);
            txtNumToCompare.Text = digit.ToString();
        }
    }
}
