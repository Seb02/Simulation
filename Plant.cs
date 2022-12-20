using System;
namespace Simulation
{
    public class Plant : LifeForm
    {
        
        public Plant(double x, double y, Simulation simulation, int visionRadius = 5, int contactRadius = 10, double Energy = 2, double Life = 10) : base(Colors.Green, x, y, simulation, visionRadius, contactRadius, Energy, Life) {
            
        }
        

        public override void Update()
        {
            base.Update();
            NewPlant();
            SeeAround();
        }
        public void NewPlant() {
            Random rd = new Random();
            //pour ne pas créer de plante à chaque appel:
            if(rd.Next(0,40) == 3)
            {
                //Simulation.objects.Add(new Plant(x + rd.Next(-5, 5), y + rd.Next(-5, 5)));
                Plant baby = new Plant(X + rd.Next(-visionRadius, visionRadius), Y + rd.Next(- visionRadius, visionRadius), Sim);
                Sim.Add(baby);
            }
             

        }
        public override void GetEnergy()
        {
            
            base.GetEnergy();

            if (Life <= 1) 
            { 
            
            
                OrganicWaste shit = new OrganicWaste(X, Y, Sim, 10);
                Sim.Add(shit);
                Sim.Del(this);


            }
        }
        public override void SeeAround()
        { 
            base.SeeAround(); 
            foreach(SimulationObject obj in objectsAround)
            {
                if (obj is OrganicWaste)
                {
                    Energy += 5;
                    Sim.Del(obj);
                }
            }
        }

    }
}

