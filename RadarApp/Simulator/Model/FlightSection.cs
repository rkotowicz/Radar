using Radar.Model;

namespace Radar.Model
{
	internal class FlightSection
	{
		Point3D startPoint;
		Point3D endPoint;
		Vector2D vec;
		private float heading;
		private int height;
		private int speed;

		protected internal float Heading { get => heading; }
		protected internal int Speed { get => speed; }
		protected internal int Height { get => height; }
        public Point3D StartPoint { get => startPoint; }
        public Point3D EndPoint { get => endPoint;  }

        //void SetEndPoint(Position3D endPoint)
        //{
        //	this.endPoint = endPoint;
        //}

        //FlightSection(Position3D start, int heading, int height, int speed)
        //{
        //	this.startPoint = start;
        //	this.endPoint = start;
        //	this.heading = heading;
        //	this.height = height;
        //	this.speed = speed;
        //}

        internal protected FlightSection(Point3D start, Point3D dst, int speed)
		{
			this.startPoint = start;
			this.endPoint = dst;
			this.speed = speed;
			this.height = dst.Z;
			vec = new Vector2D(startPoint, endPoint);
			this.heading = vec.Heading;
		}

		internal protected FlightSection Follow(Point3D pos)
		{
			FlightSection fs = new FlightSection(pos, this.endPoint, this.speed);
			return fs;
		}

		internal bool EndpointNear(Point3D newPosition)
		{
			const float SAME_POINT_DISTANCE = 20;

			Vector2D v = endPoint - newPosition;
			bool b = v.Length <= SAME_POINT_DISTANCE;
			if(b)
			{

			}
			return b;
		}

		public override string ToString()
		{
			return $"FSection start:{startPoint} end:{endPoint} h:{height} speed:{speed} h:{heading}\n";
		}
	}
}