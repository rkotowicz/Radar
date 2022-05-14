using Radar.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
	// main class provides simulator services
	public class Simulator
	{
		// max physicals dimensions in metres
		//public const int MaxX = 100 * 1000;
		//public const int MaxY = 100 * 1000;
		//public const int MaxZ = 10 * 1000;
		public const int MaxX = 1000;
		public const int MaxY = 500;
		public const int MaxZ = 1000;

		List<SimulatedObject> objects = new List<SimulatedObject>();
		public List<SimulatedObject> Objects { get => objects; }
		List<IEvent> events = new List<IEvent>();
		public List<IEvent> Events { get => events; }


		int simulationStep = 1;
		int PROXIMITY_DISTANCE = 25;

		public int SimulationStep { get; set; }


		public Simulator()
		{
			InitMovable();
			InitStationary();
		}
		// generating random movable objects with random flight plans
		void InitMovable()
		{
			const int MaxCountGeneratedMovableObj = 1;
			for (int i = 0; i < MaxCountGeneratedMovableObj; i++)
			{
				objects.Add(GenerateRandomMovable());
			}
			//objects.Add(GenerateTestMovable1());
			////objects.Add(GenerateTestMovable2());
			////objects.Add(GenerateTestMovable3());
			////objects.Add(GenerateTestMovable4());

		}

		private MovableObject GenerateRandomMovable()
		{
			FlightPlan flightPlan = GenerateRandomFlightPlan();
			MovableObject obj = new Plane(flightPlan);
			return obj;
		}

		private MovableObject GenerateTestMovable1()
		{
			FlightPlan flightPlan = GenerateTestFlightPlan1();
			MovableObject obj = new Plane(flightPlan);
			return obj;
		}
		private MovableObject GenerateTestMovable2()
		{
			FlightPlan flightPlan = GenerateTestFlightPlan2();
			MovableObject obj = new Plane(flightPlan);
			return obj;
		}
		private MovableObject GenerateTestMovable3()
		{
			FlightPlan flightPlan = GenerateTestFlightPlan3();
			MovableObject obj = new Plane(flightPlan);
			return obj;
		}
		private MovableObject GenerateTestMovable4()
		{
			FlightPlan flightPlan = GenerateTestFlightPlan4();
			MovableObject obj = new Plane(flightPlan);
			return obj;
		}

		private FlightPlan GenerateTestFlightPlan1()
		{
			Point3D pos1 = new Point3D(800, 500, 100);
			Point3D pos2 = pos1 + new Vector2D(200.0f, 120);
			FlightSection fs = new FlightSection(pos1, pos2, 400);
			FlightPlan flightPlan = new FlightPlan(fs, 400);
			return flightPlan;
		}
		private FlightPlan GenerateTestFlightPlan2()
		{
			Point3D pos1 = new Point3D(800, 500, 100);
			Point3D pos2 = pos1 + new Vector2D(100.0f, 120);
			FlightSection fs = new FlightSection(pos1, pos2, 800);
			FlightPlan flightPlan = new FlightPlan(fs, 800);
			return flightPlan;
		}
		private FlightPlan GenerateTestFlightPlan3()
		{
			Point3D pos1 = new Point3D(800, 500, 100);
			Point3D pos2 = pos1 + new Vector2D(100.0f, 210);
			FlightSection fs = new FlightSection(pos1, pos2, 700);
			FlightPlan flightPlan = new FlightPlan(fs, 700);
			return flightPlan;
		}
		private FlightPlan GenerateTestFlightPlan4()
		{
			Point3D pos1 = new Point3D(800, 500, 100);
			Point3D pos2 = pos1 + new Vector2D(100.0f, 270);
			FlightSection fs = new FlightSection(pos1, pos2, 500);
			FlightPlan flightPlan = new FlightPlan(fs, 500);
			return flightPlan;
		}

		private FlightPlan GenerateRandomFlightPlan()
		{
			const int MAX_SECTIONS = 2;
			List<Point3D> points = new List<Point3D>();
			Random rnd = new Random();
			int sections = rnd.Next(1, MAX_SECTIONS - 1);
			Point3D startPos = new Point3D(rnd.Next(MaxX), rnd.Next(MaxY), 0);
			points.Add(startPos);
			for (int i = 0; i < sections; i++)
			{
				Point3D pos = Point3D.Random(MaxX, MaxY, MaxZ);
				points.Add(pos);
			}
			FlightPlan flightPlan = new FlightPlan(points, -Plane.MaxSpeed);
			return flightPlan;
		}

		// loading map of stationary objects
		// saving map of stationary objects

		// setting test map
		void InitStationary()
		{
			const int MaxCountGeneratedStationaryObj = 5;
			for (int i = 0; i < MaxCountGeneratedStationaryObj; i++)
			{
				objects.Add(GenerateRandomStationary());
			}
		}

		// returns random stationary object
		private StationaryObject GenerateRandomStationary()
		{
			Random rnd = new Random();
			Point3D pos = new Point3D(rnd.Next(MaxX), rnd.Next(MaxY), 0);
			int size = 0;
			if (rnd.Next(10) < 5)
			{
				// generate Mountain
				size = rnd.Next((int)(MaxZ * 0.05), (int)(MaxZ * 0.1));
				if (pos.X - size <= 0) { pos.X = size; }
				if (pos.X + size >= MaxX) { pos.X = MaxX - size; }
				if (pos.Y - size <= 0) { pos.Y = size; }
				if (pos.Y + size >= MaxY) { pos.Y = MaxY - size; }
				StationaryObject obj = new Mountain(pos, size);
				return obj;
			}
			else
			{
				// generate Building
				size = rnd.Next(20, 40);
				if (pos.X - size <= 0) { pos.X = size; }
				if (pos.X + size >= MaxX) { pos.X = MaxX - size; }
				if (pos.Y - size <= 0) { pos.Y = size; }
				if (pos.Y + size >= MaxY) { pos.Y = MaxY - size; }
				StationaryObject obj = new Building(pos, size);
				return obj;
			}
		}

		// simulating move of objects
		public void SimulateNext()
		{
			for (int i = 0; i < objects.Count; i++)
			{
				SimulatedObject o = objects[i];
				if (o is Plane plane)
				{
					//((Plane)o).SimulateNext(simulationStep);
					plane.SimulateNext(simulationStep);
					objects[i] = plane;
				}
			}
		}

		// checking objects warning distance
		// checking objects collision
		public void CheckDistanceAndGenerateEvents()
		{
			events.Clear();
			if (objects.Count <= 1)
			{
				return;
			}

			for (int i = 0; i < objects.Count - 1; i++)
			{
				SimulatedObject objA = objects[i];
				// sprawdzamy tylko ruchome
				if (objA is StationaryObject)
				{
					continue;
				}

				for (int j = i + 1; j < objects.Count; j++)
				{
					SimulatedObject objB = objects[j];
					float dist = (objA.Position - objB.Position).Length;
					dist -= objA.Size;
					dist -= objB.Size;
					if (dist <= 0)
					{
						events.Add(new Collision(objA, objB));
					}
					else
					{
						if (dist < PROXIMITY_DISTANCE)
						{
							events.Add(new Proximity(objA, objB));
						}
					}
				}
			}
		}
	}

}
