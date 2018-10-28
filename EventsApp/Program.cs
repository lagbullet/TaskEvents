using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Plant plant = new Plant();
            Herbivore herbivore = new Herbivore();
            Carnivore carnivore = new Carnivore();
            while (true)
            {
                if (!plant.PlantGrown)
                    plant.Grow();
                else
                {
                    plant.PlantAge = 0;
                    plant.PlantGrown = false;
                }
                if (!herbivore.Grown)
                    herbivore.Grow(plant.PlantGrown);
                else
                {
                    herbivore.HerbAge = 0;
                    herbivore.Grown = false;
                    herbivore.PlantsEaten = 0;
                }
                if (!carnivore.Grown)
                    carnivore.Grow(herbivore.Grown);
                else
                    break;
                Thread.Sleep(500);
            }
            Console.ReadKey(false);
        }
    }
}
