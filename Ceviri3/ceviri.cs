using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using SonsuzAlgoritma;

namespace Ceviri3
{
    public partial class ceviri : Form
    {
        public ceviri()
        {
            InitializeComponent();
        }

        SonsuzFile ini = new SonsuzFile(Environment.CurrentDirectory + "/settings.ini");
        private const string finalURL =
        "https://translate.yandex.net/api/v1.5/tr.json/translate?lang=COUNTRYKEY&key=" +
        "trnsl.1.1.20180403T234128Z.5790699ba62f5d0f.ba2a4bb3f66abe408a4b0d973f443a7a649054ff";

        private static bool runningTwo = false;
        private static string FirstCharToUpper(string input)
        {

            return input.First().ToString().ToUpper() + input.Substring(1);

        }
        private string doPost(string URL, string postData)
        {
                try
                {

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

                    request.Method = WebRequestMethods.Http.Post;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Referer = "https://www.lifemcserver.com/";
                    request.UserAgent = "Mozilla/5.0";
                    request.Proxy = null;

                    var data = Encoding.UTF8.GetBytes(postData);

                    using (Stream stream = request.GetRequestStream())
                    {

                        stream.Write(data, 0, data.Length);
                        stream.Close();

                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (!response.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        return "Hata Oluştu: #" + response.StatusCode.ToString();
                    }

                    Stream streamResponse = response.GetResponseStream();
                    StreamReader streamRead = new StreamReader(streamResponse);

                    Char[] readBuff = new Char[256];
                    int count = streamRead.Read(readBuff, 0, 256);

                    String responseStr = "";

                    while (count > 0)
                    {
                        String outputData = new String(readBuff, 0, count);
                        responseStr = responseStr + outputData;
                        count = streamRead.Read(readBuff, 0, 256);
                    }

                    streamResponse.Close();
                    streamRead.Close();
                    response.Close();
                    request.Abort();

                    responseStr = responseStr.ToString().Trim();

                    if (responseStr.Replace(" ", "").Length < 1 || responseStr.ToLower().Contains("invalid") || responseStr.ToLower().Contains("error"))
                    {
                        return "Bilinmeyen hata oluştu :/";
                    }

                    return responseStr;
            }
            catch (WebException we)
            {

                return "Hata oluştu: #" + ((HttpWebResponse)we.Response).StatusCode.ToString();

            }
            catch (Exception)
            {

                return "Bilinmeyen hata oluştu :/";

            }
        }

        private void cevirme()
        {

            String countryKey = "";

            String countryKey1 = "";
            String countryKey2 = "";

            if (bunifuDropdown1.Text == "Türkçe" || bunifuDropdown1.Text == "Turkish" || bunifuDropdown1.Text == "التركية")
            {

                countryKey1 = "tr";

            }

            else if (bunifuDropdown1.Text == "İngilizce" || bunifuDropdown1.Text == "English" || bunifuDropdown1.Text == "اللغة الإنجليزية")
            {

                countryKey1 = "en";

            }

            else if (bunifuDropdown1.Text == "Almanca" || bunifuDropdown1.Text == "German" || bunifuDropdown1.Text == "الألمانية")
            {

                countryKey1 = "de";

            }

            else if (bunifuDropdown1.Text == "Rusça" || bunifuDropdown1.Text == "Russian" || bunifuDropdown1.Text == "الروسية")
            {

                countryKey1 = "ru";

            }

            else if (bunifuDropdown1.Text == "Fransızca" || bunifuDropdown1.Text == "French" || bunifuDropdown1.Text == "الفرنسية")
            {

                countryKey1 = "fr";

            }

            else if (bunifuDropdown1.Text == "Arapça" || bunifuDropdown1.Text == "Arabic" || bunifuDropdown1.Text == "العربية")
            {

                countryKey1 = "ar";

            }

            else if (bunifuDropdown1.Text == "Korece" || bunifuDropdown1.Text == "Korean" || bunifuDropdown1.Text == "الكورية")
            {

                countryKey1 = "ko";

            }

            else if (bunifuDropdown1.Text == "İspanyolca" || bunifuDropdown1.Text == "Spanish" || bunifuDropdown1.Text == "الإسبانية")
            {

                countryKey1 = "es";

            }

            /*-------------------------------------------------------------------------------------------------------------------*/

            if (bunifuDropdown2.Text == "Türkçe" || bunifuDropdown2.Text == "Turkish" || bunifuDropdown2.Text == "التركية")
            {

                countryKey2 = "tr";

            }

            else if (bunifuDropdown2.Text == "İngilizce" || bunifuDropdown2.Text == "English" || bunifuDropdown2.Text == "اللغة الإنجليزية")
            {

                countryKey2 = "en";

            }

            else if (bunifuDropdown2.Text == "Almanca" || bunifuDropdown2.Text == "German" || bunifuDropdown2.Text == "الألمانية")
            {

                countryKey2 = "de";

            }

            else if (bunifuDropdown2.Text == "Rusça" || bunifuDropdown2.Text == "Russian" || bunifuDropdown2.Text == "الروسية")
            {

                countryKey2 = "ru";

            }

            else if (bunifuDropdown2.Text == "Fransızca" || bunifuDropdown2.Text == "French" || bunifuDropdown2.Text == "الفرنسية")
            {

                countryKey2 = "fr";

            }

            else if (bunifuDropdown2.Text == "Arapça" || bunifuDropdown2.Text == "Arabic" || bunifuDropdown2.Text == "العربية")
            {

                countryKey2 = "ar";

            }

            else if (bunifuDropdown2.Text == "Korece" || bunifuDropdown2.Text == "Korean" || bunifuDropdown2.Text == "الكورية")
            {

                countryKey2 = "ko";

            }

            else if (bunifuDropdown2.Text == "İspanyolca" || bunifuDropdown2.Text == "Spanish" || bunifuDropdown2.Text == "الإسبانية")
            {

                countryKey2 = "es";

            }

            countryKey = countryKey1 + "-" + countryKey2;

            if (runningTwo)
            {
                return;
            }

            if (bunifuTextBox1.Text.Length < 1 || bunifuTextBox1.Text.Equals("Çevirilecek metin..."))
            {
                bunifuTextBox2.Text = "Çevirmek için metin girmeniz şarttır.";
                return;
            }

            runningTwo = true;

            bunifuTextBox2.Text = "Lütfen Bekleyin...";



            new Thread(() => {

                Thread.CurrentThread.IsBackground = true;

                this.Invoke(new MethodInvoker(() => bunifuTextBox2.Text = FirstCharToUpper(bunifuTextBox2.Text)));

                string resp = doPost(finalURL.Replace("COUNTRYKEY", countryKey + ""), "text=" + bunifuTextBox1.Text);

                if (resp.ToString().ToLower().Contains("badrequest"))
                {

                    this.Invoke(new MethodInvoker(() => bunifuTextBox2.Text = "Lütfen geçerli diller girin."));
                    runningTwo = false;
                    return;

                }

                if (resp.ToString().ToLower().Contains("hata"))
                {
                    this.Invoke(new MethodInvoker(() => bunifuTextBox2.Text = resp));
                    runningTwo = false;
                    return;
                }

                var json = JsonConvert.DeserializeObject<dynamic>(resp.Replace("[", "").Replace("]", ""));
                string tr = json.text;

                tr = FirstCharToUpper(tr);

                this.Invoke(new MethodInvoker(() => bunifuTextBox2.Text = tr));

                this.Invoke(new MethodInvoker(() => runningTwo = false));

            }).Start();

        }

        private void BunifuDropdown2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
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

        private void BunifuTextBox1_OnIconRightClick(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = Clipboard.GetText();
        }

        private void BunifuTextBox2_OnIconRightClick(object sender, EventArgs e)
        {
            string son = bunifuTextBox2.Text;
            Clipboard.SetText(son);
        }

        private void BunifuTextBox1_DoubleClick(object sender, EventArgs e)
        {
            bunifuTextBox1.Clear();
        }

        private void BunifuImageButton2_Click(object sender, EventArgs e)
        {
            string degis = bunifuDropdown1.Text;
            bunifuDropdown1.Text = bunifuDropdown2.Text;
            bunifuDropdown2.Text = degis;
        }

        private void BunifuImageButton3_Click(object sender, EventArgs e)
        {
            kontrol = InternetKontrol();
            if(kontrol == true)
            {
                cevirme();
            }
            else
            {
                bunifuTextBox2.Text = "İnternet bağlantınız bulunmuyor.Lütfen daha sonra tekrar deneyiniz.";
            }
        }

        private void BunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            kontrol = InternetKontrol();
            if (e.KeyCode == Keys.Enter)
            {
                if (kontrol == true)
                {
                    cevirme();
                }
                else
                {
                    bunifuTextBox2.Text = "İnternet bağlantınız bulunmuyor.Lütfen daha sonra tekrar deneyiniz.";
                }
            }
        }

