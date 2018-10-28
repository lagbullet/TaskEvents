using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsApp
{
    class Plant
    {
        private int Age = 0;
        public int PlantAge
        {
            get { return Age; }
            set
            {
                Age = value;
                if (value != 0)
                    OnChanged();
            }
        }
        public bool PlantGrown;

        public event EventHandler OnChange = delegate { };

        public void Grow()
        {
            if (PlantAge != 3)
            {
                OnChange = (sender, e) => Console.WriteLine("Plant is growing");
                PlantAge++;
            }
            if (PlantAge == 3)
            {
                PlantGrown = true;
                OnChange = (sender, e) => Console.WriteLine($"Plant has grown. It Grew {PlantAge}");
                OnChanged();
            }
        }

        protected void OnChanged() => OnChange(this, EventArgs.Empty);
    }
}
