using System.Drawing;

namespace CSci_L6_Ase_Comp1To2
{
    public partial class DrawProjForm : Form
    {
        public string curCmd { get; set; }
        private List<ObjectShape> activeShapes = new List<ObjectShape>();
        private List<string> activeTypes = new List<string>();
        public DrawProjForm()
        {
            curCmd = "x";
            InitializeComponent();
        }

        public void clearActiveShapes()
        {
            activeShapes.Clear();
            activeTypes.Clear();
        }

        public void addShape(ObjectShape o, string t)
        {
            activeShapes.Add(o);
            activeTypes.Add(t);
        }

        private void btn_syn_Click(object sender, EventArgs e)
        {
            ///<summary>Calls CommandParser.CheckSyntax to check for errors, and return them in the textbox.</summary>
            ///
            try
            {
                if(CommandParser.CheckSyntax(tb_code.Text)) { tb_out.Text = "Syntax OK!"; }
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
                tb_out.Text = CommandParser.Execute(tb_code.Text, this);
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
        private void btn_exeO_Click(object sender, EventArgs e)
        {
            try
            {
                tb_out.Text = CommandParser.Execute(tb_olc.Text, this);
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string[] command = curCmd.Split("/");
            if (command[0] == "c")
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(255, int.Parse(command[6]), int.Parse(command[7]), int.Parse(command[8])));
                ObjectShape shape = ObjectDrawer.DrawObject(int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), int.Parse(command[3]), int.Parse(command[4]), b, bool.Parse(command[5]));
                addShape(shape, "c");
            }
            else if (command[0] == "r")
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(255, int.Parse(command[7]), int.Parse(command[8]), int.Parse(command[9])));
                ObjectShape shape = ObjectDrawer.DrawObject(int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), int.Parse(command[4]), int.Parse(command[5]), b, bool.Parse(command[6]));
                addShape(shape, "r");
            }
            else if (command[0] == "l")
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(255, int.Parse(command[7]), int.Parse(command[8]), int.Parse(command[9])));
                ObjectShape shape = ObjectDrawer.DrawObject(int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), int.Parse(command[4]), int.Parse(command[5]), b, bool.Parse(command[6]));
                addShape(shape, "l");
            }
            // draw all shapes
            for (int i = 0; i < activeShapes.Count; i++)
            {
                if (activeTypes[i] == "c")
                {
                    ObjectDrawer.DrawCircle(activeShapes[i], e);
                }
                else if (activeTypes[i] == "r")
                {
                    ObjectDrawer.DrawRectangle(activeShapes[i], e);
                }
                else if (activeTypes[i] == "l")
                {
                    // do draw line magic
                }
            }
            curCmd = "x";
        }

    }
}