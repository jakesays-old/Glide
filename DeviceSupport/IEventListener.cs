namespace Glide.DeviceSupport
{
	public interface IEventListener
	{
		void InitializeForEventSource();
		bool OnEvent(BaseEvent ev);
	}
}