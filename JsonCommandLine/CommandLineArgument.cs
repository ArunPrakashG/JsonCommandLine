using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace JsonCommandLine {
	public class CommandLineArgument {
		[JsonProperty]
		public string BaseCommand { get; set; }

		[JsonProperty]
		public int ParameterCount => Parameters != null ? Parameters.Count : 0;

		[JsonProperty]
		public Dictionary<string, string> Parameters { get; set; }

		public CommandLineArgument(string baseCommand, Dictionary<string, string> parameters) {
			BaseCommand = baseCommand;
			Parameters = parameters;
		}

		[JsonConstructor]
		public CommandLineArgument() { }

		public CommandLineArgument(string baseCommand) {
			BaseCommand = baseCommand ?? throw new ArgumentNullException(nameof(baseCommand));
			Parameters = new Dictionary<string, string>();
		}

		public virtual string BuildAsArgument() {
			Arguments args = new Arguments(this) {
				CurrentExecutableDirectory = Assembly.GetExecutingAssembly().Location
			};

			return args.AsArgument();
		}

		public virtual Arguments Build() {
			Arguments args = new Arguments(this) {
				CurrentExecutableDirectory = Assembly.GetExecutingAssembly().Location
			};

			return args;
		}

		public bool TryAddParameter(string key, string value) => Parameters.TryAdd(key, value);
	}
}
