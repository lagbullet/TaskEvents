using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp
{
    class Herbivore
    {
        private int Age = 0;
        public int HerbAge
        {
            get { return Age; }
            set
            {
                Age = value;
                if (value != 0)
                    OnChanged();
            }
        }
        public int PlantsEaten { get; set; }
        public bool Grown { get; set; }

        public event EventHandler OnChange = delegate { };

        public void Grow(bool plantgrown)
        {
            OnChange = (sender, e) => Console.WriteLine("Herbivore is growing");
            HerbAge++;
            if (plantgrown && PlantsEaten != 2)
            {
                OnChange = (sender, e) => Console.WriteLine("Herbivore ate the plant");
                OnChanged();
                PlantsEaten++;
                return;
            }
            if (PlantsEaten == 2)
            {
                Grown = true;
                OnChange = (sender, e) => Console.WriteLine($"Herbivore has grown. It grew {HerbAge} and it ate {PlantsEaten} plants");
                OnChanged();
            }
        }

        protected void OnChanged() => OnChange(this, EventArgs.Empty);
    }
}
