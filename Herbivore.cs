using System;
namespace Simulation
{

	public class Herbivore : Animal
	{
		public Herbivore(double x, double y, Simulation simulation, int visionRadius = 10, int contactRadius = 6, double Energy = 5, double Life = 10) : base(Colors.Blue, x, y, simulation, visionRadius, contactRadius, Energy, Life) { }



	}
}