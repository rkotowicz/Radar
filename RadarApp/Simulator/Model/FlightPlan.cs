using Radar.Model;

namespace Radar.Model
{
	internal class FlightPlan
	{
		List<FlightSection> sections = new List<FlightSection>();
		protected internal List<FlightSection> Sections { get => sections; }
		Point3D startPoint;
		Point3D endPoint;
		int SectionsCount { get => sections.Count; }
		int currentSectionIdx;
		protected internal FlightSection Section { get => sections[currentSectionIdx]; }
		public Point3D StartPoint { get => startPoint; }
		public Point3D EndPoint { get => endPoint;  }
		public CourseAngle Heading { get => Section.Heading; }
		public int Speed { get => Section.Speed; }

		protected internal FlightPlan(IList<Point3D> list, int fpspeed)
		{
			Random rnd = new Random();

			this.startPoint = list[0];
			this.endPoint = list[list.Count - 1];
			Point3D currentPoint = this.startPoint;
			for (int i = 1; i < list.Count; i++)
			{
				Point3D dst = list[i];
				int speed = (fpspeed < 0) ? rnd.Next(-fpspeed) : fpspeed;
				FlightSection section = new FlightSection(currentPoint, dst, speed);
				this.sections.Add(section);
				currentPoint = dst;
			}
			currentSectionIdx = 0;
		}

		protected internal FlightPlan(FlightSection flightSection, int fpspeed)
		{
			Random rnd = new Random();

			this.startPoint = flightSection.StartPoint;
			this.endPoint = flightSection.EndPoint;
			this.sections.Add(flightSection);
			
			currentSectionIdx = 0;
		}

		internal bool UpdatePosition(Point3D newPosition)
		{
			if (Section.EndpointNear(newPosition))
			{
				return ChangeToNextSection();
			}
			else
			{
				return false;
			}
		}

		protected internal bool ChangeToNextSection()
		{
			currentSectionIdx = (++currentSectionIdx) % SectionsCount;
			return (currentSectionIdx == 0);
		}


		void AddSection(FlightSection section)
		{
			sections.Add(section);
		}
		protected internal void PrependSection(FlightSection section)
		{
			sections.Insert(currentSectionIdx, section);
		}


		protected internal FlightSection WhereToFollow(Point3D pos)
		{
			FlightSection fs = Section.Follow(pos);
			return fs;
		}

		public override string ToString()
		{
			string s1= $"FPlan start:{startPoint} end:{endPoint} speed:{Speed} h:{Heading}\n";
			string s2 = "";
			for (int i = 0; i < sections.Count; i++)
			{
				s2 += sections[i].ToString();
			}
			return s1 + s2;
		}
	}
}