using System;
namespace Simulation
{
    public class Plant : LifeForm
    {

        
        public Plant(double x, double y, Simulation simulation, int visionRadius = 30, int contactRadius = 50, double Energy = 2, double Life = 10) : base(Colors.Green, x, y, simulation, visionRadius, contactRadius, Energy, Life) {
            
        }
        

        public override void Update()
        {
            base.Update();
            NewPlant();
            EatOrganic();
        }
        public void NewPlant() {
            Random rd = new Random();
            //pour ne pas créer de plante à chaque appel:
            if(rd.Next(0,30) == 3)
            {
                //Simulation.objects.Add(new Plant(x + rd.Next(-5, 5), y + rd.Next(-5, 5)));
                Plant baby = new Plant(X + rd.Next(-contactRadius, contactRadius), Y + rd.Next(- contactRadius, contactRadius), Sim);
                Sim.Add(baby);
            }
             

        }
        public override void GetEnergy()
        {
            
            base.GetEnergy();

            if (Life <= 1) 
            { 
            
            
                OrganicWaste poop = new OrganicWaste(X, Y, Sim);
                Sim.Add(poop);
                Sim.Del(this);


            }
        }
        public void EatOrganic ()
        {            
            foreach(SimulationObject obj in Sim.SeeAround(visionRadius, X, Y))
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

