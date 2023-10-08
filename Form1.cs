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
        tb_out.Text = CommandParser.CheckSyntax(tb_code.Text);

        }

        private void btn_exe_Click(object sender, EventArgs e)
        {
            ///<summary>Calls CommandParser.Execute. If an exception is returned, will display it to the output box.</summary>
        }

        private void btn_ope_Click(object sender, EventArgs e)
        {
            ///<summary>Calls CommandParser.OpenFile. Opens a file from the user's computer, and inputs it into the tb_code.Text.</summary>
        }

        private void btn_sav_Click(object sender, EventArgs e)
        {
            ///<summary>Calls CommandParser.SaveFile. Saves a file from the tb_code.Text into the user's computer.</summary>
        }
    }
}