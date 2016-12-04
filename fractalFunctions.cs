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
            if (ratioRects > 0) {
                int newRatio = ratioRects / 2;

                threeSquares(g, x - newRatio, y + newRatio, newRatio);
                threeSquares(g, x - newRatio, y - newRatio, newRatio);
                threeSquares(g, x + newRatio, y - newRatio, newRatio);

                g.FillRectangle(brWhite, x, y, ratioRects, ratioRects);
                g.DrawRectangle(penBlack, x, y, ratioRects, ratioRects);
            }
            // System.Threading.Thread.Sleep(10);  //delay to show the recursion
        }

        public void whiteCarpet(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0) {
                int newRatio = ratioRects / 2;

                whiteCarpet(g, x - ratioRects, y + ratioRects, newRatio);
                whiteCarpet(g, x + ratioRects, y + ratioRects, newRatio);
                whiteCarpet(g, x - ratioRects, y - ratioRects, newRatio);
                whiteCarpet(g, x + ratioRects, y - ratioRects, newRatio);

                g.FillRectangle(brWhite, x - newRatio, y - newRatio, ratioRects, ratioRects);
                g.DrawRectangle(penBlack, x - newRatio, y - newRatio, ratioRects, ratioRects);
            }
        }

        public void blackCarpet(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0) {
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
            if (ratioRects > 0) {
                int newRatio = (int)(ratioRects / 1.5);

                shentschel_citybuilding(g, x - ratioRects, y + ratioRects, newRatio);
                shentschel_citybuilding(g, x + ratioRects, y - ratioRects, newRatio);
                shentschel_citybuilding(g, x - ratioRects, y - ratioRects, newRatio);
                shentschel_citybuilding(g, x + ratioRects, y + ratioRects, newRatio);

                g.FillRectangle(brWhite, x - newRatio, y - newRatio, ratioRects, ratioRects);
                g.DrawRectangle(penBlack, x - newRatio, y - newRatio, ratioRects, ratioRects);
            }

        }

        public void krampMaximilian_spaceInvaders(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0) {
                int newRatio = (int)(ratioRects / 2);

                krampMaximilian_spaceInvaders(g, x - ratioRects, y * ratioRects, newRatio);
                krampMaximilian_spaceInvaders(g, x + ratioRects, y - ratioRects, newRatio);
                krampMaximilian_spaceInvaders(g, x - ratioRects, y - ratioRects, newRatio);
                krampMaximilian_spaceInvaders(g, x * ratioRects, y + ratioRects, newRatio);

                g.FillRectangle(brWhite, x - newRatio, y - newRatio, ratioRects, ratioRects);
                g.DrawRectangle(penBlack, x - newRatio, y - newRatio, ratioRects, ratioRects);
            }
        }
	
	public void nRandomBranchesTree(Graphics g, int x, int y, int ratioRects)
        {	    
            Random rand = new Random();
	    
	    float widthPen = 5;
            float length = (int)(y * rand.Next(ratioRects-30, ratioRects-30) / 100.0);
            double angle = -Math.PI / 2;
            DrawBranches(rand, g, widthPen, length, x, y, angle);
	}

        private void DrawBranches(Random rand, Graphics gr, float widthPen, float length, float x, float y, double angle)
        {
            // See where this branch ends.
            float x1 = (float)(x + length * Math.Cos(angle));
            float y1 = (float)(y + length * Math.Sin(angle));

            int scale1 = rand.Next((int)length, 255);
            int greenColor = scale1 - (int) length;
            if (greenColor > 255) greenColor = 255;

            Color color = Color.FromArgb(0, greenColor, 0);
            using (Pen pen = new Pen(color, widthPen)){
                gr.DrawLine(pen, x, y, x1, y1);
            }

            int numBranches = rand.Next(2, 10);
            for (int i = 0; i < numBranches; i++) { 
                float scale2 = rand.Next(25, 75) / 100f;
                float newWidth = widthPen * scale2;
                float newLength = length * scale2;

		if (newLength < 5) break;
		
		double newAngle = angle + rand.Next(-80, 81) * Math.PI / 180.0;
		DrawBranches(rand, gr, newWidth, newLength, x1, y1, newAngle);		
            }
        }
    }
}
