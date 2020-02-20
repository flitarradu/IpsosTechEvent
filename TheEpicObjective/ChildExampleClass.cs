using System;

namespace Ipsos.TechEvent
{
	public class ChildExampleClass : ExampleClass
	{
		public ChildExampleClass() 
		{ 
			
		}

		public override int ShouldNotBeImplemented(int? arg = null)
		{
			return arg ?? 10;
		}

		public override int ShouldBeImplemented(int? arg = null)
		{
			return arg ?? 15;
		}

		public override void ChildAccessModifiers()
		{
			System.Console.WriteLine($"ChildExampleClass: {this.ProtectedProperty}");
			System.Console.WriteLine($"ChildExampleClass: {this.InternalProperty}");
			System.Console.WriteLine($"ChildExampleClass: {this._protectedInternal}");
			System.Console.WriteLine($"ChildExampleClass: {this._privateProtected}");
		}

		public void Inheritance()
		{
			System.Console.WriteLine($"ChildExampleClass: {base.ProtectedProperty}");
		}
	}
}