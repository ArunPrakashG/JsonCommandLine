using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JsonCommandLine {
	public class ArgumentBuilder {
		private readonly List<CommandLineArgument> SingleArguments = new List<CommandLineArgument>();

		public ArgumentBuilder(List<CommandLineArgument> args) => SingleArguments = args;

		public ArgumentBuilder(params CommandLineArgument[] args) => SingleArguments = args.ToList();

		public ArgumentBuilder(CommandLineArgument arg) {
			SingleArguments.Add(arg);
		}

		public ArgumentBuilder() { }

		public ArgumentBuilder Add(CommandLineArgument arg) {
			if (arg == null) {
				throw new NullReferenceException(nameof(arg));
			}

			SingleArguments.Add(arg);
			return this;
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
