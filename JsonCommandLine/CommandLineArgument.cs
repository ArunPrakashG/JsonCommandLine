using JsonCommandLine.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JsonCommandLine {
	public class CommandLineArgument : ICommandLineArgument {
		public string BaseCommand { get; set; }

		public Dictionary<string, string> Parameters { get; set; }

		public CommandLineArgument(string baseCommand, Dictionary<string, string> parameters) {
			BaseCommand = baseCommand ?? throw new ArgumentNullException(nameof(baseCommand));
			Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
		}

		[JsonConstructor]
		public CommandLineArgument() { }

		public CommandLineArgument(string baseCommand) {
			BaseCommand = baseCommand ?? throw new ArgumentNullException(nameof(baseCommand));
			
		}

		public bool TryAddParameter(string key, string value) => Parameters.TryAdd(key, value);
	}
}
