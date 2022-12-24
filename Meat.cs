using System;
namespace Simulation
{
    public class Meat : SimulationObject
    {
        public Meat(double x, double y, Simulation simulation, double Life = 25) : base(Colors.Red, x, y, simulation)
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
        public void MeatToOrganic()
        {
            if (Life < 1) {
                OrganicWaste waste = new OrganicWaste(X, Y, Sim);
                Sim.Add(waste);
                Sim.Del(this);

            }
        }

    }
}