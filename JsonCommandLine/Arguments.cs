using JsonCommandLine.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace JsonCommandLine {
	public class Arguments {
		[JsonIgnore]
		public string CurrentExecutableDirectory { get; internal set; }

		[JsonProperty]
		public List<ICommandLineArgument> ArgumentCollection { get; internal set; }

		[JsonProperty]
		public bool ArgumentsExist => ArgumentCollection != null && ArgumentCollection.Count > 0;

		internal Arguments(List<ICommandLineArgument> arguments) {
			ArgumentCollection = arguments;
		}

		internal Arguments(params ICommandLineArgument[] arguments) {
			ArgumentCollection = arguments.ToList();
		}

		[JsonConstructor]
		public Arguments() {
			ArgumentCollection = new List<ICommandLineArgument>();
		}		
	}
}
