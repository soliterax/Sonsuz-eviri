using System;
using System.Drawing;
using System.Windows.Forms;
using SonsuzAlgoritma;

namespace Ceviri3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        SonsuzFile file = new SonsuzFile(Environment.CurrentDirectory + "/settings.ini");
        private void Form1_Load(object sender, EventArgs e)
        {
            if (file.Read("Application", "Background").Contains("dark"))
            {
                this.BackColor = ColorTranslator.FromHtml("#3E3E42");
            }
            else
            {
                this.BackColor = Color.White;
            }
            if(file.Read("Application","Language").Contains("turkish"))
            {
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton1, "Kapat");
                bunifuToolTip1.SetToolTip(bunifuImageButton1, "Bastığınızda kapatır.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton2, "Oyun");
                bunifuToolTip1.SetToolTip(bunifuImageButton2, "Bastığınızda çeviriye özel kodlanmış oyunu açar.(Yapım Aşamasında)");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton3, "Anasayfa");
                bunifuToolTip1.SetToolTip(bunifuImageButton3, "Tıkladığınızda çeviri yerini açar.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton4, "Yapımcılar");
                bunifuToolTip1.SetToolTip(bunifuImageButton4, "Tıkladığınızda Programın yapımcılarının\ngösterildiği yere gidersiniz.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton5, "Ayarlar");
                bunifuToolTip1.SetToolTip(bunifuImageButton5, "Programın ayarlarına gider.");
            }
            else if (file.Read("Application", "Language").Contains("english"))
            {
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton1, "Close");
                bunifuToolTip1.SetToolTip(bunifuImageButton1, "The program closes.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton2, "Game");
                bunifuToolTip1.SetToolTip(bunifuImageButton2, "Custom coded game opens up when you press A to turn.(Under Construction)");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton3, "Homepage");
                bunifuToolTip1.SetToolTip(bunifuImageButton3, "Clicking opens the location of the translation.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton4, "Producers");
                bunifuToolTip1.SetToolTip(bunifuImageButton4, "You'll get shown where clicking the program's producers.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton5, "Settings");
                bunifuToolTip1.SetToolTip(bunifuImageButton5, "Goes to the settings of the program.");
            }
            else if (file.Read("Application", "Language").Contains("arabic"))
            {
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton1, "قريب");
                bunifuToolTip1.SetToolTip(bunifuImageButton1, "إغلاق البرنامج.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton2, "لعبة");
                bunifuToolTip1.SetToolTip(bunifuImageButton2, "مخصص مشفرة اللعبة يفتح عند الضغط على تشغيل.(تحت الإنشاء)");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton3, "الصفحة الرئيسية");
                bunifuToolTip1.SetToolTip(bunifuImageButton3, "النقر فوق فتح موقع الترجمة.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton4, "المنتجين");
                bunifuToolTip1.SetToolTip(bunifuImageButton4, "ستحصل حيث أظهرت النقر على البرنامج المنتجين.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton5, "الإعدادات");
                bunifuToolTip1.SetToolTip(bunifuImageButton5, "يذهب إلى إعدادات البرنامج.");
            }
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

        private void BunifuImageButton2_Click(object sender, EventArgs e)
        {
            game g = new game();
            g.Visible = true;
            this.Close();
        }
    }
}
