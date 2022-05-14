using Radar.Model;

namespace Radar.Presenter
{
	public interface IPresenter
	{
		void Draw(Simulator simulator, Graphics gr);
		void DrawCircle(Point3D centre, int size, Color penColor, int penWidth);
		//void DrawPie(Point3D centre, int size, int startAngle, int sweepAngle, Color penColor, int penWidth);
		void DrawRectangle(Point3D centre, int width, int height, Color penColor, int penWidth);
		void DrawSection(Point3D start, Point3D end, Color penColor, int penWidth);
		void Redraw();

		void DrawString(Point3D where, string s, Color fontColor);
		void DrawString(Point3D where, string s, Color fontColor, Font font);

	}
}
