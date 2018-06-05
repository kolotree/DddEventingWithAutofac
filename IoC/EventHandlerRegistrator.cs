using Autofac;
using Domain;

namespace IoC
{
	internal sealed class EventHandlerRegistrator : Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<EventDispatcher>().As<IEventDispatcher>().SingleInstance();
		}
	}
}
