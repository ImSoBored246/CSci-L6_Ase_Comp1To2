namespace CSci_L6_Ase_Comp1To2
{
    partial class Form1
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
            btn_debug = new Button();
            SuspendLayout();
            // 
            // tb_out
            // 
            tb_out.Location = new Point(19, 467);
            tb_out.Name = "tb_out";
            tb_out.PlaceholderText = "Output";
            tb_out.ReadOnly = true;
            tb_out.Size = new Size(1158, 23);
            tb_out.TabIndex = 0;
            // 
            // btn_syn
            // 
            btn_syn.Location = new Point(18, 501);
            btn_syn.Name = "btn_syn";
            btn_syn.Size = new Size(99, 23);
            btn_syn.TabIndex = 1;
            btn_syn.Text = "Check Syntax";
            btn_syn.UseVisualStyleBackColor = true;
            btn_syn.Click += btn_syn_Click;
            // 
            // btn_exe
            // 
            btn_exe.Location = new Point(123, 501);
            btn_exe.Name = "btn_exe";
            btn_exe.Size = new Size(99, 23);
            btn_exe.TabIndex = 2;
            btn_exe.Text = "Execute";
            btn_exe.UseVisualStyleBackColor = true;
            btn_exe.Click += btn_exe_Click;
            // 
            // tb_code
            // 
            tb_code.AcceptsReturn = true;
            tb_code.AcceptsTab = true;
            tb_code.Location = new Point(19, 19);
            tb_code.Multiline = true;
            tb_code.Name = "tb_code";
            tb_code.PlaceholderText = "Code goes here";
            tb_code.Size = new Size(726, 426);
            tb_code.TabIndex = 3;
            // 
            // btn_sav
            // 
            btn_sav.Location = new Point(333, 501);
            btn_sav.Name = "btn_sav";
            btn_sav.Size = new Size(99, 23);
            btn_sav.TabIndex = 4;
            btn_sav.Text = "Save";
            btn_sav.UseVisualStyleBackColor = true;
            btn_sav.Click += btn_sav_Click;
            // 
            // btn_ope
            // 
            btn_ope.Location = new Point(228, 501);
            btn_ope.Name = "btn_ope";
            btn_ope.Size = new Size(99, 23);
            btn_ope.TabIndex = 5;
            btn_ope.Text = "Open";
            btn_ope.UseVisualStyleBackColor = true;
            btn_ope.Click += btn_ope_Click;
            // 
            // btn_clr
            // 
            btn_clr.Location = new Point(438, 501);
            btn_clr.Name = "btn_clr";
            btn_clr.Size = new Size(99, 23);
            btn_clr.TabIndex = 7;
            btn_clr.Text = "Clear";
            btn_clr.UseVisualStyleBackColor = true;
            btn_clr.Click += btn_clr_Click;
            // 
            // btn_debug
            // 
            btn_debug.Location = new Point(543, 501);
            btn_debug.Name = "btn_debug";
            btn_debug.Size = new Size(99, 23);
            btn_debug.TabIndex = 8;
            btn_debug.Text = "Debug - Circle";
            btn_debug.UseVisualStyleBackColor = true;
            btn_debug.Click += btn_debug_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 540);
            Controls.Add(btn_debug);
            Controls.Add(btn_clr);
            Controls.Add(btn_ope);
            Controls.Add(btn_sav);
            Controls.Add(tb_code);
            Controls.Add(btn_exe);
            Controls.Add(btn_syn);
            Controls.Add(tb_out);
            Name = "Form1";
            Text = "Component TORENAME";
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
    }
}