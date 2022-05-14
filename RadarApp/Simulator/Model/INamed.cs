using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
	internal interface INamed
	{
		int Id { get; }
		string Name { get; }
	}
}
