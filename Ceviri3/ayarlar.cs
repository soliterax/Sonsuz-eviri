using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SonsuzAlgoritma;

namespace Ceviri3
{
    public partial class ayarlar : Form
    {
        public ayarlar()
        {
            InitializeComponent();
        }
        SonsuzFile file = new SonsuzFile(Environment.CurrentDirectory + "/settings.ini");
        private void Ayarlar_Load(object sender, EventArgs e)
        {
            if (dil().Contains("turkish"))
            {
                bunifuLabel1.Text = "Program Dili";
                bunifuLabel2.Text = "Program Teması";
                bunifuDropdown1.Items.Add("Arapça");
                bunifuDropdown1.Items.Add("İngilizce");
                bunifuDropdown1.Items.Add("Türkçe");
            }
            else if (dil().Contains("english"))
            {
                bunifuLabel1.Text = "Application Language";
                bunifuLabel2.Text = "Application Theme";
            }
            else if (dil().Contains("arabic"))
            {
                bunifuLabel1.Text = "";
                bunifuLabel2.Text = "";
            }
        }
        
        public string dil()
        {
            return file.Read("Application", "Language");
        }

        private void Timer1_Tick(object sender, EventArgs e)
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
