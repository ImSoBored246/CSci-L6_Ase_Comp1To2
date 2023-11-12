using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci_L6_Ase_Comp1To2
{
    public class ObjectShape
    {
        internal int[] coords { get; set; }
        internal Brush b { get; set; }
        internal bool f { get; set; }
        public ObjectShape(int[] crd, Brush bru) {
            coords = crd;
            b = bru;
            f = false;
        }
        public ObjectShape(int[] crd, Brush bru, bool fill) {
            coords = crd;
            b = bru;
            f = fill;
        }
    }
}
