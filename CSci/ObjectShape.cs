using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci_L6_Ase_Comp1To2
{
    public class ObjectShape
    {
    /// <summary>Information storage class. Stores fill state, coordinates and brush(colour)</summary>
    ///
        public int[] coords { get; set; }
        public SolidBrush b { get; set; }
        public bool f { get; set; }
        public ObjectShape(int[] crd, SolidBrush bru, bool fill = false) {
            coords = crd;
            b = bru;
            f = fill;
        }
    }
}
