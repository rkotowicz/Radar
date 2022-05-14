using Radar.Events;
using Radar.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Presenter
{

	internal class GraphicalPresenter : IPresenter
	{
		Panel panel;
		Graphics graphics;
		float scale;
		int maxX;
		int maxY;
		int maxZ;
		Matrix viewMatrix;

		public GraphicalPresenter(Panel panel,  int maxX, int maxY, int maxZ)
		{
			this.panel = panel;
			InitPanelDoubleBuffering();
			this.graphics = panel.CreateGraphics();
			this.maxX = maxX;
			this.maxY = maxY;
			this.maxZ = maxZ;
			this.viewMatrix = new Matrix(1, 0, 0, 1, 0, 0);
			ScaleAutomatically(maxX, maxY, maxZ);
			PrepareTransform();
			this.graphics.Dispose();
		}


		void InitPanelDoubleBuffering()
		{
			if (panel == null) { return; }
			this.panel.GetType().GetMethod("SetStyle",
				System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(this.panel,
				new object[]
				{
					System.Windows.Forms.ControlStyles.UserPaint |
					System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
					System.Windows.Forms.ControlStyles.DoubleBuffer, true
				});
		}


		void ScaleAutomatically(int maxX, int maxY, int maxZ)
		{
			float scaleX = graphics.VisibleClipBounds.Width / maxX;
			float scaleY = graphics.VisibleClipBounds.Height / maxY;
			scale = scaleX < scaleY ? scaleX : scaleY;
		}
		void PrepareTransform()
		{
			graphics.ResetTransform();
			//viewMatrix = new Matrix(1, 0, 0, -1, 0, 0);
			//viewMatrix.Translate(0, -graphics.VisibleClipBounds.Height);
			viewMatrix = new Matrix(1, 0, 0, 1, 0, 0);
			viewMatrix.Scale(scale, scale);

			graphics.Transform = viewMatrix;
		}

		public void Redraw()
		{
			panel.Invalidate();
		}

		public void Draw(Simulator simulator, Graphics gr)
		{
			graphics = gr;
			//gr.Clear(Color.Black);
			//PrepareTransform();
			//DrawCircle(new Position3D(100, 100, 0), 100, Color.Pink, 5);
			foreach (SimulatedObject o in simulator.Objects)
			{
				if (o is Plane plane)
				{
					PlaneGr.Draw(plane, this);
				}
				//
				if (o is Mountain mountain)
				{
					MountainGr.Draw(mountain, this);
				}
				if (o is Building building)
				{
					BuildingGr.Draw(building, this);
				}
				if (o is INamed)
				{
					INamed named = (INamed)o;
					DrawString(o.Position, named.Name, Color.Gray);
				}

			}
			DrawEvents(simulator, gr);
		}


		private void DrawEvents(Simulator simulator, Graphics gr)
		{
			graphics = gr;
			foreach (IEvent e in simulator.Events)
			{
				if (e is Proximity prox)
				{
					ProximityGr.Draw(prox, this);
				}
				if (e is Collision col)
				{
					CollisionGr.Draw(col, this);
				}

			}
		}


			public void DrawCircle(Point3D centre, int radius, Color penColor, int penWidth)
		{
			using (Pen pen = new Pen(penColor, penWidth))
			{
				Rectangle rect = new Rectangle((int)centre.X - radius, (int)centre.Y - radius, radius * 2, radius * 2);
				graphics.DrawEllipse(pen, rect);
			}
		}

		public void DrawRectangle(Point3D centre, int width, int height, Color penColor, int penWidth)
		{
			using (Pen pen = new Pen(penColor, penWidth))
			{
				graphics.DrawRectangle(pen, centre.X - width / 2, centre.Y - height / 2, width, height);
			}
		}

		public void DrawSection(Point3D start, Point3D end, Color penColor, int penWidth)
		{
			using (Pen pen = new Pen(penColor, penWidth))
			{
				graphics.DrawLine(pen, start, end);
			}
		}

		public void DrawString(Point3D where, string s, Color fontColor)
		{
			TextRenderer.DrawText(graphics, s, panel.Font, where, fontColor);
		}

		public void DrawString(Point3D where, string s, Color fontColor, Font font)
		{
			TextRenderer.DrawText(graphics, s, font, where, fontColor);
		}

	}
}
