using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci_L6_Ase_Comp1To2
{
    internal class DrawFunctions
    {
        public static void ClearAllPictureBoxes(int eC, ref Form1 form)
        {
            for (int x = 0; x < eC; x++)
            {
                form.Controls.RemoveByKey("pb_" + eC);
            }
        }
    }
}
