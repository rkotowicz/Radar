using Radar.Events;
using Radar.Model;

namespace Radar.Presenter
{
	internal class ProximityGr
	{
		internal static void Draw(Proximity prox, IPresenter presenter)
		{
			presenter.DrawCircle(prox.EventObjects.ObjA.Position, prox.EventObjects.ObjA.Size, Color.Orange, 3);
			presenter.DrawCircle(prox.EventObjects.ObjB.Position, prox.EventObjects.ObjB.Size, Color.Orange, 3);
		}
	}
}