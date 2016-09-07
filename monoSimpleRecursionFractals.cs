using System;
using System.Drawing;
using System.Windows.Forms;

public class SimpleRecursionFractals : Form
{
    //add here your new fractal string name
    const string fractalThreeSquares = "three-squares";
    const string fractalCarpet = "carpet";
    const string fractalWhiteOnBlack = "white-on-black";

    //add here a different pen and brush colors
    SolidBrush br1 = new SolidBrush(Color.White);
    Pen pen1 = new Pen(Color.Black);

    SolidBrush br3 = new SolidBrush(Color.White);
    Pen pen3 = new Pen(Color.White);

    //form components
    ComboBox cb;
    Button b;
    PictureBox pb;
    TextBox tb;

    static public void Main ()
    {
        Application.Run (new SimpleRecursionFractals());
    }

    public SimpleRecursionFractals ()
    {    
        Text = "Simple Recursion Fractals";
	
	cb = new ComboBox();
	cb.Location = new System.Drawing.Point(1, 250);
	cb.Items.AddRange(new object[] {
			      fractalThreeSquares,
			      fractalCarpet,
			      fractalWhiteOnBlack
			      });
	cb.Text = fractalThreeSquares;

	b = new Button();
	b.Location = new System.Drawing.Point(200, 250);
        b.Text = "Create";
        b.Click += new EventHandler (Button_Click);

	pb =  new PictureBox();
	pb.Size = new System.Drawing.Size(200, 200);

	tb = new TextBox();
	tb.Text = "50";
	tb.Location = new System.Drawing.Point(130, 250);
	tb.Size = new System.Drawing.Size(60, 20);
	
        Controls.AddRange(new Control[] {b, cb, pb, tb});
    }

    private void Button_Click (object sender, EventArgs e)
    {
	Graphics g = pb.CreateGraphics();
	
        g.Clear(Color.White);
	int ratio = int.Parse(tb.Text);

	if (cb.SelectedItem.ToString() == fractalThreeSquares){
           threeSquares(g, 100, 100, ratio);
	}
	else if(cb.SelectedItem.ToString() == fractalCarpet){
           carpet(g, 100, 100, ratio);
	}
	else if(cb.SelectedItem.ToString() == fractalWhiteOnBlack){
	   g.Clear(Color.Black);
           whiteOnBlack(g, 100, 100, ratio);
	}

        pb.Update();
    }

    private void threeSquares(Graphics g, int x, int y, int ratioRects)
    {
	if (ratioRects > 0)
	{
	    int newRatio = ratioRects / 2;

	    threeSquares(g,  x - newRatio, y + newRatio, newRatio);             
	    threeSquares(g, x - newRatio, y - newRatio, newRatio);
	    threeSquares(g,  x + newRatio, y - newRatio, newRatio);                

	    g.FillRectangle(br1, x, y, ratioRects, ratioRects);
	    g.DrawRectangle(pen1, x, y, ratioRects, ratioRects);
	}
    }

    private void carpet(Graphics g, int x, int y, int ratioRects)
    {
	if (ratioRects > 0)
	{                
	    int newRatio = ratioRects / 2;

	    carpet(g, x - ratioRects, y + ratioRects, newRatio);
	    carpet(g, x + ratioRects, y + ratioRects, newRatio);
	    carpet(g, x - ratioRects, y - ratioRects, newRatio);
	    carpet(g, x + ratioRects, y - ratioRects, newRatio);

	    g.FillRectangle(br1, x - newRatio, y - newRatio, ratioRects, ratioRects);
	    g.DrawRectangle(pen1, x - newRatio, y - newRatio, ratioRects, ratioRects);
	}
    }

    private void whiteOnBlack(Graphics g, int x, int y, int ratioRects)
    {
	if (ratioRects > 0)
	{
	    int newRatio = ratioRects / 2;

	    whiteOnBlack(g, x - ratioRects, y + ratioRects, newRatio);
	    whiteOnBlack(g, x + ratioRects, y + ratioRects, newRatio);
	    whiteOnBlack(g, x - ratioRects, y - ratioRects, newRatio);
	    whiteOnBlack(g, x + ratioRects, y - ratioRects, newRatio);

	    int offset = (int)(newRatio * 0.707);

	    g.FillRectangle(br3, x - newRatio - offset, y - newRatio - offset, ratioRects + offset, ratioRects + offset);
	    g.DrawRectangle(pen3, x - newRatio - offset, y - newRatio - offset, ratioRects + offset, ratioRects + offset);
	}
    }
}