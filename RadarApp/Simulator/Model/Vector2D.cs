using Radar.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
// 2-dimension vector of dx,dy with polar alternative representation (heading, length)    
public class Vector2D
    {
        float dX;
        float dY;
        public float DX { get => dX; }
        public float DY { get => dY; }
        float heading;
        public float Heading { get => heading; }
        public float Length { get => Vector2D.Distance(this.dX, this.dY); }
        bool IsZero { get => Length == 0;  }

        public Vector2D(float dx, float dy)
        {
            this.dX = dx;
            this.dY = dy;
            this.heading = CalcHeading();
        }
        public Vector2D(Point3D start, Point3D end)
        {
            this.dX = end.X - start.X;
            this.dY = end.Y - start.Y;
            this.heading = CalcHeading();
        }
        public Vector2D(float length, CourseAngle course)
        {
            double radCourse = course * Math.PI / 180.0;
            this.dX = (float)(Math.Sin(radCourse) * length);
            this.dY = (float)(Math.Cos(radCourse) * length);
            this.heading = CalcHeading();
        }

        public static Vector2D NewWithAngle(float length, float angle) {
            return new Vector2D(length, new CourseAngle(angle));
		}

        public Vector2D Reverse()
        {
            return new Vector2D(-dX, -dY);
        }

        public Vector2D Add(Vector2D v)
        {
            return new Vector2D(dX + v.dX, dY + v.dY);
        }

        public Vector2D Sub(Vector2D v)
        {
            return new Vector2D(dX - v.dX, dY - v.dY);
        }

        public static float Distance(float x, float y)
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        static Vector2D Scale(Vector2D vec, float scale)
        {
            if(scale == 0) { throw new ArgumentOutOfRangeException("scale"); }
            return new Vector2D(vec.dX * scale, vec.dY * scale);
        }

        private float CalcHeading()
        {
            float angle = (float)(Math.Atan2(this.dX, this.dY) * 180.0 / Math.PI);
            //Debug.WriteLine($"    Heading: {h} dx:{dx} dy:{dy}");
            return CourseAngle.GetHeading(angle);
        }

        // vector rotation with given angle clokwise
        static Vector2D Rotate(Vector2D vec, float angle)
        {
            double radAngle = Math.PI * angle / 180.0;
            float sin = (float)Math.Sin(-radAngle);
            float cos = (float)Math.Cos(-radAngle);
            return new Vector2D(cos * vec.dX - sin * vec.dY, sin * vec.dX + cos * vec.dY);
        }

        // normalize vector to length 1
        static Vector2D Normalize(Vector2D vec)
		{
            return vec.IsZero ? vec : vec / vec.Length;
		}

        public Vector2D Normalize()
		{
            return Vector2D.Normalize(this);
		}

        public static Vector2D operator -(Vector2D v) => v.Reverse();
        public static Vector2D operator +(Vector2D a, Vector2D b) => a.Add(b);
        public static Vector2D operator -(Vector2D a, Vector2D b) => a.Sub(b);
        public static Vector2D operator *(Vector2D vec, float scale) => Vector2D.Scale(vec, scale);
        public static Vector2D operator /(Vector2D vec, float scale) => Vector2D.Scale(vec, 1/scale);
        public static Vector2D operator >>(Vector2D vec, int angle) => Vector2D.Rotate(vec, angle);

        public override string ToString()
        {
            return $"[{dX:F1}, {dY:F1} hd:{heading:F0}]";
        }

    }
}
