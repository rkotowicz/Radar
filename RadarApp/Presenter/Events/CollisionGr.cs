using Radar.Events;
using Radar.Model;

namespace Radar.Presenter
{
	internal class CollisionGr
	{
		internal static void Draw(Collision col, IPresenter presenter)
		{
			presenter.DrawCircle(col.EventObjects.ObjA.Position, col.EventObjects.ObjA.Size + 10, Color.Red, 5);
			presenter.DrawCircle(col.EventObjects.ObjB.Position, col.EventObjects.ObjB.Size + 10, Color.Red, 5);
			using (Font font = new Font("Arial", 24, FontStyle.Bold))
			{
				presenter.DrawString(col.EventObjects.ObjA.Position.Translate(-20, 0), "BUM!", Color.Red, font);
			}
		}
	}
}