namespace Microsoft.SPOT
{
	public interface IEventListener
	{
		void InitializeForEventSource();
		bool OnEvent(BaseEvent ev);
	}
}