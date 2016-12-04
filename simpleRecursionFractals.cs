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
        MainForm form = new MainForm {Size = new System.Drawing.Size(310, 330)};
        Application.Run (form);
    }

    public MainForm () {    
        Text = "Simple Recursion Fractals";

	fractalNames.Add("threeSquares", "three-squares");
        fractalNames.Add("whiteCarpet", "white-carpet");
        fractalNames.Add("blackCarpet", "black-carpet");
        fractalNames.Add("shentschel_citybuilding", "shentschel_citybuilding");
        fractalNames.Add("krampMaximilian_spaceInvaders", "krampMaximilian_spaceInvaders");
        fractalNames.Add("nRandomBranchesTree", "random-tree");
	
        // ComboBox
        cb.Location = new System.Drawing.Point(10, 250);
	foreach (string value in fractalNames.Values) {
		cb.Items.Add(value);
	}
	cb.Text = fractalNames["threeSquares"];

	// Button
	bt.Location = new System.Drawing.Point(210, 250);
        bt.Text = "Create";
        bt.Click += new EventHandler (Button_Click);

	//PictureBox
	pb.Location = new System.Drawing.Point(48, 25);
	pb.Size = new System.Drawing.Size(200, 200);
	pb.BorderStyle = BorderStyle.FixedSingle;
	pb.BackColor = Color.White;

	//TextBox
	tb.Text = "50";
	tb.Location = new System.Drawing.Point(140, 250);
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
	else if (cb.SelectedItem.ToString() == fractalNames["shentschel_citybuilding"]){
	    gp.Clear(Color.White);
	    fractal.shentschel_citybuilding(gp, 100, 100, ratio);
	}
	else if (cb.SelectedItem.ToString() == fractalNames["krampMaximilian_spaceInvaders"]){
	    gp.Clear(Color.White);
	    fractal.krampMaximilian_spaceInvaders(gp, 100, 100, ratio);
	}
	else if (cb.SelectedItem.ToString() == fractalNames["nRandomBranchesTree"]){
	    gp.Clear(Color.White);
	    fractal.nRandomBranchesTree(gp, 100, 200, ratio);
	}

        pb.Update();
    }
  }
}
