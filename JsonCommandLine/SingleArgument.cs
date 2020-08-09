using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonCommandLine {
	public class SingleArgument : ISingleArgument {		
		public string BaseCommand { get; set; }

		public Dictionary<string, string> Parameters { get; set; }

		public SingleArgument(string baseCommand, Dictionary<string, string> parameters) {
			BaseCommand = baseCommand ?? throw new ArgumentNullException(nameof(baseCommand));
			Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
		}

		[JsonConstructor]
		public SingleArgument() { }

		public SingleArgument(string baseCommand) {
			BaseCommand = baseCommand ?? throw new ArgumentNullException(nameof(baseCommand));
		}

		public bool TryAddParameter(string key, string value) => Parameters.TryAdd(key, value);
	}
}
