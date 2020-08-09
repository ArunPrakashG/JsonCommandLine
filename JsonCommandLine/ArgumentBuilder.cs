using JsonCommandLine.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JsonCommandLine {
	public class ArgumentBuilder {
		private readonly List<ICommandLineArgument> SingleArguments = new List<ICommandLineArgument>();

		public ArgumentBuilder(List<ICommandLineArgument> args) => SingleArguments = args;

		public ArgumentBuilder(params ICommandLineArgument[] args) => SingleArguments = args.ToList();

		public ArgumentBuilder(ICommandLineArgument arg) {
			SingleArguments.Add(arg);
		}

		public ArgumentBuilder() { }

		public void Add(ICommandLineArgument arg) {
			if (arg == null) {
				return;
			}

			SingleArguments.Add(arg);
		}

		public Arguments Build() {
			Arguments args = new Arguments(SingleArguments) {
				CurrentExecutableDirectory = Assembly.GetExecutingAssembly().Location
			};

			return args;
		}

		public string BuildAsArgument() => this.Build().AsArgument();
	}
}
