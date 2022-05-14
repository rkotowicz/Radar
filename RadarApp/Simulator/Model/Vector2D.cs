﻿using Radar.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
    public class Vector2D
    {
        float x;
        float y;
        public float X { get => x; }
        public float Y { get => y; }
        float heading;
        public float Heading { get => heading; }
        public float Length { get => Vector2D.Distance(this.x, this.y); }

        public Vector2D(float dx, float dy)
        {
            this.x = dx;
            this.y = dy;
            this.heading = GetHeading();
        }
        public Vector2D(Point3D start, Point3D end)
        {
            this.x = end.X - start.X;
            this.y = end.Y - start.Y;
            this.heading = GetHeading();
        }
        public Vector2D(float length, CourseAngle course)
        {
            this.x = (float)(Math.Sin(course.Heading * Math.PI / 180.0) * length);
            this.y = (float)(Math.Cos(course.Heading * Math.PI / 180.0) * length);
            this.heading = GetHeading();
        }

        public Vector2D Reverse()
        {
            return new Vector2D(-x, -y);
        }

        public Vector2D Add(Vector2D v)
        {
            return new Vector2D(x + v.x, y + v.y);
        }

        public Vector2D Sub(Vector2D v)
        {
            return new Vector2D(x - v.x, y - v.y);
        }

        public static float Distance(float x, float y)
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        static Vector2D Scale(Vector2D vec, float scale)
        {
            return new Vector2D((int)(vec.x * scale), (int)(vec.y * scale));
        }

        private float GetHeading()
        {
            float dx = this.x;
            float dy = this.y;
            float angle = (float)(Math.Atan2(dx, dy) * 180.0 / Math.PI);
            //Debug.WriteLine($"    Heading: {h} dx:{dx} dy:{dy}");
            return CourseAngle.GetHeading(angle);
        }

        static Vector2D Rotate(Vector2D vec, int angle)
        {
            double rad = angle * Math.PI / 180.0;
            double sin = Math.Sin(rad);
            double cos = Math.Cos(rad);
            return new Vector2D((int)(cos * vec.x - sin * vec.y), (int)(sin * vec.x + cos * vec.y));
        }

        static Vector2D Normalize(Vector2D vec)
		{
            return vec / vec.Length;
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

    }
}
