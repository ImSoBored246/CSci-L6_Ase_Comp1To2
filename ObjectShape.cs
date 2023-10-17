using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci_L6_Ase_Comp1To2
{
    internal class ObjectShape
    {
        internal PictureBox pb { get; set; }
        internal Graphics g { get; set; }
        internal Brush b { get; set; }
        public ObjectShape(PictureBox pic, Graphics gra, Brush bru) {
            pb = pic;
            g = gra;
            b = bru;
        }
    }
}
