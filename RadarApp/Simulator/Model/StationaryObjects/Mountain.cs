using Radar.Model;

namespace Radar.Model
{
	class Mountain : StationaryObject
	{
		static int mountainCount = 0;
		int id;
		protected internal Mountain(Point3D pos, int s) : base(pos, s)
		{
			id = mountainCount;
			mountainCount++;
		}

		public override string Name => $"Mountain {Id}";

		public override int Id => id;
	}

}