using System;
using System.Collections.Generic;
using System.Text;

namespace JsonCommandLine {
	public static class Extensions {
		public static ArgumentBuilder Generate(this ISingleArgument argument) => new ArgumentBuilder(argument);
	}
}
