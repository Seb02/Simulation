using System;
using System.Security.Cryptography.X509Certificates;

namespace Simulation
{
    public abstract class LifeForm : SimulationObject
    {
        public LifeForm(Color color, double x, double y, Simulation simulation, int visionRadius, int contactRadius, double Energy, double Life) : base(color, x, y, simulation)
        {
            this.Energy = Energy;
            this.Life = Life;
            this.visionRadius = visionRadius;
            this.cocntactRaidus = contactRadius;
        }
        public double Energy; // on risque de passer à côté de energy = 0
        public double Life;
        public int visionRadius;
        public int cocntactRaidus;
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
        public List<SimulationObject> objectsAround;
        public virtual void SeeAround()
        {
            
            objectsAround = new List<SimulationObject>();
            objectsAround.Clear();

            foreach (SimulationObject obj in Sim.SendList())
            { 
                if ((visionRadius > obj.X - X && visionRadius > obj.Y - Y) || (visionRadius > X - obj.X && visionRadius > obj.Y - Y)|| (visionRadius > X - obj.X && visionRadius > Y - obj.Y) || (visionRadius > X - obj.X && visionRadius > obj.Y - Y))
                {
                    
                     objectsAround.Add(obj); 

                    
                }

            }

        }
    }
}
