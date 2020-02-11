namespace Ipsos.TechEvent
{
	public abstract class ExampleAbstractClass : IExampleAbstractClass
	{
		//Abstraction
		public virtual int ShouldNotBeImplemented(int? arg = null)
		{
			return arg ?? default;
		}

		//Abstraction
		public abstract int ShouldBeImplemented(int? arg = null);
	}
}