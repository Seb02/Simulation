using System;
namespace Simulation
{
    public class Meat : SimulationObject
    {
        public Meat(double x, double y, Simulation simulation, double Life) : base(Colors.Red, x, y, simulation)
        {

            this.Life = Life;
        }

        public double Life;

        public override void Update()
        {
            LooseLife();
        }
        public void LooseLife()
        {
            if (Life > 1)
            {
                Life -= 1;
            }



        }

    }
}