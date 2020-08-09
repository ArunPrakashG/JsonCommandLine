using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JsonCommandLine {
	public class ArgumentBuilder {
		private readonly List<ISingleArgument> SingleArguments = new List<ISingleArgument>();

		public ArgumentBuilder(List<ISingleArgument> args) => SingleArguments = args;

		public ArgumentBuilder(params ISingleArgument[] args) => SingleArguments = args.ToList();

		public ArgumentBuilder(ISingleArgument arg) {
			SingleArguments.Add(arg);
		}

		public ArgumentBuilder() { }

		public void Add(ISingleArgument arg) {
			if(arg == null) {
				return;
			}

			SingleArguments.Add(arg);
		}

		public Arguments Build() {
			Arguments args = new Arguments(SingleArguments);
			args.CurrentExecutableDirectory = Assembly.GetExecutingAssembly().Location;
			return args;
		}
	}
}
