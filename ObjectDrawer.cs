using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci_L6_Ase_Comp1To2
{
    class ObjectDrawer
    {
        ///<summary>Class for drawing objects. Provides the code that actually creates the object and places it with appropriate offset</summary>
        ///
        public static ObjectShape DrawObject(int xPos, int yPos, int xSiz, int ySiz, int eCnt, Brush b = null)
        {
            ///<summary>Base method for creating ObjectShapes. Used to create more useful shapes.</summary>
            PictureBox pb = new PictureBox();
            if (b == null) { b = new SolidBrush(Color.Black); } // counter null if unknown
            pb.Image = new Bitmap(xSiz,ySiz);
            pb.Location = new Point(xPos + 751, yPos + 19); // account for the offset of the box!
            pb.Size = new Size(xSiz, ySiz);
            pb.Bounds = new Rectangle(xPos + 751, yPos + 19, xSiz,ySiz);
            pb.Name = "pb_" + eCnt.ToString();
            var g = Graphics.FromImage(pb.Image);
            pb.Visible = true;
            return new ObjectShape(pb, g, b);
        }
        public static void DrawCircle(ObjectShape oShape, bool fill)
        {
            ///<summary>Draw an elipsis at [xPos,yPos] with size [xSiz,ySiz]. CommandParser will ensure xSiz==ySiz in case of circle not oval.</summary>
            ///
            if (fill)
            {
                oShape.g.FillEllipse(oShape.b, oShape.pb.Bounds);
            } else
            {
                oShape.g.DrawEllipse(new Pen(oShape.b, 1), oShape.pb.Bounds);
            }
        }
        public static void DrawRectangle(ObjectShape oShape, bool fill)
        {
            ///<summary>Draw a rectangle of size and location ObjectShape.pb.Bounds. Fill determined by args.</summary>
            ///
            if (fill)
            {
                oShape.g.FillRectangle(oShape.b, oShape.pb.Bounds);
            } else
            {
                oShape.g.DrawRectangle(new Pen(oShape.b, 1), oShape.pb.Bounds);
            }
        }

        public static void DrawAmbig(ObjectShape oShape, bool fill, string type, PaintEventArgs e)
        {
            oShape.g = e.Graphics;
            if (type == "circle") { DrawCircle(oShape, fill); }
            else if (type == "rect") { DrawRectangle(oShape, fill); }
            else if (type == "line") { DrawLine(oShape); }
        }
        public static void DrawLine(ObjectShape oShape)
        {
            ///<summary>Draw a line connecting the corners of the passed ObjectShape.</summary>
            ///
            Pen pen = new Pen(oShape.b);
            Point p1 = new Point(oShape.pb.Location.X, oShape.pb.Location.Y);
            Point p2 = new Point(oShape.pb.Size.Width, oShape.pb.Size.Height);
            oShape.g.DrawLine(pen,p1,p2);
        }
    }
}
