using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;	

namespace SimpleRecursionFractals {
  public class MainForm : Form {

    // Add here your new fractal string name
    Dictionary<string, string> fractalNames = new Dictionary<string, string>();

    //form components
    ComboBox cb = new ComboBox();
    Button bt = new Button();
    PictureBox pb =  new PictureBox();
    TextBox tb = new TextBox();

    Graphics gp;
    Fractals fractal = new Fractals();

    static public void Main () {
        Application.Run (new MainForm());
    }

    public MainForm () {    
        Text = "Simple Recursion Fractals";

	fractalNames.Add("threeSquares", "three-squares");
        fractalNames.Add("whiteCarpet", "white-carpet");
        fractalNames.Add("blackCarpet", "black-carpet");
	
	// ComboBox
	cb.Location = new System.Drawing.Point(1, 250);
	foreach (string value in fractalNames.Values) {
		cb.Items.Add(value);
	}
	cb.Text = fractalNames["threeSquares"];

	// Button
	bt.Location = new System.Drawing.Point(200, 250);
        bt.Text = "Create";
        bt.Click += new EventHandler (Button_Click);

	//PictureBox
	pb.Size = new System.Drawing.Size(200, 200);

	//TextBox
	tb.Text = "50";
	tb.Location = new System.Drawing.Point(130, 250);
	tb.Size = new System.Drawing.Size(60, 20);
	
        Controls.AddRange(new Control[] {bt, cb, pb, tb});

    	gp = pb.CreateGraphics();
    }

    private void Button_Click (object sender, EventArgs e) {	
        gp.Clear(Color.White);
	int ratio = int.Parse(tb.Text);
	
	if (cb.SelectedItem.ToString() == fractalNames["threeSquares"]) {
           fractal.threeSquares(gp, 100, 100, ratio);
	}
	else if(cb.SelectedItem.ToString() == fractalNames["whiteCarpet"]) {
           fractal.whiteCarpet(gp, 100, 100, ratio);
	}
	else if(cb.SelectedItem.ToString() == fractalNames["blackCarpet"]) {
	   gp.Clear(Color.Black);
           fractal.blackCarpet(gp, 100, 100, ratio);
	}

        pb.Update();
    }
  }
}