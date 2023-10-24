﻿using System;
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

        public static string Execute(string code, Form1 form)
        {
            ///<summary>Executes the code in the code box. Returns code's text output.</summary>
            ///<exception cref="ArgumentNullException">Thrown if no code is passed to the method.</exception>
            ///
            int entityCount = 0;
            int[] init_loc = { 10, 10 };
            int[] cursor_loc = { 10, 10 };
            string outBuffer = "";
            bool fill = false;
            int iter = 0;
            if (code == null) { throw new ArgumentNullException("No code!"); }
            string[] runtime_exec_code = code.Split("\n");
            while (runtime_exec_code.Length > iter)
            {
                if (runtime_exec_code[iter].Substring(0, 5) == "clear")
                {
                    DrawFunctions.ClearAllPictureBoxes(entityCount, ref form);
                } else if (runtime_exec_code[iter].Substring(0, 5) == "reset")
                {
                    cursor_loc = init_loc;
                } else if (runtime_exec_code[iter].Substring(0, 4) == "fill")
                {
                    fill = !fill;
                } else if (runtime_exec_code[iter].Substring(0, 6) == "moveTo")
                {
                    string[] vals = runtime_exec_code[iter].Split(" ");
                    cursor_loc = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };

                } else if (runtime_exec_code[iter].Substring(0, 6) == "circle")
                {
                    int size = int.Parse(runtime_exec_code[iter].Split(" ")[1]);
                    ObjectDrawer.DrawCircle(ObjectDrawer.DrawObject(cursor_loc[0], cursor_loc[1], size, size, entityCount), fill);
                } else if (runtime_exec_code[iter].Substring(0, 4) == "rect")
                {
                    string[] vals = runtime_exec_code[iter].Split(" ");
                    int[] size = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };
                    ObjectDrawer.DrawRectangle(ObjectDrawer.DrawObject(cursor_loc[0], cursor_loc[1], size[0], size[1], entityCount), fill);
                } else if (runtime_exec_code[iter].Substring(0, 1) == "moveTo") // todo
                {

                }
                iter++;
            }
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
                StreamReader sr = new StreamReader(d.FileName);
                string x = sr.ReadToEnd();
                sr.Close();
                return x;
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
                StreamWriter sw = new StreamWriter(d.FileName);
                sw.Write(code);
                sw.Close();
            }
            else
            {
                throw new IOException("File Dialog failure!");
            }
        }
    }
}
