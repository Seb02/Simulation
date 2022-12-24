using System;

namespace Simulation
{
    public abstract class Animal : LifeForm
    {   public int movementWay;
        public int gender;
        public int pregnancyTime;

        
        public Animal(Color color, double x, double y, int gender, Simulation simulation, int visionRadius, int contactRadius, double Energy, double Life, int movementWay,  int pregnancyTime) : base(color, x, y, simulation, visionRadius, contactRadius, Energy, Life) { 
            this.movementWay = movementWay;
            this.gender = gender;
            this.pregnancyTime = pregnancyTime;
        
        }

        public override void Update()
        {
            base.Update();
            Random rd = new Random();
            
            //définir un sens de mouvement
            
            if (X < 5)
            {
                if (Y < 5)
                {
                    X = X + rd.Next(0, 5);
                    Y = Y + rd.Next(0, 5);
                }
                else
                {
                    X = X + rd.Next(0, 5);
                    Y = Y + rd.Next(-5, 5);
                }
            }
            else if (X > 955)
            {
                if (Y < 5)
                {
                    X = X + rd.Next(-5, 0);
                    Y = Y + rd.Next(0, 5);
                }
                else
                {
                    X = X + rd.Next(-5, 0);
                    Y = Y + rd.Next(-5, 5);
                }
            }
            else if (Y < 5)
            {
                if (X < 5)
                {
                    X = X + rd.Next(0, 5);
                    Y = Y + rd.Next(0, 5);
                }
                else
                {
                    X = X + rd.Next(-5, 5);
                    Y = Y + rd.Next(0, 5);
                }
            }
            else if (Y > 455)
            {
                if (X < 5)
                {
                    X = X + rd.Next(0, 5);
                    Y = Y + rd.Next(-5, 0);
                }
                else
                {
                    X = X + rd.Next(-5, 5);
                    Y = Y + rd.Next(-5, 0);
                }
            }
            else
            {
                X = X + rd.Next(-5, 5);
                Y = Y + rd.Next(-5, 5);


            }
            
         }
    public void SeeObject()
        {

        }
    public void Toilet()
        {

        }
        public override void GetEnergy()
        {
            base.GetEnergy();

            if (Life <= 1)
            {


                Meat meat = new Meat(X, Y, Sim, 10);
                Sim.Add(meat);
                Sim.Del(this);


            }
        }
        
        
    }
}

