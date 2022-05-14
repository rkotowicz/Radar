using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Presenter
{
	internal class PlaneGr
	{
		const int PieAngleDelta = 15;
		internal protected static void Draw(Plane plane, IPresenter presenter)
		{
            presenter.DrawSection(
                plane.Position + new Vector2D((float)plane.Size, plane.Heading.Heading), 
                plane.Position - new Vector2D((float)plane.Size, plane.Heading.Heading - 15),
                Color.Green, 2);
            presenter.DrawSection(
                plane.Position + new Vector2D((float)plane.Size, plane.Heading.Heading),
                plane.Position - new Vector2D((float)plane.Size, plane.Heading.Heading + 15), 
                Color.Green, 2);
            presenter.DrawSection(
                plane.Position - new Vector2D((float)plane.Size, plane.Heading.Heading - 15),
                plane.Position - new Vector2D((float)plane.Size, plane.Heading.Heading + 15),
                Color.Green, 2);

            plane.flightPlan.Sections.ForEach(section => DrawFlightSection(section, presenter));
		}

        private static void DrawFlightSection(FlightSection section, IPresenter presenter)
        {
            Color color = Color.Gray;
            int penWidth = 1;
            presenter.DrawSection(section.StartPoint, section.EndPoint, color, penWidth);
            presenter.DrawCircle(section.StartPoint, 2, color, penWidth);
            presenter.DrawCircle(section.EndPoint, 2, color, penWidth);
        }
    }
}
