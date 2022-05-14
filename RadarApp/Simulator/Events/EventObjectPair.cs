using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Events
{
	public class EventObjectPair
	{
		SimulatedObject objA;
		SimulatedObject objB;

		public SimulatedObject ObjA { get => objA; set => objA = value; }
		public SimulatedObject ObjB { get => objB; set => objB = value; }

		public EventObjectPair(SimulatedObject objA, SimulatedObject objB)
		{
			this.objA = objA;
			this.objB = objB;
		}
	}
}
