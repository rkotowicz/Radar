using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Events
{
	public interface IEvent
	{
		abstract EventObjectPair EventObjects { get; }
	
	}
}
