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

        Color light = Color.Green;
        Color dark = Color.Red;
        SonsuzFile file = new SonsuzFile(Environment.CurrentDirectory + "/settings.ini");
        SonsuzLock sifre = new SonsuzLock("b0mb@can", 4);

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            timer2.Start();
            if (dil().Contains("turkish"))
            {
                bunifuLabel1.Text = "Program Dili";
                bunifuLabel2.Text = "Program Teması";
                bunifuDropdown1.Text = "Türkçe";
                bunifuDropdown2.Items.Add("Açık");
                bunifuDropdown2.Items.Add("Koyu");
                bunifuToolTip1.SetToolTipTitle(this.bunifuImageButton1, "Kaydet");
                if (file.Read("Application", "Background").Contains("light"))
                {
                    bunifuDropdown2.Text = "Light";
                    this.BackColor = Color.White;
                    bunifuLabel1.ForeColor = Color.Blue;
                    bunifuLabel2.ForeColor = Color.Blue;
                    bunifuDropdown1.Color = light;
                    bunifuDropdown1.ForeColor = light;
                    bunifuDropdown1.IndicatorColor = light;
                    bunifuDropdown1.ItemBorderColor = light;
                    bunifuDropdown1.ItemForeColor = light;
                    bunifuDropdown2.Color = light;
                    bunifuDropdown2.ForeColor = light;
                    bunifuDropdown2.IndicatorColor = light;
                    bunifuDropdown2.ItemBorderColor = light;
                    bunifuDropdown2.ItemForeColor = light;
                }
                else
                {
                    bunifuDropdown2.Text = "Dark";
                    this.BackColor = ColorTranslator.FromHtml("#3E3E42");
                    bunifuLabel1.ForeColor = Color.Red;
                    bunifuLabel2.ForeColor = Color.Red;
                }
            }
            else if (dil().Contains("english"))
            {
                bunifuLabel1.Text = "Application Language";
                bunifuLabel2.Text = "Application Theme";
                bunifuDropdown1.Text = "English";
                bunifuToolTip1.SetToolTipTitle(this.bunifuImageButton1, "Save");
                if (sifre.sifrecoz(file.Read("Application", "Background")).Contains("light"))
                {
                    bunifuDropdown2.Text = "Light";
                }
                else
                {
                    bunifuDropdown2.Text = "Dark";
                }
                bunifuDropdown2.Items.Add("Light");
                bunifuDropdown2.Items.Add("Dark");
                
            }
            else if (dil().Contains("arabic"))
            {
                bunifuLabel1.Text = "";
                bunifuLabel2.Text = "";
            }
            else
            {
                bunifuLabel1.Text = "Program Dili";
                bunifuLabel2.Text = "Program Teması";
                bunifuDropdown1.Text = "Türkçe";
                bunifuDropdown2.Items.Add("Açık");
                bunifuDropdown2.Items.Add("Koyu");
                bunifuDropdown2.Text = "Siyah";
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

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Stop();
                if (bunifuDropdown1.Text == "İngilizce" || bunifuDropdown1.Text == "English" || bunifuDropdown1.Text == "اللغة الإنجليزية")
                {
                    file.Write("Application", "Language", "english");
                }
                else if (bunifuDropdown1.Text == "Arapça" || bunifuDropdown1.Text == "Arabic" || bunifuDropdown1.Text == "العربية")
                {
                    file.Write("Application", "Language", "arabic");
                }
                else if (bunifuDropdown1.Text == "Türkçe" || bunifuDropdown1.Text == "Turkish" || bunifuDropdown1.Text == "التركية")
                {
                    file.Write("Application", "Language", "turkish");
                }
                else
                {
                    file.Write("Application", "Language", "turkish");
                }

                if (bunifuDropdown2.Text == "Açık" || bunifuDropdown2.Text == "Light" || bunifuDropdown2.Text == "الضوء")
                {
                    file.Write("Application", "Background", sifre.sifrele("light"));
                }
                else if (bunifuDropdown2.Text == "Koyu" || bunifuDropdown2.Text == "Dark" || bunifuDropdown2.Text == "الظلام")
                {
                    file.Write("Application", "Background", sifre.sifrele("dark"));
                }
                else
                {
                    file.Write("Application", "Background", sifre.sifrele("dark"));
                }
                timer1.Start();
            }
            else
            {
                if (bunifuDropdown1.Text == "İngilizce" || bunifuDropdown1.Text == "English" || bunifuDropdown1.Text == "اللغة الإنجليزية")
                {
                    file.Write("Application", "Language", "english");
                }
                else if (bunifuDropdown1.Text == "Arapça" || bunifuDropdown1.Text == "Arabic" || bunifuDropdown1.Text == "العربية")
                {
                    file.Write("Application", "Language", "arabic");
                }
                else if (bunifuDropdown1.Text == "Türkçe" || bunifuDropdown1.Text == "Turkish" || bunifuDropdown1.Text == "التركية")
                {
                    file.Write("Application", "Language", "turkish");
                }
                else
                {
                    file.Write("Application", "Language", "turkish");
                }

                if (bunifuDropdown2.Text == "Açık" || bunifuDropdown2.Text == "Light" || bunifuDropdown2.Text == "الضوء")
                {
                    file.Write("Application", "Background", sifre.sifrele("light"));
                }
                else if (bunifuDropdown2.Text == "Koyu" || bunifuDropdown2.Text == "Dark" || bunifuDropdown2.Text == "الظلام")
                {
                    file.Write("Application", "Background", sifre.sifrele("dark"));
                }
                else
                {
                    file.Write("Application", "Background", sifre.sifrele("dark"));
                }
                timer1.Start();
            }
        }
    }
}
