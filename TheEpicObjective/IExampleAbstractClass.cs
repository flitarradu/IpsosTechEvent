namespace Ipsos.TechEvent
{
	public interface IExampleAbstractClass
	{
		int ShouldNotBeImplemented(int? arg = null);

		int ShouldBeImplemented(int? arg = null);
	}
}