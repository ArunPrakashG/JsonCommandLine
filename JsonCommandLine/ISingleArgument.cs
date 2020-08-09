using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonCommandLine {
	public interface ISingleArgument {
		[JsonProperty]
		string BaseCommand { get; set; }

		[JsonProperty]
		int ParameterCount => Parameters != null ? Parameters.Count : 0;

		[JsonProperty]
		Dictionary<string, string> Parameters { get; set; }
	}
}