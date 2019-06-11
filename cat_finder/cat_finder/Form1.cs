using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace cat_finder
{
    public partial class Form1 : Form
    {

        private Cat[] _cats;
        private Connector _connector;
        private int _size;
        private dynamic _breeds;


        private void InitCats()
        {
            _cats = new Cat[_size];
            for (int i = 0; i < _size; i++)
                _cats[i] = new Cat();
        }


        public Form1()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            InitBreeds();
            InitConnection();
            
        }


        private void InitializeRandomCat(object sender, EventArgs eventArgs)
        {
            var rand = new Random();
            var randNumber = rand.Next(20);
            listBox1.SetSelected(randNumber, true);
            ShowInfo(_cats[randNumber]);
        }


        private void ShowInfo(Cat cat)
        {
            richTextBox1.Text = $"Cat intelligence - {cat.Intelligence}\nCat energy - {cat.Energy}\nCat description - {cat.Description}";
            pictureBox1.Image = cat.BitMap;
        }


        private void initListBox()
        {
            for(int i = 0;i< _size; i++)
                listBox1.Items.Add(_cats[i].Breed);
        }


        private async void InitConnection()
        {
            button1.Enabled = false;
            await Task.Run(()=>Parallel.For(0, _size, downloadBreeds));
            button1.Enabled = true;
            initListBox();
        }


        private void InitBreeds()
        {
            _connector = new Connector("https://api.thecatapi.com/v1/breeds");
            var json = _connector.getResponse();
            _breeds = JsonConvert.DeserializeObject(json);
            _size = _breeds.Count;
            InitCats();
        }


        private void downloadBreeds(int i)
        {
            _cats[i] = new Cat();
            _cats[i].Breed = _breeds[i].name;
            _cats[i].BreedId = _breeds[i].id;
            _cats[i].Intelligence = _breeds[i].intelligence;
            _cats[i].Energy = _breeds[i].energy_level;
            _cats[i].Description = _breeds[i].description;


            _connector.RequestStr = "https://api.thecatapi.com/v1/images/search?breed_ids=" + _cats[i].BreedId;
            var json = _connector.getResponse();
            dynamic breed = JsonConvert.DeserializeObject(json);
            var fileName = "../Images/" + Path.GetFileName(breed[0].url.ToString());
            using (var wc = new WebClient())
            {
                wc.DownloadFile(breed[0].url.ToString(), fileName);
                _cats[i].BitMap = new Bitmap(Image.FromFile(fileName), new Size(760, 632));
            }
        }
        

        private void catSelected(object sender,EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            ShowInfo(_cats[index]);
        }
    }
}
