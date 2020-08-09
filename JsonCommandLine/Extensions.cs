using Newtonsoft.Json;

namespace JsonCommandLine {
	public static class Extensions {
		public static ArgumentBuilder GenerateArgumentBuilder(this CommandLineArgument argument) => new ArgumentBuilder(argument);

		public static string AsArgument(this Arguments args) => ArgEscape(JsonConvert.SerializeObject(args, Formatting.None));

		internal static string ArgEscape(string json) => json.Replace('"', '\'');

		internal static string ArgUnescape(string arg) => arg.Replace('\'', '"');
	}
}
