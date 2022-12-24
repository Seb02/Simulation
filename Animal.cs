
using System;

namespace Simulation
{
    public abstract class Animal : LifeForm
    {   public int movementWay;
        public int gender;
        public int pregnancyTime;
        public int movementDuration;

        
        public Animal(Color color, double x, double y, int gender, Simulation simulation, int visionRadius, int contactRadius, double Energy, double Life, int movementWay, int movementDuration,  int pregnancyTime) : base(color, x, y, simulation, visionRadius, contactRadius, Energy, Life) { 
            this.movementWay = movementWay;
            this.movementDuration = movementDuration;
            this.gender = gender;
            this.pregnancyTime = pregnancyTime;
        
        }

        public override void Update()
        {
            base.Update();
            Random rd = new Random();
            
            //définir un sens de mouvement
            if (movementDuration == 0 )
            {
                movementDuration = rd.Next(5, 9);
                movementWay = rd.Next(1, 4);
                                
            }
            if (movementWay ==1 )
            {
                GetDestination(7, 1, 2, 2);

            }
            if (movementWay == 2)
            {
                GetDestination(2, 2, 7, 1);
            }
            if (movementWay == 3)
            {
                GetDestination(1, 7, 2, 2);
            }
            if (movementWay == 4)
            {
                GetDestination(2, 2, 1, 7);
            }
            //gestion des bords
            movementDuration -= 1;
            
            Toilet();
            

            
         }
    public void GetDestination(int absPlus, int absMin, int ordPlus, int ordMin) {
            Random rd = new Random();
            if (X < 5)
            {
                if (Y < 5)
                {
                    X = X + rd.Next(0, absPlus);
                    Y = Y + rd.Next(0, ordPlus);
                }
                else
                {
                    X = X + rd.Next(0, absPlus);
                    Y = Y + rd.Next(-ordMin, ordPlus);
                }
            }
            else if (X > 955)
            {
                if (Y < 5)
                {
                    X = X + rd.Next(-absMin, 0);
                    Y = Y + rd.Next(0, ordPlus);
                }
                else
                {
                    X = X + rd.Next(-absMin, 0);
                    Y = Y + rd.Next(-ordMin, ordPlus);
                }
            }
            else if (Y < 5)
            {
                if (X < 5)
                {
                    X = X + rd.Next(0, absPlus);
                    Y = Y + rd.Next(0, ordPlus);
                }
                else
                {
                    X = X + rd.Next(-absMin, absPlus);
                    Y = Y + rd.Next(0, ordPlus);
                }
            }
            else if (Y > 455)
            {
                if (X < 5)
                {
                    X = X + rd.Next(0, absPlus);
                    Y = Y + rd.Next(-ordMin, 0);
                }
                else
                {
                    X = X + rd.Next(-absMin, absPlus );
                    Y = Y + rd.Next(-ordMin, 0);
                }
            }
            else
            {
                X = X + rd.Next(-absMin, absPlus);
                Y = Y + rd.Next(-absMin, absPlus);


            }
        }
    
    public void Toilet()
        {
            Random rd = new Random();
            
            if (rd.Next(0, 50) == 3)
            {
                
                OrganicWaste poop = new OrganicWaste(X , Y , Sim);
                Sim.Add(poop);
            }

        }
    public override void GetEnergy()
        {
            base.GetEnergy();

            if (Life <= 1)
            {


                Meat meat = new Meat(X, Y, Sim);
                Sim.Add(meat);
                Sim.Del(this);


            }
        }
    public void SeePartner()
        {
            foreach (SimulationObject obj in LifePub.SeeAround())
            {
                if (this is Herbivore && obj is Herbivore)
                {
                    if(gender != (obj as Animal).gender)
                    {
                        X = obj.X; 
                        Y = obj.Y;
                    }
                }
                if (this is Carnivore && obj is Carnivore)
                {
                    if (gender != (obj as Animal).gender)
                    {
                        X = obj.X;
                        Y = obj.Y;
                    }
                }
            }
            
            
        }
    public void MakeNewBaby()
        {
            Random rd = new Random();
            if (pregnancyTime > 1)
            {
                pregnancyTime -= 1;
            }
            if (pregnancyTime == 0)
            {
                foreach (SimulationObject obj in LifePub.InteractAround())
                {
                    if (this is Herbivore && obj is Herbivore)
                    {
                        if (gender == 1)
                        {
                            pregnancyTime = 8;
                        }
                        else
                        {
                            (obj as Animal).pregnancyTime = 8;
                        }
                    }
                    if (this is Carnivore && obj is Carnivore)
                    {
                        if (gender == 1)
                        {
                            pregnancyTime = 8;
                        }
                        else
                        {
                            (obj as Animal).pregnancyTime = 8;
                        }
                    }
                }
            }
            if (pregnancyTime == 1) {
                if (this is Herbivore) {
                    Herbivore baby = new Herbivore(X, Y, rd.Next(1, 2), Sim);
                    Sim.Add(baby); 
                }
                if (this is Carnivore)
                {
                    Carnivore baby = new Carnivore(X, Y, rd.Next(1, 2), Sim);
                    Sim.Add(baby);
                }
                pregnancyTime = 0;
            }
            
        }

    }
    
}

