//using System;



namespace Simulation
{
    public class Simulation : IDrawable
    {
        public List<SimulationObject> objects;
        public List<SimulationObject> addNext;
        public List<SimulationObject> sendList;
        public List<LifeForm> sendLifeFrom;
        
       
        public Simulation()
        {
            objects = new List<SimulationObject>();
            addNext = new List<SimulationObject>();
            
           
            Random rd = new Random();
            for (int i = 0; i < rd.Next(5, 30); i++)
            {


                objects.Add(new Carnivore(rd.Next(5, 955), rd.Next(5, 455), rd.Next(1, 2), this));

                objects.Add(new Herbivore(rd.Next(5, 955), rd.Next(5, 455), rd.Next(1, 2), this));

                objects.Add(new Plant(rd.Next(5, 955), rd.Next(5, 455), this));

            
        }
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
        public List<LifeForm> SendLifeForm()
        {
            foreach(SimulationObject obj in objects)
            {
                if (obj is LifeForm){
                    sendLifeFrom.Add(obj as LifeForm);
                }

            }
            return sendLifeFrom;
        }
       
        
        
    }
}

