using System;

namespace Ipsos.TechEvent.Exceptions
{
	public class ExceptionGrandParent : Exception
	{
		private const string _defaultMessage = "This is a [ExceptionGrandParent] exception";

		public ExceptionGrandParent() : base(_defaultMessage) { }

		public ExceptionGrandParent(string message) : base(message ?? _defaultMessage) { }

		public ExceptionGrandParent(string message, Exception innerException) : base(message ?? _defaultMessage, innerException) { }
	}

	public class ExceptionParent : ExceptionGrandParent
	{
		private const string _defaultMessage = "This is a [ExceptionParent] exception";

		public ExceptionParent() : base(_defaultMessage) { }

		public ExceptionParent(string message) : base(message ?? _defaultMessage) { }

		public ExceptionParent(string message, Exception innerException) : base(message ?? _defaultMessage, innerException) { }
	}

	public class ExceptionChild : ExceptionParent
	{
		private const string _defaultMessage = "This is a [ExceptionChild] exception";

		public ExceptionChild() : base(_defaultMessage) { }

		public ExceptionChild(string message) : base(message ?? _defaultMessage) { }

		public ExceptionChild(string message, Exception innerException) : base(message ?? _defaultMessage, innerException) { }
	}
}