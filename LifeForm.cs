
using System;


namespace Simulation
{
    public abstract class LifeForm : SimulationObject
    {
        LifeForm lifeForm;
        public LifeForm LifePub { get { return lifeForm; } }
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
        public List<SimulationObject> objectsAround;
        public List<SimulationObject> SeeAround()
        {
            objectsAround.Clear();
            foreach (SimulationObject obj in Sim.SendList())
            {
                //if ((visionRadius > obj.X - X && visionRadius > obj.Y - Y) || (visionRadius > X - obj.X && visionRadius > obj.Y - Y)|| (visionRadius > X - obj.X && visionRadius > Y - obj.Y) || (visionRadius > X - obj.X && visionRadius > obj.Y - Y))
                if (visionRadius > Math.Abs(obj.X - X) && visionRadius > Math.Abs(obj.Y - Y))
                {

                    objectsAround.Add(obj);


                }

            }
            return objectsAround;
        }
        
        public List<SimulationObject> objectsToInteract;
        public List<SimulationObject> InteractAround()
        {
            objectsToInteract.Clear();
            foreach (SimulationObject obj in Sim.SendList())
            {
                //if ((visionRadius > obj.X - X && visionRadius > obj.Y - Y) || (visionRadius > X - obj.X && visionRadius > obj.Y - Y)|| (visionRadius > X - obj.X && visionRadius > Y - obj.Y) || (visionRadius > X - obj.X && visionRadius > obj.Y - Y))
                if (contactRadius > Math.Abs(obj.X - X) && contactRadius > Math.Abs(obj.Y - Y))
                {

                    objectsToInteract.Add(obj);


                }

            }
            return objectsToInteract;
        }
    }
}
