using EventProject.Application.Handlers;
using EventProject.Domain.Bus;
using Microsoft.Extensions.Logging;
using Moq;

namespace EventProject.Test
{
    /// <summary>
    /// These tests are basic and tests if the handlers are logging the messages as expected
    /// TODO: Implement a complete test to verify if all events are being published in a expected order
    /// </summary>
    public class LogMessagesTest
    {
        [Fact]
        public async void Logged_As_Expected_For_EventHandler1()
        {
            //Arrange
            var busMock = new Mock<IEventBus>();
            var loggerMock = new Mock<ILogger<EventHandler1>>();
            var handler = new EventHandler1(loggerMock.Object, busMock.Object);
            var domainEvent = new Domain.Events.Event1(Guid.NewGuid());

            //Act
            await handler.Handle(domainEvent, new CancellationToken());

            // Assert
            var expectedLogMessage = $"{typeof(EventHandler1).Name} [${domainEvent.Id}]";

            loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Information),
               It.IsAny<EventId>(),
               It.Is<It.IsAnyType>((v, t) => v.ToString() == expectedLogMessage),
               It.IsAny<Exception>(),
               It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);
        }

        [Fact]
        public async void Logged_As_Expected_For_EventHandler2()
        {
            //Arrange
            var busMock = new Mock<IEventBus>();
            var loggerMock = new Mock<ILogger<EventHandler2>>();
            var handler = new EventHandler2(loggerMock.Object, busMock.Object);
            var domainEvent = new Domain.Events.Event2(Guid.NewGuid());

            //Act
            await handler.Handle(domainEvent, new CancellationToken());

            // Assert
            var expectedLogMessage = $"{typeof(EventHandler2).Name} [${domainEvent.Id}]";

            loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Information),
               It.IsAny<EventId>(),
               It.Is<It.IsAnyType>((v, t) => v.ToString() == expectedLogMessage),
               It.IsAny<Exception>(),
               It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);
        }

        [Fact]
        public async void Logged_As_Expected_For_EventHandler3()
        {
            //Arrange
            var loggerMock = new Mock<ILogger<EventHandler3>>();
            var handler = new EventHandler3(loggerMock.Object);
            var domainEvent = new Domain.Events.Event3(Guid.NewGuid());

            //Act
            await handler.Handle(domainEvent, new CancellationToken());

            // Assert
            var expectedLogMessage = $"{typeof(EventHandler3).Name} [${domainEvent.Id}]";

            loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Information),
               It.IsAny<EventId>(),
               It.Is<It.IsAnyType>((v, t) => v.ToString() == expectedLogMessage),
               It.IsAny<Exception>(),
               It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);
        }
    }
}