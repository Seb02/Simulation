using System;


namespace Simulation
{
    public class Dog : Carnivore
    {
        public Dog(double x, double y, int gender, Simulation simulation, int visionRadius = 40, int contactRadius = 6, double Energy = 15, double Life = 60, int movementWay = 0, int movementDuration = 0, int pregnancyTime = 0) : base(x, y, gender, simulation, visionRadius, contactRadius, Energy, Life, movementWay, movementDuration, pregnancyTime) { }
        public override void Update()
        {
            base.Update();
        }
    }
}
