using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp
{
    class Carnivore
    {
        private int Age = 0;
        public int CarnAge
        {
            get { return Age; }
            set
            {
                Age = value;
                OnChanged();
            }
        }
        public int HerbsEaten { get; set; }
        public bool Grown { get; set; }

        public event EventHandler OnChange = delegate { };

        public void Grow(bool herbgrown)
        {
            OnChange = (sender, e) => Console.WriteLine("Carnivore is growing");
            CarnAge++;
            if (herbgrown && HerbsEaten != 2)
            {
                OnChange = (sender, e) => Console.WriteLine("Carnivore ate the herbivore");
                OnChanged();
                HerbsEaten++;
                return;
            }
            if (HerbsEaten == 2)
            {
                Grown = true;
                OnChange = (sender, e) => Console.WriteLine($"Carnivore has grown. It grew {CarnAge} and it ate {HerbsEaten} plants");
                OnChanged();
            }
        }

        protected void OnChanged() => OnChange(this, EventArgs.Empty);
    }
}
