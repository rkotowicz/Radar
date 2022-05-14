using Radar.Model;

namespace Radar.Model
{
	abstract class StationaryObject : SimulatedObject, INamed
	{
		protected StationaryObject(Point3D pos, int size) : base(pos, size)
		{
		}

		abstract public string Name { get;  }

		abstract public int Id { get; }
	}

}