using System;

namespace Ipsos.TechEvent
{
	public class ExampleClass : ExampleAbstractClass
	{
		public ExampleClass()
		{
			this.PrivateMethod();
		}

		public static int RandomVariable = 7;
		public int SecondVariable = 6;

		protected byte _age;

		public int NewProp 
		{
			get; set;
		}

		
		public byte Age
		{
			get
			{
				return this._age;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException();
				}

				if (value > 150)
				{
					throw new ArgumentException();
				}

				this._age = value;
			}
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
			this.Random();
			ExampleAbstractClass.StaticRandom();
			return arg ?? 5;
		}

		public override int ShouldNotBeImplemented(int? arg = null)
		{
			return arg ?? default;
		}

		public override void ChildAccessModifiers()
		{
			if (this.Random() == 5)
			{
				System.Console.WriteLine("5");
			}
		}

		public override string ToString()
		{
			return this._privateField;
		}

	}
}