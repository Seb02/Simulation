using System;
namespace Simulation
{
    public class OrganicWaste : SimulationObject
    {
        public OrganicWaste(double x, double y, Simulation simulation, double Life) : base(Colors.DarkKhaki, x, y, simulation)
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
