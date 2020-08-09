using System;

namespace JsonCommandLine.Exceptions {
	public class IncorrectTypeException : Exception {
		internal IncorrectTypeException() : base("Specified arguments are in unknown type. (Required: Json)") { }
	}
}
