using EventBus.Base;
using EventBus.Base.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EventBus.Factory;
using EventBus.UnitTest.Events.EventHandlers;
using EventBus.UnitTest.Events.Events;
using RabbitMQ.Client;

namespace EventBus.UnitTest;

[TestClass]
public class EventBusTests
{
    private ServiceCollection services;

    public EventBusTests()
    {
        services = new ServiceCollection();
        services.AddLogging(configure => configure.AddConsole());
    }

    [TestMethod]
    public void subscribe_event_on_rabbitmq_test()
    {
        services.AddSingleton<IEventBus>(sp =>
        {
            EventBusConfig config = new()
            {
                ConnectionRetryCount = 5,
                SubscriberClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "MicroServiceTopicName",
                EventBusType = EventBusType.RabbitMQ,
                EventNameSuffix = "IntegrationEvent",
                // Connection = new ConnectionFactory()
                // {
                //     HostName = "localhost",
                //     Port = 5672,
                //     UserName = "guest",
                //     Password = "guest"
                // }
            };
            return EventBusFactory.Create(config, sp);
        });

        ServiceProvider sp = services.BuildServiceProvider();

        IEventBus eventBus = sp.GetRequiredService<IEventBus>();

        eventBus.Subscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();
        eventBus.UnSubscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();
    }

    [TestMethod]
    public void subscribe_event_on_azure_test()
    {
        services.AddSingleton<IEventBus>(sp =>
        {
            EventBusConfig config = new()
            {
                ConnectionRetryCount = 5,
                SubscriberClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "MicroServiceTopicName",
                EventBusType = EventBusType.AzureServiceBus,
                EventNameSuffix = "IntegrationEvent",
                EventBusConnectionString =
                    "Endpoint=sb://microtest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=s3k41+t9Eghm+vry1pxZ7Oaf0/uQuioEL+ASbB65V8Y="
            };
            return EventBusFactory.Create(config, sp);
        });

        ServiceProvider sp = services.BuildServiceProvider();

        IEventBus eventBus = sp.GetRequiredService<IEventBus>();

        eventBus.Subscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();
        eventBus.UnSubscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();
    }
}