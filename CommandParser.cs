﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSci_L6_Ase_Comp1To2
{
    internal class CommandParser
    {
        ///<summary>A class of tools dedicated to checking syntax, code execution, save/load and error handling.</summary>

        public static bool CheckSyntax(string code)
        {
            ///<summary>Code to check for errors before run time. Throws exceptions where applicable.</summary>
            ///<exception cref="ArgumentNullException">Thrown if a null value is somehow passed to the method.</exception>
            ///<exception cref="ArgumentException">Thrown when no code or invalid parameter values are passed to the method</exception>
            ///<exception cref="FormatException">Thrown when invalid variable types are passed to the method (ex. 'circle 10.5')</exception>
            if (code == null) { throw new ArgumentNullException("Null received! That shouldn't have happened! Try restarting the program!"); }
            else if (code == "") { throw new ArgumentException("No code!"); }
            int iter = 0;
            string[] runtime_exec_code = code.Split("\n");
            runtime_exec_code = FormatCode(runtime_exec_code);
            while (runtime_exec_code.Length > iter)
            {
                if (runtime_exec_code[iter].Substring(0, 5) == "clear")
                {
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 5) == "reset")
                {
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 4) == "fill")
                {
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 6) == "moveto")
                {
                    int x = 0; int y = 0;
                    try { x = int.Parse(runtime_exec_code[iter].Split(" ")[1]); y = int.Parse(runtime_exec_code[iter].Split(" ")[2]); }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR: MoveTo command expects 2x integer args"); }
                    if (x < 10 || y < 10 || x > 476 || y > 445) { throw new ArgumentException($"Line {iter + 1} ERR: Canvas size is (10,10) to (476, 445)."); }
                    iter++; continue;

                }
                else if (runtime_exec_code[iter].Substring(0, 6) == "circle")
                {
                    int r = 0;
                    try { r = int.Parse(runtime_exec_code[iter].Split(" ")[1]); } 
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR: Circle command expects integer arg"); }
                    if (r <= 0) { throw new ArgumentException($"Line {iter + 1} ERR: Circle radius too small."); }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 4) == "rect" || runtime_exec_code[iter].Substring(0, 9) == "rectangle")
                {
                    int x = 0; int y = 0;
                    try { x = int.Parse(runtime_exec_code[iter].Split(" ")[1]); y = int.Parse(runtime_exec_code[iter].Split(" ")[2]); }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR: Rectangle command expects 2x integer args"); }
                    if (x <= 0 || y <= 0) { throw new ArgumentException($"Line {iter + 1} ERR: Side length too small."); }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 6) == "drawto")
                {
                    int x = 0; int y = 0;
                    try { x = int.Parse(runtime_exec_code[iter].Split(" ")[1]); y = int.Parse(runtime_exec_code[iter].Split(" ")[2]); }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR: DrawTo command expects 2x integer args"); }
                    if (x < 10 || y < 10 || x > 476 || y > 445) { throw new ArgumentException($"Line {iter + 1} ERR: Canvas size is (10,10) to (476, 445)."); }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 8) == "triangle")
                {
                    int r = 0;
                    try { r = int.Parse(runtime_exec_code[iter].Split(" ")[1]); } 
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR: Triangle command expects integer arg"); }
                    if (r <= 0) { throw new ArgumentException($"Line {iter + 1} ERR: Circle radius too small."); }
                    iter++; continue;
                }
                else
                {
                    throw new ArgumentException($"{runtime_exec_code[iter]} is an invalid command (line {iter + 1})");
                }
            }


            return true;
        }

        public static string Execute(string code, DrawProjForm form)
        {
            ///<summary>Executes the code in the code box. Returns code's text output.</summary>
            ///<exception cref="ArgumentNullException">Thrown if no code is passed to the method.</exception>
            ///
            int entityCount = 0;
            int[] init_loc = { 10, 10 };
            int[] cursor_loc = { 10, 10 };
            string outBuffer = "";
            SolidBrush br = new SolidBrush(Color.White);
            bool fill = false;
            int iter = 0;
            CheckSyntax(code);
            string[] runtime_exec_code = code.Split("\n");
            runtime_exec_code = FormatCode(runtime_exec_code);
            while (runtime_exec_code.Length > iter)
            {
                if (runtime_exec_code[iter].Substring(0, 5) == "clear")
                {
                    form.clearActiveShapes();
                } else if (runtime_exec_code[iter].Substring(0, 5) == "reset")
                {
                    cursor_loc = init_loc;
                } else if (runtime_exec_code[iter].Substring(0, 4) == "fill")
                {
                    fill = !fill;
                } else if (runtime_exec_code[iter].Substring(0, 6) == "moveto")
                {
                    string[] vals = runtime_exec_code[iter].Split(" ");
                    cursor_loc = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };

                } else if (runtime_exec_code[iter].Substring(0, 6) == "circle")
                {
                    int size = int.Parse(runtime_exec_code[iter].Split(" ")[1]);
                    form.curCmd = "c/" + cursor_loc[0] + "/" + cursor_loc[1] + "/" + size + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                } else if (runtime_exec_code[iter].Substring(0, 4) == "rect" || runtime_exec_code[iter].Substring(0, 9) == "rectangle")
                {
                    string[] vals = runtime_exec_code[iter].Split(" ");
                    int[] size = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };
                    form.curCmd = "r/" + cursor_loc[0] + "/" + cursor_loc[1] + "/" + size[0] + "/" + size[1] + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                } else if (runtime_exec_code[iter].Substring(0, 6) == "drawto") 
                {
                    //todo
                }
                else if (runtime_exec_code[iter].Substring(0, 8) == "triangle")
                {
                    int size = int.Parse(runtime_exec_code[iter].Split(" ")[1]);
                    form.curCmd = "t/" + cursor_loc[0] + "/" + cursor_loc[1] + "/" + size + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                }
                else
                {
                    throw new ArgumentException($"ERR! {runtime_exec_code[iter]} is an invalid command (line {iter + 1})");
                }
                iter++;
                form.Refresh();
        }
            return outBuffer;
        }

        private static string[] FormatCode(string[] program)
        {
            ///<summary>Removes unneeded whitespace from program and convert to lowercase, to allow this.Execute(..) to recognise it. This method should not raise any exceptions.</summary>
            ///
            for (int x = 0; x < program.Length; x++)
            {
                program[x] = program[x].Trim().ToLower();
            }
            return program;
        }

        public static string OpenFile()
        {
            ///<summary>Executes the code in the code box. Returns code's text output.</summary>
            ///<exception cref="IOException">Thrown when loading fails for any reason.</exception>
            FileDialog d = new OpenFileDialog();
            string x = "";
            d.Filter = "Drawing Program Code (*.dpc)|*.dpc";
            try
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(d.FileName);
                    x = sr.ReadToEnd();
                    sr.Close();
                }
                else { throw new Exception("File Dialog was aborted. Your file didn't open!"); }
                return x;
            }
            catch (Exception ex)
            {
                throw new IOException($"File Dialog failure! Details:\n{ex.Message}");
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
            try
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(d.FileName);
                    sw.Write(code);
                    sw.Close();
                }
                else { throw new Exception("File Dialog aborted! Your file has NOT saved!"); }
            }
            catch (Exception ex)
            {
                throw new IOException($"File Dialog failure! Details: \n{ex.Message}");
            }
        }
    }
}