        public void yazi()
        {

            string dil = ini.Read("Application", "Language");
            if (dil.Contains("turkish"))
            {

                bunifuTextBox1.Text = "Çevrilecek Metin";
                bunifuTextBox2.Text = "Çevrilen Metin";
                bunifuDropdown1.Text = "Türkçe";
                bunifuDropdown2.Text = "İngilizce";
                bunifuDropdown1.Items.Add("Arapça");
                bunifuDropdown1.Items.Add("Almanca");
                bunifuDropdown1.Items.Add("Fransızca");
                bunifuDropdown1.Items.Add("İngilizce");
                bunifuDropdown1.Items.Add("İspanyolca");
                bunifuDropdown1.Items.Add("Korece");
                bunifuDropdown1.Items.Add("Rusça");
                bunifuDropdown1.Items.Add("Türkçe");
                bunifuDropdown2.Items.Add("Arapça");
                bunifuDropdown2.Items.Add("Almanca");
                bunifuDropdown2.Items.Add("Fransızca");
                bunifuDropdown2.Items.Add("İngilizce");
                bunifuDropdown2.Items.Add("İspanyolca");
                bunifuDropdown2.Items.Add("Korece");
                bunifuDropdown2.Items.Add("Rusça");
                bunifuDropdown2.Items.Add("Türkçe");
                label1.Text = "Sonsuz";
                label2.Text = "Çeviri";
                bunifuToolTip1.SetToolTipTitle(bunifuTextBox1, "Çevrilecek metin");
                bunifuToolTip1.SetToolTip(bunifuTextBox1, "Çevirmek istediğiniz kelimeyi buraya yazın \nya da sağdaki yapıştır butonunu kullanın");
                bunifuToolTip1.SetToolTipTitle(bunifuTextBox2, "Çevrilen metin");
                bunifuToolTip1.SetToolTip(bunifuTextBox2, "Çevrilen metnin gösterildiği yerdir.sağdan kopyalayabilirsiniz.");
                bunifuToolTip1.SetToolTipTitle(bunifuDropdown1, "Bu Dilden");
                bunifuToolTip1.SetToolTip(bunifuDropdown1, "Çevrilicek dil burdan seçilir.");
                bunifuToolTip1.SetToolTipTitle(bunifuDropdown2, "Şu Dile");
                bunifuToolTip1.SetToolTip(bunifuDropdown2, "Çevrilen dil buradan seçilir.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton1, "Geri");
                bunifuToolTip1.SetToolTip(bunifuImageButton1, "Bastığınızda geri döner");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton2, "Değiştir");
                bunifuToolTip1.SetToolTip(bunifuImageButton2, "Dillerin yerini değiştirir.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton3, "Çevir");
                bunifuToolTip1.SetToolTip(bunifuImageButton3, "Bastığınızda çevirir.");

            }
            else if (dil.Contains("english"))
            {

                bunifuTextBox1.Text = "The Text To Be Translated";
                bunifuTextBox2.Text = "Translated Text";
                bunifuDropdown1.Text = "English";
                bunifuDropdown2.Text = "Turkish";
                bunifuDropdown1.Items.Add("Arabic");
                bunifuDropdown1.Items.Add("German");
                bunifuDropdown1.Items.Add("French");
                bunifuDropdown1.Items.Add("English");
                bunifuDropdown1.Items.Add("Spanish");
                bunifuDropdown1.Items.Add("Korean");
                bunifuDropdown1.Items.Add("Russian");
                bunifuDropdown1.Items.Add("Turkish");
                bunifuDropdown2.Items.Add("Arabic");
                bunifuDropdown2.Items.Add("German");
                bunifuDropdown2.Items.Add("French");
                bunifuDropdown2.Items.Add("English");
                bunifuDropdown2.Items.Add("Spanish");
                bunifuDropdown2.Items.Add("Korean");
                bunifuDropdown2.Items.Add("Russian");
                bunifuDropdown2.Items.Add("Turkish");
                label1.Text = "Infinite";
                label2.Text = "Translation";
                bunifuToolTip1.SetToolTipTitle(bunifuTextBox1, "Text To Translate");
                bunifuToolTip1.SetToolTip(bunifuTextBox1, "Type the text you want to translate\nhere or paste it from the right button.");
                bunifuToolTip1.SetToolTipTitle(bunifuTextBox2, "Translated Text");
                bunifuToolTip1.SetToolTip(bunifuTextBox2, "Where the translated text is.If you want to read it,\ncopy it from the button on the right.");
                bunifuToolTip1.SetToolTipTitle(bunifuDropdown1, "From this language");
                bunifuToolTip1.SetToolTip(bunifuDropdown1, "The language to translate is selected from here.");
                bunifuToolTip1.SetToolTipTitle(bunifuDropdown2, "This Language");
                bunifuToolTip1.SetToolTip(bunifuDropdown2, "The language to translate is selected here.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton1, "Back");
                bunifuToolTip1.SetToolTip(bunifuImageButton1, "When you press it, it returns.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton2, "Replace");
                bunifuToolTip1.SetToolTip(bunifuImageButton2, "Move languages.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton3, "Translate");
                bunifuToolTip1.SetToolTip(bunifuImageButton3, "When you press it, it translates.");

            }
            else if (dil.Contains("arabic"))
            {

                bunifuTextBox1.Text = "النص المراد ترجمته";
                bunifuTextBox2.Text = "ترجمة النص";
                bunifuDropdown1.Text = "العربية";
                bunifuDropdown2.Text = "التركية";
                bunifuDropdown1.Items.Add("العربية");
                bunifuDropdown1.Items.Add("الألمانية");
                bunifuDropdown1.Items.Add("الفرنسية");
                bunifuDropdown1.Items.Add("اللغة الإنجليزية");
                bunifuDropdown1.Items.Add("الإسبانية");
                bunifuDropdown1.Items.Add("الكورية");
                bunifuDropdown1.Items.Add("الروسية");
                bunifuDropdown1.Items.Add("التركية");
                bunifuDropdown2.Items.Add("العربية");
                bunifuDropdown2.Items.Add("الألمانية");
                bunifuDropdown2.Items.Add("الفرنسية");
                bunifuDropdown2.Items.Add("اللغة الإنجليزية");
                bunifuDropdown2.Items.Add("الإسبانية");
                bunifuDropdown2.Items.Add("الكورية");
                bunifuDropdown2.Items.Add("الروسية");
                bunifuDropdown2.Items.Add("التركية");
                label1.Text = "اللانهائية";
                label2.Text = "الترجمة";
                bunifuToolTip1.SetToolTipTitle(bunifuTextBox1, "النص المراد ترجمته");
                bunifuToolTip1.SetToolTip(bunifuTextBox1, "اكتب الكلمة التي تريد ترجمتها ، أو استخدام معجون زر على اليمين");
                bunifuToolTip1.SetToolTipTitle(bunifuTextBox2, "ترجمة النص");
                bunifuToolTip1.SetToolTip(bunifuTextBox2, "النص المترجم هو مبين.يمكنك نسخ من الحق.");
                bunifuToolTip1.SetToolTipTitle(bunifuDropdown1, "من هذه اللغة");
                bunifuToolTip1.SetToolTip(bunifuDropdown1, "هنا لغة للترجمة هو المحدد.");
                bunifuToolTip1.SetToolTipTitle(bunifuDropdown2, "لغة الماء");
                bunifuToolTip1.SetToolTip(bunifuDropdown2, "ترجمة اللغة هي المحدد هنا.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton1, "مرة أخرى");
                bunifuToolTip1.SetToolTip(bunifuImageButton1, "يتحول مرة أخرى عند الضغط");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton2, "تغيير");
                bunifuToolTip1.SetToolTip(bunifuImageButton2, "مكان اللغة التغييرات.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton3, "الوجه");
                bunifuToolTip1.SetToolTip(bunifuImageButton3, "عند الضغط على المنعطفات.");

            }
            else
            {

                bunifuTextBox1.Text = "Çevrilecek Metin";
                bunifuTextBox2.Text = "Çevrilen Metin";
                bunifuDropdown1.Text = "Türkçe";
                bunifuDropdown2.Text = "İngilizce";
                bunifuDropdown1.Items.Add("Arapça");
                bunifuDropdown1.Items.Add("Almanca");
                bunifuDropdown1.Items.Add("Fransızca");
                bunifuDropdown1.Items.Add("İngilizce");
                bunifuDropdown1.Items.Add("İspanyolca");
                bunifuDropdown1.Items.Add("Korece");
                bunifuDropdown1.Items.Add("Rusça");
                bunifuDropdown1.Items.Add("Türkçe");
                bunifuDropdown2.Items.Add("Arapça");
                bunifuDropdown2.Items.Add("Almanca");
                bunifuDropdown2.Items.Add("Fransızca");
                bunifuDropdown2.Items.Add("İngilizce");
                bunifuDropdown2.Items.Add("İspanyolca");
                bunifuDropdown2.Items.Add("Korece");
                bunifuDropdown2.Items.Add("Rusça");
                bunifuDropdown2.Items.Add("Türkçe");
                label1.Text = "Sonsuz";
                label2.Text = "Çeviri";
                bunifuToolTip1.SetToolTipTitle(bunifuTextBox1, "Çevrilecek metin");
                bunifuToolTip1.SetToolTip(bunifuTextBox1, "Çevirmek istediğiniz kelimeyi buraya yazın \nya da sağdaki yapıştır butonunu kullanın");
                bunifuToolTip1.SetToolTipTitle(bunifuTextBox2, "Çevrilen metin");
                bunifuToolTip1.SetToolTip(bunifuTextBox2, "Çevrilen metnin gösterildiği yerdir.sağdan kopyalayabilirsiniz.");
                bunifuToolTip1.SetToolTipTitle(bunifuDropdown1, "Bu Dilden");
                bunifuToolTip1.SetToolTip(bunifuDropdown1, "Çevrilicek dil burdan seçilir.");
                bunifuToolTip1.SetToolTipTitle(bunifuDropdown2, "Şu Dile");
                bunifuToolTip1.SetToolTip(bunifuDropdown2, "Çevrilen dil buradan seçilir.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton1, "Geri");
                bunifuToolTip1.SetToolTip(bunifuImageButton1, "Bastığınızda geri döner");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton2, "Değiştir");
                bunifuToolTip1.SetToolTip(bunifuImageButton2, "Dillerin yerini değiştirir.");
                bunifuToolTip1.SetToolTipTitle(bunifuImageButton3, "Çevir");
                bunifuToolTip1.SetToolTip(bunifuImageButton3, "Bastığınızda çevirir.");
            }
        }

        private void Ceviri_Load(object sender, EventArgs e)
        {
            yazi();
            if(ini.Read("Application","Background").Contains("dark"))
            {
                this.BackColor = ColorTranslator.FromHtml("#3E3E42");
                bunifuTextBox1.FillColor = ColorTranslator.FromHtml("#3E3E42");
                bunifuTextBox2.FillColor = ColorTranslator.FromHtml("#3E3E42");
            }
            else
            {
                this.BackColor = Color.White;
                bunifuTextBox1.FillColor = Color.White;
                bunifuTextBox2.FillColor = Color.White;
            }
            timer2.Start();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if(this.Opacity == 1)
            {
                timer2.Stop();
            }
            else
            {
                this.Opacity += 0.025;
            }
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

        private void Ceviri_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        bool kontrol;
        public static bool InternetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
