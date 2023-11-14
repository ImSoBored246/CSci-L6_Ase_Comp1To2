using CSci_L6_Ase_Comp1To2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject1
{
    internal class D_CommandParser : CommandParser
    {
        ///<summary>Dummy CommandParser IO that throw errors.</summary>
        ///
        public static string OpenFile(bool commit = true)
        {
            ///<summary>Pretends to open a file, only to throw an error. Can throw exception for failure, or abort as requested.</summary>
            if (commit) { throw new IOException("Dummy Check"); } else { throw new Exception("File Dialog aborted! Your file has NOT saved!"); }
        }
        public static void SaveFile(string code, bool commit = true)
        {
            ///<summary>Pretends to save a file, only to throw an error. Can throw exception for failure, or abort as requested.</summary>
            if (code == null) { throw new ArgumentNullException("Null passed in!"); }
            if (code == "") { throw new ArgumentException("No code!"); }
            if (commit) { throw new IOException("Dummy Check"); } else { throw new Exception("File Dialog aborted! Your file has NOT saved!"); } // commit shows whether to make the dialog fail or be manually closed
        }

        private static ObjectShape makeShape(string shapeCode)
        {
            ///<summary>Emulates functions in form1.Paint(..) and form1.addShape(..), for use in D_CommandParser.Execute(..)</summary>
            string[] command = shapeCode.Split("/");
            if (command[0] == "c") // circle
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(255, int.Parse(command[6]), int.Parse(command[7]), int.Parse(command[8])));
                return ObjectDrawer.DrawObject(int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), int.Parse(command[3]), int.Parse(command[4]), b, bool.Parse(command[5]));
            }
            else if (command[0] == "r") // rectangle
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(255, int.Parse(command[7]), int.Parse(command[8]), int.Parse(command[9])));
                return ObjectDrawer.DrawObject(int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), int.Parse(command[4]), int.Parse(command[5]), b, bool.Parse(command[6]));
            }
            else if (command[0] == "l") // line
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(255, int.Parse(command[7]), int.Parse(command[8]), int.Parse(command[9])));
                return ObjectDrawer.DrawObject(int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), int.Parse(command[4]), int.Parse(command[5]), b, bool.Parse(command[6]));
            }
            else if (command[0] == "t") // triangle
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(255, int.Parse(command[6]), int.Parse(command[7]), int.Parse(command[8])));
                return ObjectDrawer.DrawObject(int.Parse(command[1]), int.Parse(command[2]), int.Parse(command[3]), int.Parse(command[3]), int.Parse(command[4]), b, bool.Parse(command[5]));
            }
            throw new Exception("Invalid shape!");
        }

        public static string Execute(string code)
        {
            ///<summary>Executes a simulation of code. Currently based on [commit c9326a]. Tracks all values in a returned string. Should never throw errors.</summary>
            string log = "";
            try
            {
                CheckSyntax(code);
            }
            catch (Exception ex) { log = "FATAL COMPILE ERR " + ex.Message; return log; }

            // get initial values, copied from [CommandParser, commit c9326a...]
            // TODO: entityCount is deprecated and is to be removed
            int[] init_loc = { 10, 10 };
            int[] cursor_loc = { 10, 10 };
            int entityCount = 0;
            string outBuffer = "";
            SolidBrush br = new SolidBrush(Color.White);
            bool fill = false;
            string curCmd = "";
            List<ObjectShape> activeShapes = new List<ObjectShape>();
            List<string> activeTypes = new List<string>();
            int iter = 0;
            log = $"INIT: location={cursor_loc}, brush={br.Color}, fill={fill}\n";
            string[] iterable = code.Split("\n");
            iterable = FormatCode(iterable);

            while (iterable.Length > iter)
            {
                if (iterable[iter].Substring(0, 5) == "clear")
                {
                    activeShapes.Clear(); activeTypes.Clear(); log += "CLEAR - OK\n";
                }
                else if (iterable[iter].Substring(0, 5) == "reset")
                {
                    cursor_loc = init_loc; log += $"RESET - COORDS NOW [{cursor_loc[0]},{cursor_loc[1]}]\n";
                }
                else if (iterable[iter].Substring(0, 4) == "fill")
                {
                    fill = !fill; log += $"FILL - NOW {fill}\n";
                }
                else if (iterable[iter].Substring(0, 6) == "moveto")
                {
                    string[] vals = iterable[iter].Split(" ");
                    cursor_loc = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };
                    log += $"MOVE - COORDS NOW {cursor_loc}\n";
                }
                else if (iterable[iter].Substring(0, 6) == "circle")
                {
                    int size = int.Parse(iterable[iter].Split(" ")[1]);
                    curCmd = "c/" + cursor_loc[0] + "/" + cursor_loc[1] + "/" + size + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                    activeShapes.Add(makeShape(curCmd)); activeTypes.Add(curCmd[0].ToString());
                    log += $"CIRCLE - DETAILS: {curCmd}\n";
                }
                else if (iterable[iter].Substring(0, 4) == "rect" || iterable[iter].Substring(0, 9) == "rectangle")
                {
                    string[] vals = iterable[iter].Split(" ");
                    int[] size = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };
                    curCmd = "r/" + cursor_loc[0] + "/" + cursor_loc[1] + "/" + size[0] + "/" + size[1] + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                    activeShapes.Add(makeShape(curCmd)); activeTypes.Add(curCmd[0].ToString());
                    log += $"RECTANGLE - DETAILS: {curCmd}\n";
                }
                else if (iterable[iter].Substring(0, 6) == "drawto")
                {
                    string[] vals = iterable[iter].Split(" ");
                    int[] size = new int[] { int.Parse(vals[1]), int.Parse(vals[2]) };
                    curCmd = "l/" + cursor_loc[0] + "/" + cursor_loc[1] + "/" + size[0] + "/" + size[1] + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                    activeShapes.Add(makeShape(curCmd)); activeTypes.Add(curCmd[0].ToString());
                    log += $"DRAWTO - DETAILS: {curCmd}\n";
                }
                else if (iterable[iter].Substring(0, 8) == "triangle")
                {
                    int size = int.Parse(iterable[iter].Split(" ")[1]);
                    curCmd = "t/" + cursor_loc[0] + "/" + cursor_loc[1] + "/" + size + "/" + entityCount + "/" + fill + "/" + br.Color.R + "/" + br.Color.G + "/" + br.Color.B;
                    activeShapes.Add(makeShape(curCmd)); activeTypes.Add(curCmd[0].ToString());
                    log += $"TRIANGLE - DETAILS: {curCmd}\n";
                }
                else if (iterable[iter].Substring(0, 3) == "pen")
                {
                    string col = iterable[iter].Split(" ")[1];
                    if (col == "red") { br.Color = Color.FromArgb(255, 255, 0, 0); }
                    else if (col == "green") { br.Color = Color.FromArgb(255, 0, 255, 0); }
                    else if (col == "blue") { br.Color = Color.FromArgb(255, 0, 0, 255); }
                    else if (col == "white") { br.Color = Color.FromArgb(255, 255, 255, 255); }
                    log += $"PEN - NEW COLOUR={br.Color}\n";
                }
                else
                {
                    throw new ArgumentException($"Line {iter + 1} ERR! \"{iterable[iter]}\" is an invalid command");
                }
                iter++;
            }
            log += $"END - FINAL VALUES:\nInitial cursor location: [{init_loc[0]},{init_loc[1]}] (current: [{cursor_loc[0]},{cursor_loc[1]}])\nShapes: {activeShapes.Count}\nFinal pen colour: {br.Color}, lines iterated: {iter}\nDetails on shapes:\n";
            foreach (var item in activeShapes)
            {
                log += $"\tCoords: [{item.coords[0]}, {item.coords[1]}]. Size: [{item.coords[2]}, {item.coords[3]}]. Filled?{item.f}. Colour: {item.b.Color}\n";
            }
            return log;
        }
    }
}
