using System;
namespace Simulation
{

	public class Herbivore : Animal
	{
		public Herbivore(double x, double y, int gender, Simulation simulation, int visionRadius, int contactRadius, double Energy, double Life, int movementWay, int movementDuration, int pregnancyTime) : base(Colors.Blue, x, y, gender, simulation, visionRadius, contactRadius, Energy, Life, movementWay, movementDuration, pregnancyTime) { }


        public override void Update()
        {
            base.Update();
            SeePlant();
            Eat();
        }
        public void SeePlant()
        {
            
            foreach (SimulationObject obj in Sim.SeeAround(visionRadius, X, Y))
            {
                if (obj is Plant)
                {
                    X = obj.X;
                    Y = obj.Y;

                }
            }
        }
        public void Eat()
        {
            
            foreach (SimulationObject obj in Sim.InteractAround(contactRadius, X, Y))
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