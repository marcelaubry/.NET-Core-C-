using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class BaseGraphicsElementClass
    {
        public virtual void Draw(Graphics g) { }

        public Color SelectedColor(int nonConvertedColor)
        {
            Color convertedColor;
            if (nonConvertedColor == 1)
            {
                convertedColor = Color.Black;
                return convertedColor;
            }
            else if (nonConvertedColor == 2)
            {
                convertedColor = Color.Red;
                return convertedColor;
            }
            else if (nonConvertedColor == 3)
            {
                convertedColor = Color.Blue;
                return convertedColor;
            }
            else if (nonConvertedColor == 4)
            {
                convertedColor = Color.Green;
                return convertedColor;
            }
            else { return Color.Empty; }
        }
    }
    class LineClass : BaseGraphicsElementClass
    {
        private readonly Point Point1, Point2;
        private readonly Color PenColor;
        private readonly int PenSize;

        public LineClass(Point inputPoint1, Point inputPoint2, int inputPenColor, int inputPenSize)
        {
            Point1 = inputPoint1;
            Point2 = inputPoint2;
            PenColor = SelectedColor(inputPenColor);
            PenSize = inputPenSize;
        }

        public override void Draw(Graphics g)
        {
            var myPen = new Pen(PenColor, PenSize);
            g.DrawLine(myPen, Point1, Point2);
        }
    }

    class RectangleClass : BaseGraphicsElementClass
    {
        private readonly int PenSize, X, Y, Width, Height;
        private readonly Color Outline, FillColor;

        public RectangleClass(Point inputPoint1, Point inputPoint2, int inputPenColor, int inputPenFill,
                              int inputPenSize)
        {
            X = inputPoint1.X > inputPoint2.X ? inputPoint2.X : inputPoint1.X;
            Y = inputPoint1.Y > inputPoint2.Y ? inputPoint2.Y : inputPoint1.Y;
            Width = Math.Abs(inputPoint1.X - inputPoint2.X);
            Height = Math.Abs(inputPoint1.Y - inputPoint2.Y);
            Outline = SelectedColor(inputPenColor);
            FillColor = SelectedColor(inputPenFill);
            PenSize = inputPenSize;
        }
        public override void Draw(Graphics g)
        {
            var myOutlinePen = new Pen(Outline, PenSize);
            using (Brush myFillBrush = new SolidBrush(FillColor))
            {
                // Color.Empty was assigned if no fill or no outline was selected respectively
                if (FillColor != Color.Empty)
                {
                    g.FillRectangle(myFillBrush, X, Y, Width, Height);
                }
                if (Outline != Color.Empty)
                {
                    g.DrawRectangle(myOutlinePen, X, Y, Width, Height);
                }
            }
        }
    }

    class EllipseClass : BaseGraphicsElementClass
    {
        private readonly int PenSize, X, Y, Width, Height;
        private readonly Color Outline, FillColor;

        public EllipseClass(Point inputPoint1, Point inputPoint2, int inputPenColor, int inputPenFill, 
                            int inputPenSize)
        {
            X = inputPoint1.X > inputPoint2.X ? inputPoint2.X : inputPoint1.X;
            Y = inputPoint1.Y > inputPoint2.Y ? inputPoint2.Y : inputPoint1.Y;
            Width = Math.Abs(inputPoint1.X - inputPoint2.X);
            Height = Math.Abs(inputPoint1.Y - inputPoint2.Y);
            Outline = SelectedColor(inputPenColor);
            FillColor = SelectedColor(inputPenFill);
            PenSize = inputPenSize;
        }
        public override void Draw(Graphics g)
        {
            var myOutlinePen = new Pen(Outline, PenSize);
            using (Brush myFillBrush = new SolidBrush(FillColor))
            {
                // Color.Empty was assigned if no fill or no outline was selected respectively
                if (FillColor != Color.Empty)
                {
                    g.FillEllipse(myFillBrush, X, Y, Width, Height);
                }
                if (Outline != Color.Empty)
                {
                    g.DrawEllipse(myOutlinePen, X, Y, Width, Height);
                }  
            }
        }
    }
}
