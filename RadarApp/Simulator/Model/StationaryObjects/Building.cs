using Radar.Model;

namespace Radar.Model
{
	class Building : StationaryObject
	{
		static int buildingCount = 0;
		int id;
		protected internal Building(Point3D pos, int s) : base(pos, s)
		{
			id = buildingCount;
			buildingCount++;
		}

		public override string Name => $"Building {Id}";

		public override int Id => id;
	}

}