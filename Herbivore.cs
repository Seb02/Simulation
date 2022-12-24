using System;
namespace Simulation
{

	public class Herbivore : Animal
	{
		public Herbivore(double x, double y, int gender, Simulation simulation, int visionRadius = 40, int contactRadius = 6, double Energy = 5, double Life = 40, int movementWay = 0, int movementDuration = 0, int pregnancyTime = 0) : base(Colors.Blue, x, y, gender, simulation, visionRadius, contactRadius, Energy, Life, movementWay, movementDuration, pregnancyTime) { }

        public override void SeeAround()
        {
            base.SeeAround();
            foreach (SimulationObject obj in objectsAround)
            {
                if (obj is Plant)
                {
                    X = obj.X;
                    Y = obj.Y;

                }
            }
        }
        public override void InterractAround()
        {
            base.InterractAround();
            foreach (SimulationObject obj in objectsAround)
            {
                if (obj is Plant)
                {
                    Energy += 30;
                    Sim.Del(obj);

                }
                
            }
        }

    }
}