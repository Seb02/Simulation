//using System;



namespace Simulation
{
    public class Simulation : IDrawable
    {
        public List<SimulationObject> objects;
        public List<SimulationObject> addNext;
        


        public List<SimulationObject> sendList;
        public List<SimulationObject> sendLifeFrom;
        public List<SimulationObject> objectsToInteract;
        public List<SimulationObject> objectsAround;


        public Simulation()
        {
            objects = new List<SimulationObject>();
            addNext = new List<SimulationObject>();
           
            sendList = new List<SimulationObject>();
            sendLifeFrom = new List<SimulationObject>();
            objectsAround = new List<SimulationObject>();
            objectsToInteract = new List<SimulationObject>();



             Random rd = new Random();
             for (int i = 0; i < rd.Next(5, 30); i++)
             {


                 objects.Add(new Dog(rd.Next(5, 955), rd.Next(5, 455), rd.Next(1, 2), this));

                 objects.Add(new Turtle(rd.Next(5, 955), rd.Next(5, 455), rd.Next(1, 2), this));

                 objects.Add(new Plant(rd.Next(5, 955), rd.Next(5, 455), this));


            }
             for (int i = 0; i < rd.Next(20, 40); i++)
             {


                 objects.Add(new Plant(rd.Next(5, 955), rd.Next(5, 455), this, Life: rd.Next(5, 15)));


             }
            objects.Add(new Plant(rd.Next(5, 955), rd.Next(5, 455), this, Life: rd.Next(5, 15)));
            

        }

        public void Update()
            
        {
            
            

            foreach (SimulationObject drawable in objects)
            {
                drawable.Update();
            }
           
            objects.AddRange(addNext);
            
            
            
            addNext.Clear();
            


        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        { 
            
            foreach (SimulationObject drawable in objects)
            {
                canvas.FillColor = drawable.Color;
                canvas.FillCircle(new Point(drawable.X, drawable.Y), 5.0);
            }
        }

        public void Add(SimulationObject obj)
        {
            addNext.Add(obj);
        }
        public void Del(SimulationObject obj)
        {
            objects.Remove(obj);
             

            
            
        }

        

        public List<SimulationObject> SendList()
        {
            return objects;
        }
        
        
        public List<SimulationObject> SeeAround(int visionRadius, double X, double Y)
        {
            objectsAround.Clear();

            foreach (SimulationObject obj in objects)
            {
                //if ((visionRadius > obj.X - X && visionRadius > obj.Y - Y) || (visionRadius > X - obj.X && visionRadius > obj.Y - Y)|| (visionRadius > X - obj.X && visionRadius > Y - obj.Y) || (visionRadius > X - obj.X && visionRadius > obj.Y - Y))
                if (visionRadius > Math.Abs(obj.X - X) && visionRadius > Math.Abs(obj.Y - Y))
                {

                    objectsAround.Add(obj);


                }

            }
            return objectsAround;
            
        }

        
        public List<SimulationObject> InteractAround(int contactRadius, double X, double Y)
        {
            objectsToInteract.Clear();
            foreach (SimulationObject obj in objects)
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

