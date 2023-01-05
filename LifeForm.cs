
using System;


namespace Simulation
{
    public abstract class LifeForm : SimulationObject
    {
        
        public LifeForm(Color color, double x, double y, Simulation simulation, int visionRadius, int contactRadius, double Energy, double Life) : base(color, x, y, simulation)
        {
            this.Energy = Energy;
            this.Life = Life;
            this.visionRadius = visionRadius;
            this.contactRadius = contactRadius;
        }
        public double Energy; // on risque de passer à côté de energy = 0
        public double Life;
        public int visionRadius;
        public int contactRadius;
        public override void Update()
        {
            LooseEnergy();
        }
        public void LooseEnergy()
        {
            if (Energy > 1)
            {
                Energy -= 1;
            }
            else
            {
                GetEnergy();
            }


        }
        public virtual void GetEnergy()
        {
            if (Life > 1)
            {
                Energy += 1;
                Life -= 1;
            }

        }
        
    }
}
