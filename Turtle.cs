using System;


namespace Simulation
{
    internal class Turtle : Herbivore
    {
        public Turtle(double x, double y, int gender, Simulation simulation, int visionRadius = 40, int contactRadius = 6, double Energy = 5, double Life = 40, int movementWay = 0, int movementDuration = 0, int pregnancyTime = 0) : base( x, y, gender, simulation, visionRadius, contactRadius, Energy, Life, movementWay, movementDuration, pregnancyTime) { }

    }
}
