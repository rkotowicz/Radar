using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
	public class Point3D
	{
		private float posX;
		private float posY;
		private float posZ;
		
		public float X { get => posX; set => posX = value; }
		public float Y { get => posY; set => posY = value; }
		public float Z { get => posZ; set => posZ = value; }

		public Point3D(float x, float y, float z)
		{
			this.posX = x;
			this.posY = y;
			this.posZ = z;
		}

		public static Point3D Random()
		{
			Random rnd = new Random();
			return new Point3D(rnd.Next(), rnd.Next(), rnd.Next());
		}

		public static Point3D Random(int maxX, int maxY, int maxZ)
		{
			Random rnd = new Random();
			return new Point3D(rnd.Next(maxX), rnd.Next(maxY), rnd.Next(maxZ));
		}

		public static implicit operator Point(Point3D p) => new Point((int)Math.Floor(p.posX), (int)Math.Floor(p.posY));

		public static Point3D operator +(Point3D from, Vector2D vec) => new Point3D(from.X + vec.DX, from.Y + vec.DY, from.Z);
		public static Point3D operator -(Point3D from, Vector2D vec) => new Point3D(from.X - vec.DX, from.Y - vec.DY, from.Z);
		public static Vector2D operator -(Point3D a, Point3D b) => new Vector2D(a.posX - b.posX, a.posY - b.posY);
		public Point3D Translate(float dx, float dy)
		{
			return new Point3D(posX + dx, posY + dy, posZ);	
		}
		public Point3D Translate(Vector2D vec)
		{
			return new Point3D(posX + vec.DX, posY + vec.DY, posZ);
		}
		public override string ToString()
		{
			return $"X={posX} Y={posY} Z={posZ}";
		}
	}
}
