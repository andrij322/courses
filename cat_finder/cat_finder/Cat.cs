using System.Drawing;

namespace cat_finder
{
    public class Cat
    {
        private int _intelligence;
        private int _energy;
        public string Breed { get; set; }
        public string BreedId { get; set; }
        public string Description { get; set; }
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
                if (value > 5)
                    _intelligence = 5;
                if (value < 0)
                    _intelligence = 0;


            }
        }
        public int Energy
        {
            get { return _energy; }
            set
            {
                _energy = value;
                if (value > 5)
                    _energy = 5;
                if (value < 0)
                    _energy = 0;
            }
        }
        public Bitmap BitMap { get; set; }
    }
}
