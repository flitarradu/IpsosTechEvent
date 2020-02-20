namespace Ipsos.TechEvent
{
	public abstract class ExampleAbstractClass : IExampleAbstractClass, IExampleChildClass
	{
		public int Random()
		{
			return 1;
		}

		public static int StaticRandom()
		{
			return 7;
		}

		//Abstraction
		// It's a possible implementation but not final
		public virtual int ShouldNotBeImplemented(int? arg = null)
		{
			return arg ?? default;
		}

		// The derived class should implement this method
		//Abstraction
		public abstract int ShouldBeImplemented(int? arg = null);

		public abstract void ChildAccessModifiers();

		public virtual void NewMethod()
		{
		
		}

	}
}