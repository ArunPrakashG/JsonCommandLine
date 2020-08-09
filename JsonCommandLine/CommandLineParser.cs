using JsonCommandLine.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonCommandLine {
	public class CommandLineParser : IDisposable {
		private readonly IEnumerable<string> Arguments;
		public readonly bool IsJsonType;
		public readonly string ExecutablePath;

		public CommandLineParser(string envCommandLine) {
			if (string.IsNullOrEmpty(envCommandLine)) {
				throw new ArgumentNullException(nameof(envCommandLine));
			}

			Arguments = SplitEnvironmentArgs(envCommandLine);

			// First element is always the app path
			ExecutablePath = Arguments.FirstOrDefault() ?? throw new NullReferenceException(nameof(ExecutablePath));
			IsJsonType = Arguments.ElementAt(1).StartsWith("{") && Arguments.ElementAt(1).EndsWith("}");
		}

		public Arguments Parse() {
			if (!IsJsonType) {
				throw new IncorrectTypeException();
			}

			return JsonConvert.DeserializeObject<Arguments>(Extensions.ArgUnescape(Arguments.ElementAt(1)));
		}

		private IEnumerable<string> SplitEnvironmentArgs(string cmdLine) {
			if (string.IsNullOrEmpty(cmdLine)) {
				return Array.Empty<string>();
			}

			return cmdLine.Split(' ').Where(x => !string.IsNullOrEmpty(x));
		}

		public void Dispose() { }
	}
}
