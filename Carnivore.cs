//using System;


namespace Simulation
{

    public class Carnivore : Animal
    {
        public Carnivore(double x, double y, Simulation simulation, int visionRadius = 10,  int contactRadius = 6, double Energy = 15, double Life = 20) : base(Colors.Brown, x, y, simulation, visionRadius, contactRadius, Energy, Life) { }

    }
}
