using System;
using System.Drawing;

namespace SimpleRecursionFractals
{
    public class Fractals
    {
        // add here different pen and brush colors
        public SolidBrush brWhite = new SolidBrush(Color.White);
        public Pen penBlack = new Pen(Color.Black);
        public Pen penWhite = new Pen(Color.White);

        public void threeSquares(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;

                threeSquares(g, x - newRatio, y + newRatio, newRatio);
                threeSquares(g, x - newRatio, y - newRatio, newRatio);
                threeSquares(g, x + newRatio, y - newRatio, newRatio);

                g.FillRectangle(brWhite, x, y, ratioRects, ratioRects);
                g.DrawRectangle(penBlack, x, y, ratioRects, ratioRects);
            }
        }

        public void whiteCarpet(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;

                whiteCarpet(g, x - ratioRects, y + ratioRects, newRatio);
                whiteCarpet(g, x + ratioRects, y + ratioRects, newRatio);
                whiteCarpet(g, x - ratioRects, y - ratioRects, newRatio);
                whiteCarpet(g, x + ratioRects, y - ratioRects, newRatio);

                g.FillRectangle(brWhite, x - newRatio, y - newRatio, ratioRects, ratioRects);
                g.DrawRectangle(penBlack, x - newRatio, y - newRatio, ratioRects, ratioRects);
            }

            // System.Threading.Thread.Sleep(10);  //delay to show the recursion
        }

        public void blackCarpet(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;

                blackCarpet(g, x - ratioRects, y + ratioRects, newRatio);
                blackCarpet(g, x + ratioRects, y + ratioRects, newRatio);
                blackCarpet(g, x - ratioRects, y - ratioRects, newRatio);
                blackCarpet(g, x + ratioRects, y - ratioRects, newRatio);

                int offset = (int)(newRatio * 0.707);

                g.FillRectangle(brWhite, x - newRatio - offset, y - newRatio - offset, ratioRects + offset, ratioRects + offset);
                g.DrawRectangle(penWhite, x - newRatio - offset, y - newRatio - offset, ratioRects + offset, ratioRects + offset);
            }
        }

        public void shentschel_citybuilding(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = (int)(ratioRects / 1.5);

                shentschel_citybuilding(g, x - ratioRects, y + ratioRects, newRatio);
                shentschel_citybuilding(g, x + ratioRects, y - ratioRects, newRatio);
                shentschel_citybuilding(g, x - ratioRects, y - ratioRects, newRatio);
                shentschel_citybuilding(g, x + ratioRects, y + ratioRects, newRatio);

                g.FillRectangle(brWhite, x - newRatio, y - newRatio, ratioRects, ratioRects);
                g.DrawRectangle(penBlack, x - newRatio, y - newRatio, ratioRects, ratioRects);
            }
            
        }
    }
}