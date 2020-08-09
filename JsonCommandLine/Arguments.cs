using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace JsonCommandLine {
	public class Arguments {
		[JsonIgnore]
		public string CurrentExecutableDirectory { get; internal set; }

		[JsonProperty]
		public List<CommandLineArgument> ArgumentCollection { get; internal set; }

		[JsonProperty]
		public bool ArgumentsExist => ArgumentCollection != null && ArgumentCollection.Count > 0;

		internal Arguments(List<CommandLineArgument> arguments) {
			ArgumentCollection = arguments;
		}

		internal Arguments(params CommandLineArgument[] arguments) {
			ArgumentCollection = arguments.ToList();
		}

		[JsonConstructor]
		public Arguments() {
			ArgumentCollection = new List<CommandLineArgument>();
		}
	}
}
