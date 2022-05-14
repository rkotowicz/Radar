using Radar.Model;

namespace Radar.Model
{
	// Common class for all simulated objects, all objects are simple spheres
	public class SimulatedObject
	{
		private Point3D position; // position of sphere centre
		private int size; // size or radius n metres

		public Point3D Position { get => position; set => position = value; }
		public int Size { get => size; set => size = value; }

		protected SimulatedObject(Point3D pos, int s)
		{
			position = pos;
			size = s;
		}

	}

}
