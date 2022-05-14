using Radar.Events;
using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Events
{
	internal class Collision : IEvent
	{
		EventObjectPair eventObjects;
		public EventObjectPair EventObjects { get => eventObjects; }

		public Collision(SimulatedObject objA, SimulatedObject objB)
		{
			eventObjects = new EventObjectPair(objA, objB);
		}

		public override string ToString()
        {
			return $"Collision of {((INamed)eventObjects.ObjA).Name} and {((INamed)eventObjects.ObjB).Name}";
        }
	}
}
