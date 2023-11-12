using CSci_L6_Ase_Comp1To2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class D_CommandParser : CommandParser
    {
        ///<summary>Dummy CommandParser IO that throw errors.</summary>
        ///
        public static new string OpenFile() {
        throw new IOException("Dummy Check");
        }
        public static void SaveFile(string code, bool commit=true) {
        if (code == null) { throw new ArgumentNullException("Null passed in!"); }
        if (code == "") { throw new ArgumentException("No code!"); }
        if (commit) { throw new IOException("Dummy Check"); } else { throw new Exception("File Dialog aborted! Your file has NOT saved!"); } // commit shows whether to make the dialog fail or be manually closed
        }
    }
}
