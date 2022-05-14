using Radar.Model;
using System.Diagnostics;

namespace Radar.Model
{
	class Plane : MovableObject
	{
		const int MAXSIZE = 20;
		public static new int MaxSpeed { get => 1500; }
		static int planeCount = 0;
		int id;


		protected internal Plane(FlightPlan flightPlan) : base(flightPlan, MAXSIZE)
		{
			this.id = planeCount++;
			Debug.WriteLine(this);
		}
		public override string ToString()
		{
			return $"Plane at: {this.Position}, speed:{this.Speed}, heading:{this.Heading}\n{this.flightPlan}";
		}

		public override string Name => $"Plane {Id}";
		public override int Id => id;

	}
}

