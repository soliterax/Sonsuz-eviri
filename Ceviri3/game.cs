using System;
using System.Windows.Forms;

namespace Ceviri3
{
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
        }

        private void BunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Visible = true;
            this.Close();
        }
    }
}
