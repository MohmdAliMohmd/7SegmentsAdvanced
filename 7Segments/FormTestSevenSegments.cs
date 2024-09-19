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
    public partial class FormTestSevenSegments : Form
    {
        public FormTestSevenSegments()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            colorDialog1.AnyColor = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                ctrlSevenSegments2.BackGroundColor = colorDialog1.Color;
        }

        private void digitColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            colorDialog1.AnyColor = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                ctrlSevenSegments2.FrontColor = colorDialog1.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 0;
            ctrlSevenSegmentsv21.Digit = '0';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 1;
            ctrlSevenSegmentsv21.Digit = '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 2;
            ctrlSevenSegmentsv21.Digit = '2';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 3;
            ctrlSevenSegmentsv21.Digit = '3';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 4;
            ctrlSevenSegmentsv21.Digit = '4';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 5;
            ctrlSevenSegmentsv21.Digit = '5';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 6;
            ctrlSevenSegmentsv21.Digit = '6';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 7;
            ctrlSevenSegmentsv21.Digit = '7';
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 8;
            ctrlSevenSegmentsv21.Digit = '8';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ctrlSevenSegments2.Digit = 9;
            ctrlSevenSegmentsv21.Digit = '9';
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (ctrlSevenSegments2.DotExist)
                ctrlSevenSegments2.DotExist = false;
            else
                ctrlSevenSegments2.DotExist = true;

            if (ctrlSevenSegmentsv21.DotExist)
                ctrlSevenSegmentsv21.DotExist = false;
            else
                ctrlSevenSegmentsv21.DotExist = true;
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            ctrlSevenSegmentsv21.Digit = 'E';
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            ctrlSevenSegmentsv21.Digit = '-';
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            ctrlSevenSegmentsv21.Digit = '+';
        }
    }
}
