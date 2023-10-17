using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci_L6_Ase_Comp1To2
{
    abstract class ObjectDrawer
    {
        ///<summary>Abstract class for drawing objects. Provides the code that actually creates the object and places it with appropriate offset</summary>
        ///
        public static ObjectShape DrawObject(int xPos, int yPos, int xSiz, int ySiz, int eCnt, Brush b)
        {
            ///<summary>Base method for creating ObjectShapes. Used to create more useful shapes.</summary>
            PictureBox pb = new PictureBox();
            pb.Location = new Point(xPos + 751, yPos + 19); // account for the offset of the box!
            pb.Size = new Size(xSiz, ySiz);
            pb.Name = eCnt.ToString();
            var g = Graphics.FromImage(pb.Image);
            return new ObjectShape(pb, g, b);
        }
        public static void DrawCircle(int xPos, int yPos, int xSiz, int ySiz, int eCnt, Brush b)
        {
            ///<summary>Draw an elipsis at [xPos,yPos] with size [xSiz,ySiz]. CommandParser will ensure xSiz==ySiz in case of circle not oval.</summary>
            ///
            ObjectShape oShape = DrawObject(xPos, yPos, xSiz, ySiz, eCnt, b);
            oShape.g.FillEllipse(oShape.b, xPos, yPos, xSiz, ySiz);
        }
        public static void DrawRectangle(int xPos, int yPos, int xSiz, int ySiz, int eCnt, Brush b)
        {
            ///<summary>Draw a rectangle at [xPos,yPos] with size [xSiz,ySiz]. CommandParser will ensure xSiz==ySiz in case of square.</summary>
            ///
            ObjectShape oShape = DrawObject(xPos, yPos, xSiz, ySiz, eCnt, b);
            oShape.g.FillRectangle(oShape.b, xPos, yPos, xSiz, ySiz);
        }
        public static void DrawLine(int xPos, int yPos, int xSiz, int ySiz, int eCnt, Brush b)
        {
            ///<summary>Draw a line connecting [xPos,yPos] with [xSiz,ySiz].</summary>
            ///
            ObjectShape oShape = DrawObject(xPos, yPos, xSiz, ySiz, eCnt, b);
            Pen pen = new Pen(b);
            Point p1 = new Point(xPos, yPos);
            Point p2 = new Point(xSiz, ySiz);
            oShape.g.DrawLine(pen,p1,p2);
        }
    }
}
