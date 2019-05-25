using SonsuzAlgoritma;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ceviri3
{
    public partial class yapimcilar : Form
    {
        public yapimcilar()
        {
            InitializeComponent();
        }

        private void BunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Stop();
                a = "umut";
                timer1.Start();
            }
            else
            {
                a = "umut";
                timer1.Start();
            }
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Stop();
                a = "exit";
                timer1.Start();
            }
            else
            {
                a = "exit";
                timer1.Start();
            }
        }

        private void BunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Stop();
                a = "mustafa";
                timer1.Start();
            }
            else
            {
                a = "mustafa";
                timer1.Start();
            }
        }
        string a;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (a.Contains("exit"))
            {
                if (this.Opacity == 0)
                {
                    timer1.Stop();
                    Form1 form = new Form1();
                    form.Visible = true;
                    this.Close();
                }
                else
                {
                    this.Opacity -= 0.025;
                }
            }
            else if (a.Contains("mustafa"))
            {
                if (this.Opacity == 0)
                {
                    timer1.Stop();
                    messagebox message = new messagebox("Mustafa");
                    message.Visible = true;
                    this.Close();
                }
                else
                {
                    this.Opacity -= 0.025;
                }
            }
            else if (a.Contains("umut"))
            {
                if (this.Opacity == 0)
                {
                    timer1.Stop();
                    messagebox message = new messagebox("Umut");
                    message.Visible = true;
                    this.Close();
                }
                else
                {
                    this.Opacity -= 0.025;
                }
            }
        }

        private void Yapimcilar_Load(object sender, EventArgs e)
        {
            SonsuzFile file = new SonsuzFile(Environment.CurrentDirectory + "/settings.ini");
            if(file.Read("Application","Background").Contains("dark"))
            {
                this.BackColor = ColorTranslator.FromHtml("#3E3E42");
            }
            else
            {
                this.BackColor = Color.White;
            }
            timer2.Start();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                timer2.Stop();
            }
            else
            {
                this.Opacity += 0.025;
            }
        }
    }
}
