namespace Radar.Model
{
	// Course class to handle movable objects course of range 0-360 degrees, easilly convertable to simple float value
	public class CourseAngle
	{
		float heading;
		public float Heading { get => heading; set => heading = GetHeading(value); }
		public CourseAngle(float angle)
		{
			this.heading = GetHeading(angle);
		}

		public static float GetHeading(float angle)
		{
			float heading = angle % 360;
			if(heading < 0) { 
				heading += 360; 
			}
			return heading;
		}

		public override string ToString()
		{
			return heading.ToString("F0");
		}

		public static implicit operator float(CourseAngle a) => a.heading;
		public static CourseAngle operator +(CourseAngle from, float d) => new CourseAngle(from.heading + d);
		public static CourseAngle operator -(CourseAngle from, float d) => new CourseAngle(from.heading - d);

	}
}