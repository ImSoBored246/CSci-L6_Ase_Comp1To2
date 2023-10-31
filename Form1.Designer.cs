namespace CSci_L6_Ase_Comp1To2
{
    partial class DrawProjForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_out = new TextBox();
            btn_syn = new Button();
            btn_exe = new Button();
            tb_code = new TextBox();
            btn_sav = new Button();
            btn_ope = new Button();
            btn_clr = new Button();
            btn_exeO = new Button();
            tb_olc = new TextBox();
            SuspendLayout();
            // 
            // tb_out
            // 
            tb_out.BackColor = Color.FromArgb(10, 10, 10);
            tb_out.ForeColor = SystemColors.ControlLight;
            tb_out.Location = new Point(751, 467);
            tb_out.Name = "tb_out";
            tb_out.PlaceholderText = "Output";
            tb_out.ReadOnly = true;
            tb_out.Size = new Size(426, 23);
            tb_out.TabIndex = 0;
            // 
            // btn_syn
            // 
            btn_syn.BackColor = Color.FromArgb(10, 10, 10);
            btn_syn.FlatStyle = FlatStyle.Popup;
            btn_syn.ForeColor = SystemColors.ControlLight;
            btn_syn.Location = new Point(18, 501);
            btn_syn.Name = "btn_syn";
            btn_syn.Size = new Size(99, 23);
            btn_syn.TabIndex = 1;
            btn_syn.Text = "Check Syntax";
            btn_syn.UseVisualStyleBackColor = false;
            btn_syn.Click += btn_syn_Click;
            // 
            // btn_exe
            // 
            btn_exe.BackColor = Color.FromArgb(10, 10, 10);
            btn_exe.FlatStyle = FlatStyle.Popup;
            btn_exe.ForeColor = SystemColors.ControlLight;
            btn_exe.Location = new Point(123, 501);
            btn_exe.Name = "btn_exe";
            btn_exe.Size = new Size(99, 23);
            btn_exe.TabIndex = 2;
            btn_exe.Text = "Execute";
            btn_exe.UseVisualStyleBackColor = false;
            btn_exe.Click += btn_exe_Click;
            // 
            // tb_code
            // 
            tb_code.AcceptsReturn = true;
            tb_code.AcceptsTab = true;
            tb_code.BackColor = Color.FromArgb(10, 10, 10);
            tb_code.ForeColor = SystemColors.ControlLight;
            tb_code.Location = new Point(19, 19);
            tb_code.Multiline = true;
            tb_code.Name = "tb_code";
            tb_code.PlaceholderText = "If you want to execute or save an entire program, use this box and click \"Execute\" or \"Save\"";
            tb_code.Size = new Size(726, 426);
            tb_code.TabIndex = 3;
            // 
            // btn_sav
            // 
            btn_sav.BackColor = Color.FromArgb(10, 10, 10);
            btn_sav.FlatStyle = FlatStyle.Popup;
            btn_sav.ForeColor = SystemColors.ControlLight;
            btn_sav.Location = new Point(359, 501);
            btn_sav.Name = "btn_sav";
            btn_sav.Size = new Size(99, 23);
            btn_sav.TabIndex = 4;
            btn_sav.Text = "Save";
            btn_sav.UseVisualStyleBackColor = false;
            btn_sav.Click += btn_sav_Click;
            // 
            // btn_ope
            // 
            btn_ope.BackColor = Color.FromArgb(10, 10, 10);
            btn_ope.FlatStyle = FlatStyle.Popup;
            btn_ope.ForeColor = SystemColors.ControlLight;
            btn_ope.Location = new Point(464, 501);
            btn_ope.Name = "btn_ope";
            btn_ope.Size = new Size(99, 23);
            btn_ope.TabIndex = 5;
            btn_ope.Text = "Open";
            btn_ope.UseVisualStyleBackColor = false;
            btn_ope.Click += btn_ope_Click;
            // 
            // btn_clr
            // 
            btn_clr.BackColor = Color.FromArgb(10, 10, 10);
            btn_clr.FlatStyle = FlatStyle.Popup;
            btn_clr.ForeColor = SystemColors.ControlLight;
            btn_clr.Location = new Point(569, 501);
            btn_clr.Name = "btn_clr";
            btn_clr.Size = new Size(99, 23);
            btn_clr.TabIndex = 7;
            btn_clr.Text = "Clear";
            btn_clr.UseVisualStyleBackColor = false;
            btn_clr.Click += btn_clr_Click;
            // 
            // btn_exeO
            // 
            btn_exeO.BackColor = Color.FromArgb(10, 10, 10);
            btn_exeO.FlatStyle = FlatStyle.Popup;
            btn_exeO.ForeColor = SystemColors.ControlLight;
            btn_exeO.Location = new Point(228, 501);
            btn_exeO.Name = "btn_exeO";
            btn_exeO.Size = new Size(125, 23);
            btn_exeO.TabIndex = 8;
            btn_exeO.Text = "Execute (One Line)";
            btn_exeO.UseVisualStyleBackColor = false;
            btn_exeO.Click += btn_exeO_Click;
            // 
            // tb_olc
            // 
            tb_olc.BackColor = Color.FromArgb(10, 10, 10);
            tb_olc.ForeColor = SystemColors.ControlLight;
            tb_olc.Location = new Point(18, 467);
            tb_olc.Name = "tb_olc";
            tb_olc.PlaceholderText = "If you want to execute a single line of code, type here and use the Execute (One Line) button";
            tb_olc.Size = new Size(727, 23);
            tb_olc.TabIndex = 9;
            // 
            // DrawProjForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 31, 31);
            ClientSize = new Size(1192, 540);
            Controls.Add(tb_olc);
            Controls.Add(btn_exeO);
            Controls.Add(btn_clr);
            Controls.Add(btn_ope);
            Controls.Add(btn_sav);
            Controls.Add(tb_code);
            Controls.Add(btn_exe);
            Controls.Add(btn_syn);
            Controls.Add(tb_out);
            ForeColor = SystemColors.ControlLight;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "DrawProjForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Drawing Project";
            Paint += Form1_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_out;
        private Button btn_syn;
        private Button btn_exe;
        private TextBox tb_code;
        private Button btn_sav;
        private Button btn_ope;
        private Button btn_clr;
        private Button btn_debug;
        private Button btn_exeO;
        private TextBox tb_olc;
    }
}