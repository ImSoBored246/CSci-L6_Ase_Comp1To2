using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci_L6_Ase_Comp1To2
{
    public class ObjectDrawer
    {
        ///<summary>Class for drawing objects. Provides the code that actually creates the object and places it with appropriate offset</summary>
        ///
        public static ObjectShape DrawObject(int xPos, int yPos, int xSiz, int ySiz, int eCnt, SolidBrush b, bool fill)
        {
            ///<summary>Base method for creating ObjectShapes. Used to create more useful shapes.</summary>
            int[] coords = new int[4] { xPos + 751, yPos + 19, xSiz, ySiz };

            return new ObjectShape(coords, b, fill);
        }

        public static ObjectShape DrawObject(int[] crdn, int eCnt, SolidBrush b, bool fill)
        {
            ///<summary>Override for DrawObject that takes integer array instead of coordinates. To be used for undefined polygons.</summary>
            int[] coords = crdn;
            coords[0] = coords[0] + 751;
            coords[1] = coords[1] + 19;

            return new ObjectShape(coords, b, fill);
        }

        public static void DrawCircle(ObjectShape oShape, PaintEventArgs e)
        {
            ///<summary>Draw an elipsis at [xPos,yPos] with size [xSiz,ySiz]. CommandParser will ensure xSiz==ySiz in case of circle not oval.</summary>
            ///
            if (oShape.f)
            {
                e.Graphics.FillEllipse(oShape.b, new Rectangle(oShape.coords[0], oShape.coords[1], oShape.coords[2], oShape.coords[3]));
            }
            else
            {
                e.Graphics.DrawEllipse(new Pen(oShape.b, 1), new Rectangle(oShape.coords[0], oShape.coords[1], oShape.coords[2], oShape.coords[3]));
            }
        }
        public static void DrawRectangle(ObjectShape oShape, PaintEventArgs e)
        {
            ///<summary>Draw a rectangle of size and location ObjectShape.pb.Bounds. Fill determined by args.</summary>
            ///
            if (oShape.f)
            {
                e.Graphics.FillRectangle(oShape.b, new Rectangle(oShape.coords[0], oShape.coords[1], oShape.coords[2], oShape.coords[3]));
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(oShape.b, 1), new Rectangle(oShape.coords[0], oShape.coords[1], oShape.coords[2], oShape.coords[3]));
            }
        }

        public static void DrawLine(ObjectShape oShape, PaintEventArgs e)
        {
            ///<summary>Draws a line connecting coords[0,1] and coords[2,3].</summary>
            ///
            e.Graphics.DrawLine(new Pen(oShape.b, 1), new Point(oShape.coords[0], oShape.coords[1]), new Point(oShape.coords[2] + 751, oShape.coords[3] + 19));
        }

        public static void DrawTriangle(ObjectShape oShape, PaintEventArgs e)
        {
            ///<summary>Draw a rectangle of size and location ObjectShape.pb.Bounds. Fill determined by args.</summary>
            ///
            Point[] points = new Point[3];
            points[0] = new Point(oShape.coords[0], oShape.coords[1] + (oShape.coords[3] / 2));
            points[1] = new Point(oShape.coords[0] + oShape.coords[2], oShape.coords[1]);
            points[2] = new Point(oShape.coords[0] + oShape.coords[2], oShape.coords[1] + oShape.coords[3]);
            if (oShape.f)
            {
                e.Graphics.FillPolygon(oShape.b, points);
            }
            else
            {
                e.Graphics.DrawPolygon(new Pen(oShape.b, 1), points);
            }
        }
    }
}
