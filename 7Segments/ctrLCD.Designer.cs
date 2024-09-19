namespace _7Segments
{
    partial class ctrLCD
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.digitsColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ctrlHundreds = new _7Segments.ctrlSevenSegments();
            this.ctrlThousands = new _7Segments.ctrlSevenSegments();
            this.ctrlTensOfThousands = new _7Segments.ctrlSevenSegments();
            this.ctrlTens = new _7Segments.ctrlSevenSegments();
            this.ctrlTensOfMillions = new _7Segments.ctrlSevenSegments();
            this.ctrlOnes = new _7Segments.ctrlSevenSegments();
            this.ctrlHundredsOfThousands = new _7Segments.ctrlSevenSegments();
            this.ctrlMillions = new _7Segments.ctrlSevenSegments();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.digitsColorsToolStripMenuItem,
            this.screenColorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(328, 112);
            // 
            // digitsColorsToolStripMenuItem
            // 
            this.digitsColorsToolStripMenuItem.Name = "digitsColorsToolStripMenuItem";
            this.digitsColorsToolStripMenuItem.Size = new System.Drawing.Size(327, 54);
            this.digitsColorsToolStripMenuItem.Text = "&Digits Colors";
            this.digitsColorsToolStripMenuItem.Click += new System.EventHandler(this.digitsColorsToolStripMenuItem_Click);
            // 
            // screenColorToolStripMenuItem
            // 
            this.screenColorToolStripMenuItem.Name = "screenColorToolStripMenuItem";
            this.screenColorToolStripMenuItem.Size = new System.Drawing.Size(327, 54);
            this.screenColorToolStripMenuItem.Text = "&Screen Color";
            this.screenColorToolStripMenuItem.Click += new System.EventHandler(this.screenColorToolStripMenuItem_Click);
            // 
            // ctrlHundreds
            // 
            this.ctrlHundreds.BackGroundColor = System.Drawing.Color.Empty;
            this.ctrlHundreds.Digit = ((byte)(0));
            this.ctrlHundreds.DotExist = false;
            this.ctrlHundreds.Font = new System.Drawing.Font("Malgun Gothic", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlHundreds.FrontColor = System.Drawing.Color.Empty;
            this.ctrlHundreds.Location = new System.Drawing.Point(468, 13);
            this.ctrlHundreds.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ctrlHundreds.Name = "ctrlHundreds";
            this.ctrlHundreds.Size = new System.Drawing.Size(94, 136);
            this.ctrlHundreds.TabIndex = 5;
            // 
            // ctrlThousands
            // 
            this.ctrlThousands.BackGroundColor = System.Drawing.Color.Empty;
            this.ctrlThousands.Digit = ((byte)(0));
            this.ctrlThousands.DotExist = false;
            this.ctrlThousands.Font = new System.Drawing.Font("Malgun Gothic", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlThousands.FrontColor = System.Drawing.Color.Empty;
            this.ctrlThousands.Location = new System.Drawing.Point(380, 15);
            this.ctrlThousands.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ctrlThousands.Name = "ctrlThousands";
            this.ctrlThousands.Size = new System.Drawing.Size(98, 133);
            this.ctrlThousands.TabIndex = 4;
            // 
            // ctrlTensOfThousands
            // 
            this.ctrlTensOfThousands.BackGroundColor = System.Drawing.Color.Empty;
            this.ctrlTensOfThousands.Digit = ((byte)(0));
            this.ctrlTensOfThousands.DotExist = false;
            this.ctrlTensOfThousands.Font = new System.Drawing.Font("Malgun Gothic", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlTensOfThousands.FrontColor = System.Drawing.Color.Empty;
            this.ctrlTensOfThousands.Location = new System.Drawing.Point(291, 15);
            this.ctrlTensOfThousands.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlTensOfThousands.Name = "ctrlTensOfThousands";
            this.ctrlTensOfThousands.Size = new System.Drawing.Size(97, 132);
            this.ctrlTensOfThousands.TabIndex = 3;
            // 
            // ctrlTens
            // 
            this.ctrlTens.BackGroundColor = System.Drawing.Color.Empty;
            this.ctrlTens.Digit = ((byte)(0));
            this.ctrlTens.DotExist = false;
            this.ctrlTens.Font = new System.Drawing.Font("Malgun Gothic", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlTens.FrontColor = System.Drawing.Color.Empty;
            this.ctrlTens.Location = new System.Drawing.Point(559, 16);
            this.ctrlTens.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlTens.Name = "ctrlTens";
            this.ctrlTens.Size = new System.Drawing.Size(96, 130);
            this.ctrlTens.TabIndex = 6;
            // 
            // ctrlTensOfMillions
            // 
            this.ctrlTensOfMillions.BackGroundColor = System.Drawing.Color.Empty;
            this.ctrlTensOfMillions.Digit = ((byte)(0));
            this.ctrlTensOfMillions.DotExist = false;
            this.ctrlTensOfMillions.Font = new System.Drawing.Font("Malgun Gothic", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlTensOfMillions.FrontColor = System.Drawing.Color.Empty;
            this.ctrlTensOfMillions.Location = new System.Drawing.Point(26, 12);
            this.ctrlTensOfMillions.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlTensOfMillions.Name = "ctrlTensOfMillions";
            this.ctrlTensOfMillions.Size = new System.Drawing.Size(93, 138);
            this.ctrlTensOfMillions.TabIndex = 0;
            // 
            // ctrlOnes
            // 
            this.ctrlOnes.BackGroundColor = System.Drawing.Color.Empty;
            this.ctrlOnes.Digit = ((byte)(0));
            this.ctrlOnes.DotExist = false;
            this.ctrlOnes.Font = new System.Drawing.Font("Malgun Gothic", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlOnes.FrontColor = System.Drawing.Color.Empty;
            this.ctrlOnes.Location = new System.Drawing.Point(652, 14);
            this.ctrlOnes.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlOnes.Name = "ctrlOnes";
            this.ctrlOnes.Size = new System.Drawing.Size(87, 134);
            this.ctrlOnes.TabIndex = 7;
            // 
            // ctrlHundredsOfThousands
            // 
            this.ctrlHundredsOfThousands.BackGroundColor = System.Drawing.Color.Empty;
            this.ctrlHundredsOfThousands.Digit = ((byte)(0));
            this.ctrlHundredsOfThousands.DotExist = false;
            this.ctrlHundredsOfThousands.Font = new System.Drawing.Font("Malgun Gothic", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlHundredsOfThousands.FrontColor = System.Drawing.Color.Empty;
            this.ctrlHundredsOfThousands.Location = new System.Drawing.Point(203, 14);
            this.ctrlHundredsOfThousands.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlHundredsOfThousands.Name = "ctrlHundredsOfThousands";
            this.ctrlHundredsOfThousands.Size = new System.Drawing.Size(99, 135);
            this.ctrlHundredsOfThousands.TabIndex = 2;
            // 
            // ctrlMillions
            // 
            this.ctrlMillions.BackGroundColor = System.Drawing.Color.Empty;
            this.ctrlMillions.Digit = ((byte)(0));
            this.ctrlMillions.DotExist = false;
            this.ctrlMillions.Font = new System.Drawing.Font("Malgun Gothic", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlMillions.FrontColor = System.Drawing.Color.Empty;
            this.ctrlMillions.Location = new System.Drawing.Point(115, 15);
            this.ctrlMillions.Margin = new System.Windows.Forms.Padding(1);
            this.ctrlMillions.Name = "ctrlMillions";
            this.ctrlMillions.Size = new System.Drawing.Size(94, 133);
            this.ctrlMillions.TabIndex = 1;
            // 
            // ctrLCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(3F, 6F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.ctrlHundreds);
            this.Controls.Add(this.ctrlThousands);
            this.Controls.Add(this.ctrlTensOfThousands);
            this.Controls.Add(this.ctrlTens);
            this.Controls.Add(this.ctrlTensOfMillions);
            this.Controls.Add(this.ctrlOnes);
            this.Controls.Add(this.ctrlHundredsOfThousands);
            this.Controls.Add(this.ctrlMillions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "ctrLCD";
            this.Size = new System.Drawing.Size(788, 192);
            this.Load += new System.EventHandler(this.ctrLCD_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSevenSegments ctrlTensOfMillions;
        private ctrlSevenSegments ctrlMillions;
        private ctrlSevenSegments ctrlTensOfThousands;
        private ctrlSevenSegments ctrlHundredsOfThousands;
        private ctrlSevenSegments ctrlThousands;
        private ctrlSevenSegments ctrlHundreds;
        private ctrlSevenSegments ctrlTens;
        private ctrlSevenSegments ctrlOnes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem digitsColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
