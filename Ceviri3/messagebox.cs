using SonsuzAlgoritma;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ceviri3
{
    public partial class messagebox : Form
    {
        public messagebox(string ad)
        {
            InitializeComponent();
            if (ad.Contains("Mustafa"))
            {

                label1.Text = "Mustafa Öncel";
                label2.Text = "!💲мυѕтαғα öɴcel#0001";
                label8.Text = "LifeMCServer";
                label4.Text = "Kodlama ve Çeviri Sistemi";

            }
            else if (ad.Contains("Umut"))
            {

                label1.Text = "Umut Özercan";
                label2.Text = "!💲вoмвαcαɴ#9409";
                label8.Text = "The Infinity Studios";
                label4.Text = "Kodlama,Tasarım,güncelleme,Çeviri Sistemi";

            }
        }

        private void Messagebox_Load(object sender, EventArgs e)
        {
            SonsuzFile file = new SonsuzFile(Environment.CurrentDirectory + "/settings.ini");
            if (file.Read("Application","Background").Contains("dark"))
            {
                this.BackColor = ColorTranslator.FromHtml("#3E3E42");
            }
            else
            {
                this.BackColor = Color.White;
            }
            if(file.Read("Application","Language").Contains("turkish"))
            {
                label5.Text = "Adı Soyadı:";
                label6.Text = "Discord Adresi:";
                label7.Text = "Facebook Adresi:";
                label3.Text = "Yardım Ettiği Hususlar:";
            }
            else if(file.Read("Application", "Language").Contains("english"))
            {
                label5.Text = "Name Surname:";
                label6.Text = "Discord Address:";
                label7.Text = "Facebook Adress:";
                label3.Text = "Helping matters:";
            }
            else if (file.Read("Application", "Language").Contains("arabic"))
            {
                label5.Text = "اسم اللقب" + ":";
                label6.Text = "الفتنة عنوان" + ":";
                label7.Text = "Facebook عنوان" + ":";
                label3.Text = "يساعد" + ":";
            }
            else
            {
                label5.Text = "Adı Soyadı:";
                label6.Text = "Discord Adresi:";
                label7.Text = "Facebook Adresi:";
                label3.Text = "Yardım Ettiği Hususlar:";
            }
            timer2.Start();
        }

        private void BunifuButton1_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Stop();
                timer1.Start();
            }
            else
            {
                timer1.Start();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 0)
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
