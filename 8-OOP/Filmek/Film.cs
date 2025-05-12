namespace Filmek
{
    internal class Film
    {
        private string cim;
        private int ev;
        private string mufaj;
        private double imdb;
        private int nezok;

        public Film(string cim, int ev, string mufaj, double imdb, int nezok)
        {
            this.cim = cim;
            this.ev = ev;
            this.mufaj = mufaj;
            this.imdb = imdb;
            this.nezok = nezok;
        }

        public string Cim { get => this.cim; }

        public string Ev
        { 
            get
            {
                if (this.ev < 2019)
                {
                    return $"{this.ev} BC";
                }
                else
                {
                    return $"{this.ev} AC";
                }
            }
        }
    }
}
