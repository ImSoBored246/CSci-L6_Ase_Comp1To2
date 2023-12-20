using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSci_L6_Ase_Comp1To2
{
    public class CommandParser
    {
        ///<summary>A class of tools dedicated to checking syntax, code execution, save/load and error handling.</summary>

        public static bool CheckSyntax(string code)
        {
            ///<summary>Code to check for errors before run time. Throws exceptions where applicable.</summary>
            ///<exception cref="ArgumentNullException">Thrown if a null value is somehow passed to the method.</exception>
            ///<exception cref="ArgumentException">Thrown when no code or invalid parameter values are passed to the method</exception>
            ///<exception cref="FormatException">Thrown when invalid variable types are passed to the method (ex. 'circle 10.5')</exception>
            if (code == null) { throw new ArgumentNullException("ERR! Null exception. This shouldn't have happened..."); } // to be frank, you shouldn't be getting a null exception during regular use!
            string[] runtime_exec_code = code.Split("\n");                                                                 // this is just a preventative thing in case I make a mistake
            runtime_exec_code = FormatCode(runtime_exec_code);
            if (code == "") { throw new ArgumentException("ERR! No code!"); }
            int iter = 0;
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
                    try
                    {
                        if (runtime_exec_code[iter].Split(" ").Length == 2)
                        {
                            if (!(runtime_exec_code[iter].Split(" ")[1] == "on" || runtime_exec_code[iter].Split(" ")[1] == "off")) { throw new FormatException(); }
                        }
                        else { throw new FormatException(); }
                    }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR! Fill command expects 'on' or 'off' as second argument!"); }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 6) == "moveto")
                {
                    int x = 0; int y = 0;
                    try
                    {
                        if (runtime_exec_code[iter].Split(" ").Length == 3)
                        {
                            x = int.Parse(runtime_exec_code[iter].Split(" ")[1]); y = int.Parse(runtime_exec_code[iter].Split(" ")[2]);
                        }
                        else { throw new FormatException(); }
                    }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR! MoveTo command expects 2x integer args"); }
                    if (x < 10 || y < 10 || x > 476 || y > 445) { throw new ArgumentException($"Line {iter + 1} ERR! Canvas size is (10,10) to (476, 445)."); }
                    iter++; continue;

                }
                else if (runtime_exec_code[iter].Substring(0, 6) == "circle")
                {
                    int r = 0;
                    try
                    {
                        if (runtime_exec_code[iter].Split(" ").Length == 2) { r = int.Parse(runtime_exec_code[iter].Split(" ")[1]); }
                        else { throw new FormatException(); }
                    }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR! Circle command expects integer arg"); }
                    if (r <= 0) { throw new ArgumentException($"Line {iter + 1} ERR! Circle radius too small."); }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 4) == "rect" || runtime_exec_code[iter].Substring(0, 9) == "rectangle")
                {
                    int x = 0; int y = 0;
                    try
                    {
                        if (runtime_exec_code[iter].Split(" ").Length == 3)
                        {
                            x = int.Parse(runtime_exec_code[iter].Split(" ")[1]); y = int.Parse(runtime_exec_code[iter].Split(" ")[2]);
                        }
                        else { throw new FormatException(); }
                    }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR! Rectangle command expects 2x integer args"); }
                    if (x <= 0 || y <= 0) { throw new ArgumentException($"Line {iter + 1} ERR! Side length too small."); }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 6) == "drawto")
                {
                    int x = 0; int y = 0;
                    try
                    {
                        if (runtime_exec_code[iter].Split(" ").Length == 3)
                        {
                            x = int.Parse(runtime_exec_code[iter].Split(" ")[1]); y = int.Parse(runtime_exec_code[iter].Split(" ")[2]);
                        }
                        else { throw new FormatException(); }
                    }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR! DrawTo command expects 2x integer args"); }
                    if (x < 10 || y < 10 || x > 476 || y > 445) { throw new ArgumentException($"Line {iter + 1} ERR! Canvas size is (10,10) to (476, 445)."); }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 8) == "triangle")
                {
                    int x = 0; int y = 0;
                    try
                    {
                        if (runtime_exec_code[iter].Split(" ").Length == 3)
                        {
                            x = int.Parse(runtime_exec_code[iter].Split(" ")[1]); y = int.Parse(runtime_exec_code[iter].Split(" ")[2]);
                        }
                        else { throw new FormatException(); }
                    }
                    catch (FormatException) { throw new FormatException($"Line {iter + 1} ERR! Triangle command expects 2x integer args"); }
                    if (x <= 0 || y <= 0) { throw new ArgumentException($"Line {iter + 1} ERR! Side length too small."); }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Substring(0, 3) == "pen")
                {
                    string[] col = runtime_exec_code[iter].Split(" ");
                    if (!(col.Length == 2 || col.Length == 4)) { throw new ArgumentException($"Line {iter + 1} ERR! Pen colour needs one word or three integers"); }
                    else
                    {
                        try { int.Parse(col[1]); int.Parse(col[2]); int.Parse(col[3]); } catch (FormatException) {
                            if (col[1] != "red" && col[1] != "green" && col[1] != "blue" && col[1] != "white")
                            { throw new ArgumentException($"Line {iter + 1} ERR! Invalid colour chosen"); }
                        }
                    }
                    iter++; continue;
                }
                else if (runtime_exec_code[iter].Split("=").Length == 2)
                {

                }
                else
                {
                    throw new ArgumentException($"Line {iter + 1} ERR! \"{runtime_exec_code[iter]}\" is an invalid command");
                }
            }
            return true;
        }

        public static string Execute(string code, DrawProjForm form)
        {
            ///<summary>Executes the code in the code box. Returns code's text output. This method should be incapable of throwing exceptions, as they are handled in CheckSyntax(..).</summary>
            ///
            int entityCount = 0;
            int[] init_loc = { 10, 10 };
            string outBuffer = "";
            SolidBrush br = new SolidBrush(Color.White);
            bool fill = false;
            int iter = 0;
            List<KeyValuePair<string, int>> usrVars = new List<KeyValuePair<string, int>>();
            if (CheckSyntax(code))
            {
                string[] runtime_exec_code = code.Split("\n");
                runtime_exec_code = FormatCode(runtime_exec_code);
                while (runtime_exec_code.Length > iter)
                {
                    if (runtime_exec_code[iter].Substring(0, 5) == "clear")
                    {
                        form.clearActiveShapes();
                    }
                    else if (runtime_exec_code[iter].Substring(0, 5) == "reset")
                    {
                        form.coords = init_loc;
                    }
                    else if (runtime_exec_code[iter].Substring(0, 4) == "fill")
                    {
                        if (runtime_exec_code[iter].Split(" ")[1] == "on") { fill = true; }
                        else { fill = false; }
                    }
                    else if (runtime_exec_code[iter].Substring(0, 6) == "moveto")
                    {
                        string[] vals = runtime_exec_code[iter].Split(" ");
                        form.coords = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };

                    }
                    else if (runtime_exec_code[iter].Substring(0, 6) == "circle")
                    {
                        int size = int.Parse(runtime_exec_code[iter].Split(" ")[1]);
                        form.curCmd = "c/" + form.coords[0] + "/" + form.coords[1] + "/" + size + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                    }
                    else if (runtime_exec_code[iter].Substring(0, 4) == "rect" || runtime_exec_code[iter].Substring(0, 9) == "rectangle")
                    {
                        string[] vals = runtime_exec_code[iter].Split(" ");
                        int[] size = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };
                        form.curCmd = "r/" + form.coords[0] + "/" + form.coords[1] + "/" + size[0] + "/" + size[1] + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                    }
                    else if (runtime_exec_code[iter].Substring(0, 6) == "drawto")
                    {
                        string[] vals = runtime_exec_code[iter].Split(" ");
                        int[] size = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };
                        form.curCmd = "l/" + form.coords[0] + "/" + form.coords[1] + "/" + size[0] + "/" + size[1] + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                    }
                    else if (runtime_exec_code[iter].Substring(0, 8) == "triangle")
                    {
                        string[] vals = runtime_exec_code[iter].Split(" ");
                        int[] size = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };
                        form.curCmd = "t/" + form.coords[0] + "/" + form.coords[1] + "/" + size[0] + "/" + size[1] + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                    }
                    else if (runtime_exec_code[iter].Substring(0, 3) == "pen")
                    {
                        string[] col = runtime_exec_code[iter].Split(" ");
                        if (runtime_exec_code[iter].Split(" ").Length == 2)
                        {
                            if (col[1] == "red") { br.Color = Color.FromArgb(255, 255, 0, 0); }
                            else if (col[1] == "green") { br.Color = Color.FromArgb(255, 0, 255, 0); }
                            else if (col[1] == "blue") { br.Color = Color.FromArgb(255, 0, 0, 255); }
                            else if (col[1] == "white") { br.Color = Color.FromArgb(255, 255, 255, 255); }
                        } else
                        {
                            br.Color = Color.FromArgb(255, int.Parse(col[1]), int.Parse(col[2]), int.Parse(col[3]));
                        }
                    }
                    else if (runtime_exec_code[iter].Split("=").Length == 2)
                    {
                        string[] assign = runtime_exec_code[iter].Split("=");
                        assign[1] = ReplaceVarsWithVals(assign[1], usrVars);
                        KeyValuePair<string, int> tmp = SearchItem_KVP(usrVars, assign[0]);
                        if (tmp.Key != "PL") {
                            usrVars.Remove(tmp);
                        }
                        int val = SolveMathEquations(assign[1]);
                        usrVars.Add(new KeyValuePair<string, int>(assign[0],val));

                    }
                    else
                    {
                        throw new ArgumentException($"Line {iter + 1} ERR! \"{runtime_exec_code[iter]}\" is an invalid command");
                    }
                    iter++;
                    form.Refresh();
                }
            }
            return outBuffer;
        }

        public static string ReplaceVarsWithVals(string line, List<KeyValuePair<string, int>> values)
        {
            for (int it = 0; it < values.Count; it++)
            {
                line = line.Replace(values[it].Key, values[it].Value.ToString());
            }
            return line;
        }

        internal static KeyValuePair<string, int> SearchItem_KVP(List<KeyValuePair<string, int>> v, string findable)
        {
            bool hit = false;
            KeyValuePair<string,int> rV = new KeyValuePair<string, int>("PL", 0);
            if (v.Count == 0) { return rV; }
            foreach (var item in v)
            {
                if (item.Key == findable && !hit) { hit = true; rV = item; }
                else if (hit) { throw new ArgumentException("Variable exists more than once!"); }
            }
            return rV;
        }

        internal static int SolveMathEquations(string equation)
        {
            ///<summary>Solves a string equation, returns the value. Supports [+, -, /, *] operators, with left-to-right order.</summary>
            ///
            float result = 0;
            char[] operators = new char[] { '/', '*', '+', '-' };
            equation = equation.Trim();
            try { 
                foreach (var item in equation.Split('/','*','-','+',' '))
                {
                    float.Parse(item);
                }
            } catch { throw new FormatException($"Invalid equation: {equation}"); }
            List<float> variables = new List<float>();
            foreach (var item in equation.Split('/', '*', '-', '+')) { variables.Add(float.Parse(item)); }
            result = variables[0];
            int x = 0;
            for (int i = 0; i < equation.Length; i++)
            {
                if (operators.Contains(equation[i]))
                {
                    x += 1;
                    if (equation[i] == '+')
                    {
                        result += variables[x];
                    } else if (equation[i] == '-')
                    {
                        result -= variables[x];
                    } else if (equation[i] == '/')
                    {
                        result /= variables[x];
                    } else if (equation[i] == '*')
                    {
                        result *= variables[x];
                    }
                }
            }
            return (int)result;
        }

        public static string[] FormatCode(string[] program)
        {
            ///<summary>Removes unneeded whitespace from program and convert to lowercase, to allow this.Execute(..) to recognise it. This method should not raise any exceptions.</summary>
            ///
            List<string> outBuffer = new List<string>();
            for (int x = 0; x < program.Length; x++)
            {
                program[x] = program[x].Trim().ToLower();
                if (!string.IsNullOrEmpty(program[x]))
                {
                    string[] tempString = program[x].Split(" ");
                    tempString[0] = tempString[0] + "________________";
                    program[x] = "";
                    for (int y = 0; y < tempString.Length; y++)
                    {
                        program[x] += tempString[y] + " ";
                    }
                    program[x] = program[x].Substring(0, program[x].Length - 1);
                    outBuffer.Add(program[x]);
                }
            }
            return outBuffer.ToArray();
        }

        public static string OpenFile()
        {
            ///<summary>Executes the code in the code box. Returns code's text output.</summary>
            ///<exception cref="IOException">Thrown when reading fails for any reason.</exception>
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
            ///<exception cref="ArgumentNullException">Thrown if null is passed to the method.</exception>
            ///<exception cref="ArgumentException">Thrown if no code is passed to the method.</exception>
            ///<exception cref="IOException">Thrown when saving fails for any reason.</exception>
            if (code == null) { throw new ArgumentNullException("Null passed in!"); }
            if (code == "") { throw new ArgumentException("No code!"); }
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
