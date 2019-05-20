using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ceviri3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Stop();
                a = "anasayfa";
                timer1.Start();
            }
            else
            {
                a = "anasayfa";
                timer1.Start();
            }
        }

        private void BunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Stop();
                a = "yapimci";
                timer1.Start();
            }
            else
            {
                a = "yapimci";
                timer1.Start();
            }
        }
        string a = "";
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (a == "anasayfa")
            {
                if (this.Opacity == 0)
                {
                    timer1.Stop();
                    this.Visible = false;
                    ceviri cev = new ceviri();
                    cev.Visible = true;
                }
                else
                {
                    this.Opacity -= 0.025;
                }
            }
            else if (a == "yapimci")
            {
                if(this.Opacity == 0)
                {
                    timer1.Stop();
                    yapimcilar yap = new yapimcilar();
                    yap.Visible = true;
                    this.Close();
                }
                else
                {
                    this.Opacity -= 0.025;
                }
            }
            else if(a == "ayarlar")
            {
                if (this.Opacity == 0)
                {
                    timer1.Stop();
                    ayarlar ayar = new ayarlar();
                    ayar.Visible = true;
                    this.Close();
                }
                else
                {
                    this.Opacity -= 0.025;
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer2.Stop();
            }
            else
            {
                this.Opacity += 0.025;
            }
        }

        private void BunifuImageButton5_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Stop();
                a = "ayarlar";
                timer1.Start();
            }
            else
            {
                a = "ayarlar";
                timer1.Start();
            }
        }
    }
}
