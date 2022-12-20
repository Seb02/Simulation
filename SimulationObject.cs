using System;
namespace Simulation
{
    public abstract class SimulationObject : DrawableObject
    {
        Simulation simulation;

        public Simulation Sim { get { return simulation; } }
        public SimulationObject(Color color, double x, double y, Simulation simulation) : base(color, x, y)
        {
            this.simulation = simulation;
        }

        abstract public void Update();
    }
}

