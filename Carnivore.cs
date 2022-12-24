//using System;


namespace Simulation
{

    public class Carnivore : Animal
    {
        public Carnivore(double x, double y, int gender, Simulation simulation,  int visionRadius = 10, int contactRadius = 6, double Energy = 15, double Life = 60, int movementWay = 0, int pregnancyTime = 0) : base(Colors.Brown, x, y,  gender, simulation, visionRadius, contactRadius, Energy, Life, movementWay, pregnancyTime) { }


        public override void SeeAround()
        {
            base.SeeAround();
            foreach (SimulationObject obj in objectsAround)
            {
                if (obj is Herbivore)
                {
                    X = obj.X;
                    Y = obj.Y;

                }
            }
        }
        public override void InterractAround()
        {
            base.InterractAround();
            foreach(SimulationObject obj in objectsAround)
            {
                if(obj is Herbivore)
                {
                    Herbivore prey = obj as Herbivore;
                    prey.Life -= 50;

                }
                if (obj is Meat)
                {
                    Energy += 100;
                    Sim.Del(obj);
                }
            }
        }
    }
}
