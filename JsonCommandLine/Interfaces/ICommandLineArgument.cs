using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonCommandLine.Interfaces {
	public interface ICommandLineArgument {
		[JsonProperty]
		string BaseCommand { get; set; }

		[JsonProperty]
		int ParameterCount => Parameters != null ? Parameters.Count : 0;

		[JsonProperty]
		Dictionary<string, string> Parameters { get; set; }
	}
}