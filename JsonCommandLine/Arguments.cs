using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace JsonCommandLine {
	public class Arguments {
		[JsonIgnore]
		public string CurrentExecutableDirectory { get; internal set; }

		[JsonProperty]
		public List<ISingleArgument> ArgumentCollection { get; internal set; }

		[JsonProperty]
		public bool ArgumentsExist => ArgumentCollection != null && ArgumentCollection.Count > 0;

		internal Arguments(List<ISingleArgument> arguments) {
			ArgumentCollection = arguments;
		}

		internal Arguments(params ISingleArgument[] arguments) {
			ArgumentCollection = arguments.ToList();
		}

		[JsonConstructor]
		public Arguments() {
			ArgumentCollection = new List<ISingleArgument>();
		}

		public string Generate<T>(T instance) where T : ISingleArgument => ArgEscape(JsonConvert.SerializeObject(instance, Formatting.None));

		private string ArgEscape(string json) => json.Replace('"', '\'');
	}
}
