using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bunifu.UI;

namespace Ceviri3
{
    public partial class oyun_soru : Form
    {
        public oyun_soru()
        {
            InitializeComponent();
        }
        string dogru = "a";
        private void Oyun_soru_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e) => dogruluk("a");
        private void BunifuFlatButton2_Click(object sender, EventArgs e) => dogruluk("b");
        private void BunifuFlatButton3_Click(object sender, EventArgs e) => dogruluk("c");
        private void BunifuFlatButton4_Click(object sender, EventArgs e) => dogruluk("d");

        public void dogruluk(string harf)
        {
            bunifuFlatButton1.Visible = false;
            bunifuFlatButton2.Visible = false;
            bunifuFlatButton3.Visible = false;
            bunifuFlatButton4.Visible = false;
            if (harf == dogru)
            {
                if (harf == "a")
                {
                    
                    bunifuFlatButton1.BackColor = Color.Green;
                    bunifuFlatButton2.BackColor = Color.Red;
                    bunifuFlatButton3.BackColor = Color.Red;
                    bunifuFlatButton4.BackColor = Color.Red;
                }
                else if (harf == "b")
                {
                    bunifuFlatButton1.BackColor = Color.Red;
                    bunifuFlatButton2.BackColor = Color.Green;
                    bunifuFlatButton3.BackColor = Color.Red;
                    bunifuFlatButton4.BackColor = Color.Red;
                }
                else if (harf == "c")
                {
                    bunifuFlatButton1.BackColor = Color.Red;
                    bunifuFlatButton2.BackColor = Color.Red;
                    bunifuFlatButton3.BackColor = Color.Green;
                    bunifuFlatButton4.BackColor = Color.Red;
                }
                else if (harf == "d")
                {
                    bunifuFlatButton1.BackColor = Color.Red;
                    bunifuFlatButton2.BackColor = Color.Red;
                    bunifuFlatButton3.BackColor = Color.Red;
                    bunifuFlatButton4.BackColor = Color.Green;
                }
            }
            else
            {
                if (harf == "a")
                {

                    bunifuFlatButton1.BackColor = Color.Green;
                    bunifuFlatButton2.BackColor = Color.Red;
                    bunifuFlatButton3.BackColor = Color.Red;
                    bunifuFlatButton4.BackColor = Color.Red;
                }
                else if (harf == "b")
                {
                    bunifuFlatButton1.BackColor = Color.Red;
                    bunifuFlatButton2.BackColor = Color.Green;
                    bunifuFlatButton3.BackColor = Color.Red;
                    bunifuFlatButton4.BackColor = Color.Red;
                }
                else if (harf == "c")
                {
                    bunifuFlatButton1.BackColor = Color.Red;
                    bunifuFlatButton2.BackColor = Color.Red;
                    bunifuFlatButton3.BackColor = Color.Green;
                    bunifuFlatButton4.BackColor = Color.Red;
                }
                else if (harf == "d")
                {
                    bunifuFlatButton1.BackColor = Color.Red;
                    bunifuFlatButton2.BackColor = Color.Red;
                    bunifuFlatButton3.BackColor = Color.Red;
                    bunifuFlatButton4.BackColor = Color.Green;
                }
            }
            bunifuFlatButton1.Visible = true;
            bunifuFlatButton2.Visible = true;
            bunifuFlatButton3.Visible = true;
            bunifuFlatButton4.Visible = true;
        }
    }
}
