//using System;


namespace Simulation
{

    public class Carnivore : Animal
    {
        public Carnivore(double x, double y, int gender, Simulation simulation,  int visionRadius, int contactRadius, double Energy , double Life,  int movementWay , int movementDuration, int pregnancyTime) : base(Colors.Brown, x, y,  gender, simulation, visionRadius, contactRadius, Energy, Life, movementWay, movementDuration, pregnancyTime) { }

        public override void Update()
        {
            base.Update();
            SeeFood();
            EatFood();
        }

        public void SeeFood()
        {
            
            foreach (SimulationObject obj in Sim.SeeAround(visionRadius, X, Y))
            {
                if (obj is Herbivore)
                {
                    X = obj.X;
                    Y = obj.Y;

                }
                if (obj is Meat) {
                    X = obj.X + 1;
                    Y = obj.Y - 1;
                }
            }
        }
        public void EatFood()
        {
           
            foreach(SimulationObject obj in Sim.InteractAround(contactRadius, X, Y))
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
