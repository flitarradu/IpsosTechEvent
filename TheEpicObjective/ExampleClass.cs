using System;

namespace Ipsos.TechEvent
{
	public class ExampleClass : ExampleAbstractClass
	{
		public ExampleClass()
		{
			this.PrivateMethod();
		}

		private string _privateField = "Private (accessd through PublicProperty)";

		protected string ProtectedProperty { get; set; }

		// Encapsulation
		public string PublicProperty { get => this._privateField; set { this._privateField = value; } }

		internal string InternalProperty { get; set; } = "Internal Property";

		internal protected string _protectedInternal = "Protected Internal";

		private protected string _privateProtected = "Private Protected";

		private void PrivateMethod()
		{
			Console.WriteLine("PrivateMethod");
		}

		protected void ProtectedMethod()
		{
			Console.WriteLine("ProtectedMethod");
		}

		public void PublicMethod()
		{
			Console.WriteLine("PublicMethod");
		}

		public override int ShouldBeImplemented(int? arg = null)
		{
			return arg ?? 5;
		}
	}
}