using Radar.Model;
using System.Diagnostics;

namespace Radar.Model
{
	abstract class MovableObject : SimulatedObject, INamed
	{
		abstract public string Name { get; }

		abstract public int Id { get; }

		protected internal FlightPlan flightPlan;
		public static int MaxSpeed { get => 0; }
		public float Heading { get => flightPlan.Heading; }
		public int Speed { get => flightPlan.Speed; }
		const int timeDivider = 50;
		public void SimulateNext(int t)
		{
			FlightSection fs = flightPlan.WhereToFollow(this.Position);
			Debug.WriteLine($" where: {fs}");
			int dx = (int)((fs.Speed / timeDivider) * Math.Sin((fs.Heading / 180.0) * Math.PI) * t);
			int dy = (int)((fs.Speed / timeDivider) * Math.Cos((fs.Heading / 180.0) * Math.PI) * t);
			Point3D newPos = new Point3D(this.Position.X + dx, this.Position.Y + dy, this.Position.Z);
			this.Position = newPos;
			Debug.WriteLine($" dx:{dx} dy:{dy}");
			if(flightPlan.UpdatePosition(newPos))
			{
				this.Position = flightPlan.StartPoint;
			}
		}

		protected MovableObject(FlightPlan flightPlan, int size) : base(flightPlan.StartPoint, size)
		{
			this.flightPlan = flightPlan;
		}

		internal void PrependNewFlightSection(Point3D pos)
		{
			flightPlan.PrependSection(flightPlan.WhereToFollow(pos));
		}
	}
}

