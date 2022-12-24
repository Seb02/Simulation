using System;
namespace Simulation
{

	public class Herbivore : Animal
	{
		public Herbivore(double x, double y, Simulation simulation, int visionRadius = 10, int contactRadius = 6, double Energy = 5, double Life = 40) : base(Colors.Blue, x, y, simulation, visionRadius, contactRadius, Energy, Life) { }

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