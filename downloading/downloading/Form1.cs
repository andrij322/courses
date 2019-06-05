using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace downloading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(@"https://progomel.by/wp-content/uploads/2019/04/1243325.jpg", "1243325.jpg");
                }
            }
            catch(WebException w)
            {
                MessageBox.Show(w.Message);
            }
            InitializeComponent();
        }

        private void Flex(object sender, EventArgs e)
        {
            try
            {
                BackgroundImage = new Bitmap("1243325.jpg");
            }
            catch (FileNotFoundException f)
            {
                MessageBox.Show(f.Message);
            }
        }
    }
}
