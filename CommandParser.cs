using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSci_L6_Ase_Comp1To2
{
    internal class CommandParser
    {
        ///<summary>A class of tools dedicated to checking syntax, code execution, save/load and error handling.</summary>
        
        public static string CheckSyntax(string code)
        {
            ///<summary>Code to check for errors before run time. Throws exceptions where applicable.</summary>
            ///<exception cref="ArgumentNullException">Thrown if no code is passed to the method.</exception>
            if (code == null) { throw new ArgumentNullException("No code!"); }
            return "Syntax OK!";
        }

        public static string Execute(string code)
        {
            ///<summary>Executes the code in the code box. Returns code's text output.</summary>
            ///<exception cref="ArgumentNullException">Thrown if no code is passed to the method.</exception>
            string outBuffer = "";
            if (code == null) { throw new ArgumentNullException("No code!"); }
            return outBuffer;
        }

        public static string OpenFile()
        {
            ///<summary>Executes the code in the code box. Returns code's text output.</summary>
            ///<exception cref="IOException">Thrown when loading fails for any reason.</exception>
            FileDialog d = new OpenFileDialog();
            d.Filter = "Drawing Program Code (*.dpc)|*.dpc";
        
            if (d.ShowDialog() == DialogResult.OK)
            {
                return new StreamReader(d.FileName).ReadToEnd();
            }
            else
        {
        throw new IOException("File Dialog failure!");
        }
        }

        public static void SaveFile(string code)
        {
        ///<summary>Saves current code to external text file.</summary>
        ///<exception cref="ArgumentNullException">Thrown if no code is passed to the method.</exception>
        ///<exception cref="IOException">Thrown when saving fails for any reason.</exception>
        if (code == null) { throw new ArgumentNullException("No code!"); }
        FileDialog d = new SaveFileDialog();
        d.Filter = "Drawing Program Code (*.dpc)|*.dpc";

        if (d.ShowDialog() == DialogResult.OK)
        {
        new StreamWriter(d.FileName).Write(code);
        }
        else
        {
        throw new IOException("File Dialog failure!");
        }
        }
    }
}
