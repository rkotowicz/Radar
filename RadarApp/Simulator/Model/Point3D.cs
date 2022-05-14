﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
	public class Point3D
	{
		private int posX;
		private int posY;
		private int posZ;
		
		public int X { get => posX; set => posX = value; }
		public int Y { get => posY; set => posY = value; }
		public int Z { get => posZ; set => posZ = value; }

		public Point3D(int x, int y, int z)
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

		public static implicit operator Point(Point3D p) => new Point(p.posX, p.posY);

		public static Point3D operator +(Point3D from, Vector2D vec) => new Point3D(from.X + vec.X, from.Y + vec.Y, from.Z);
		public static Point3D operator -(Point3D from, Vector2D vec) => new Point3D(from.X - vec.X, from.Y - vec.Y, from.Z);
		public static Vector2D operator -(Point3D a, Point3D b) => new Vector2D(a, b);
		public Point3D Translate(int dx, int dy)
		{
			return new Point3D(posX + dx, posY + dy, posZ);	
		}
		public override string ToString()
		{
			return $"X={posX} Y={posY} Z={posZ}";
		}
	}
}
