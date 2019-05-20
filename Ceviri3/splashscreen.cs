using System;
using System.Windows.Forms;

namespace Ceviri3
{
    public partial class splashscreen : Form
    {
        public splashscreen()
        {
            InitializeComponent();
        }

        private void Splashscreen_Load(object sender, EventArgs e) => timer1.Start();

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value == 100)
            {

                timer1.Stop();
                timer2.Start();

            }
            else
            {
                bunifuProgressBar1.Value += 2;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                Form1 form = new Form1();
                form.Visible = true;
                this.Visible = false;
            }
        }
    }
}
