namespace CSci_L6_Ase_Comp1To2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_syn_Click(object sender, EventArgs e)
        {
            ///<summary>Calls CommandParser.CheckSyntax to check for errors, and return them in the textbox.</summary>
            ///
            try
            {
                tb_out.Text = CommandParser.CheckSyntax(tb_code.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void btn_exe_Click(object sender, EventArgs e)
        {
            ///<summary>Calls CommandParser.Execute. If an exception is returned, will display it to the output box.</summary>
            ///
            try
            {
                tb_out.Text = CommandParser.Execute(tb_code.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btn_ope_Click(object sender, EventArgs e)
        {
            ///<summary>Calls CommandParser.OpenFile. Opens a file from the user's computer, and inputs it into the tb_code.Text.</summary>
            ///
            try
            {
                tb_code.Text = CommandParser.OpenFile();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btn_sav_Click(object sender, EventArgs e)
        {
            ///<summary>Calls CommandParser.SaveFile. Saves a file from the tb_code.Text into the user's computer.</summary>
            ///
            try
            {
                CommandParser.SaveFile(tb_code.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            ///<summary>Removes all text from tb_code and tb_out.</summary>
            ///
            tb_out.Text = ""; tb_code.Text = "";
        }
    }
}