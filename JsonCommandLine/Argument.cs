using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonCommandLine {
	public class Argument : ISingleArgument {
		[JsonProperty]
		public string BaseCommand { get; set; }

		[JsonProperty]
		public Dictionary<string, string> Parameters { get; set; }

		public Argument(string baseCommand, Dictionary<string, string> parameters) {
			BaseCommand = baseCommand;
			Parameters = parameters;
		}

		[JsonConstructor]
		public Argument() {
			BaseCommand = string.Empty;
			Parameters = new Dictionary<string, string>();
		}
	}
}
