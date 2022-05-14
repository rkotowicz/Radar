using Radar.Model;

namespace Radar.Presenter
{
	internal class MountainGr
	{
		internal static void Draw(Mountain mountain, IPresenter presenter)
		{
			presenter.DrawCircle(mountain.Position, mountain.Size, Color.Yellow, 3);
		}
	}
}