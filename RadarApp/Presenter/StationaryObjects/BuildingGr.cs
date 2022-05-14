using Radar.Model;

namespace Radar.Presenter
{
	internal class BuildingGr
	{
		internal static void Draw(Building building, IPresenter presenter)
		{
			presenter.DrawCircle(building.Position, building.Size, Color.Blue, 1);
			presenter.DrawRectangle(building.Position, (int)(building.Size*1.4), (int)(building.Size*1.4), Color.Blue, 1);
		}
	}
}