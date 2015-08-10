using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventsCalendar.Models;
using EventsCalendar.Interfaces;
using EventsCalendar.Interfaces.Repositories;
using Moq;
using EventsCalendar.BusinessLogic;
using System.Collections.Generic;
using System.Linq;

namespace EventsCalendar.Tests
{
    [TestClass]
    public class EventsUnitTest
    {
        [TestMethod]
        public void GetAllEvents_ValidResult_ReturnsAllEvents()
        {
            /*  Return values for mock EventRepository */
            List<Event> mockEvents = new List<Event>
            {
                new Event()
                { 
                    EventID = 1, 
                    EventType = 1,  
                    EventTitle = "Test Event 1", 
                    EventDesc = "Meeting with Foo", 
                    EventStart = DateTime.Now, 
                    EventEnd = DateTime.Now.AddHours(1), 
                    RepeatType = 2 
                },
                new Event()
                { 
                    EventID = 2, 
                    EventType = 2,
                    EventTitle = "Test Event 2", 
                    EventDesc = "Lunch with Bar", 
                    EventStart = DateTime.Now.AddHours(1), 
                    EventEnd = DateTime.Now.AddHours(2), 
                    RepeatType = 1 
                },
                new Event()
                { 
                    EventID = 3, 
                    EventType = 1,  
                    EventTitle = "Test Event 3", 
                    EventDesc = "Date with Foo Bar", 
                    EventStart = DateTime.Now, 
                    EventEnd = DateTime.Now.AddHours(3), 
                    RepeatType = 2 
                },
                new Event()
                { 
                    EventID = 4, 
                    EventType = 2,  
                    EventTitle = "Test Event 4", 
                    EventDesc = "Client Update Meeting", 
                    EventStart = DateTime.Now, 
                    EventEnd = DateTime.Now.AddHours(4), 
                    RepeatType = 3 
                },
                new Event()
                { 
                    EventID = 5, 
                    EventType = 1,  
                    EventTitle = "Test Event 5", 
                    EventDesc = "Family Vacation", 
                    EventStart = DateTime.Now, 
                    EventEnd = DateTime.Now.AddHours(4), 
                    RepeatType = 4 
                }
            };

            /*  Initialize Mocks */
            var operationResult = new Mock<IOperationResult>();
            var eventRepository = new Mock<IEventRepository>();

            /*  Setup Mocks */
            eventRepository
                .Setup(x => x.GetAll())
                .Returns(mockEvents);

            eventRepository
                .Setup(x => x.Result.IsError)
                .Returns(false);

            /*  Initialize Service */
            EventService service = new EventService(
                operationResult.Object,
                eventRepository.Object
            );

            /*  Test Method */
            List<Event> results = service.GetAllEvents();

            /*  Test to see returned events and mock events have the same number of elements */
            Assert.AreEqual(results.Count, mockEvents.Count);

            /*  Test to see returned events are the same as mock events */
            foreach (Event ev in results)
            {
                Assert.IsTrue(mockEvents.Contains(ev));
            }
        }


        [TestMethod]
        public void GetAllEventsByMonth_ValidResult_ReturnsAllEventsFromMonth()
        {
            DateTime now = DateTime.Today;

            /*  Return values for mock EventRepository */
            List<Event> mockEvents = new List<Event>
            {
                new Event()
                { 
                    EventID = 1, 
                    EventType = 1,  
                    EventTitle = "Test Event 1", 
                    EventDesc = "Meeting with Foo", 
                    EventStart = now, 
                    EventEnd = now.AddHours(1), 
                    RepeatType = 2 
                },
                new Event()
                { 
                    EventID = 2, 
                    EventType = 2,  
                    EventTitle = "Test Event 2", 
                    EventDesc = "Lunch with Bar", 
                    EventStart = now.AddDays(1), 
                    EventEnd = now.AddDays(1).AddHours(1), 
                    RepeatType = 1 
                },
                new Event()
                { 
                    EventID = 3, 
                    EventType = 1,  
                    EventTitle = "Test Event 3", 
                    EventDesc = "Date with Foo Bar", 
                    EventStart = now.AddDays(-1), 
                    EventEnd = now.AddDays(-1).AddHours(1),
                    RepeatType = 2 
                },
                new Event()
                { 
                    EventID = 4, 
                    EventType = 2,  
                    EventTitle = "Test Event 4", 
                    EventDesc = "Client Update Meeting", 
                    EventStart = now.AddMonths(1), 
                    EventEnd = now.AddMonths(1).AddHours(1), 
                    RepeatType = 3 
                },
                new Event()
                { 
                    EventID = 5, 
                    EventType = 1,  
                    EventTitle = "Test Event 5", 
                    EventDesc = "Family Vacation", 
                    EventStart = now.AddMonths(1), 
                    EventEnd = now.AddMonths(1).AddHours(2), 
                    RepeatType = 4 
                }
            };

            /*  Initialize Mocks */
            var operationResult = new Mock<IOperationResult>();
            var eventRepository = new Mock<IEventRepository>();

            /*  Setup Mocks */
            eventRepository
                .Setup(x => x.GetAllEventsFromMonth(now.Year, now.Month))
                .Returns(mockEvents.Where(x => x.EventStart.Month == now.Month));

            eventRepository
                .Setup(x => x.Result.IsError)
                .Returns(false);

            /*  Initialize Service */
            EventService service = new EventService(
                operationResult.Object,
                eventRepository.Object
            );

            /*  Test Method */
            List<Event> results = service.GetAllEventsFromMonth(now.Year, now.Month);

            /*  Test to see returned events and mock events have the same number of elements */
            Assert.AreEqual(3, results.Count);

            /*  Test to see returned events are the same as mock events */
            foreach (Event ev in results)
            {
                Assert.AreEqual(now.Month, ev.EventStart.Month);
            }
        }

        [TestMethod]
        public void GetAllEventDatesByMonth_ValidResult_ReturnsUniqueEventDatesFromMonth()
        {
            DateTime now = DateTime.Today;
            /*  Return values for mock EventRepository */
            List<DateTime> mockEventDates = new List<DateTime>
            {
                new DateTime(now.Year, now.Month, 1),
                new DateTime(now.Year, now.Month, 1),
                new DateTime(now.Year, now.Month, 3),
                new DateTime(now.Year, now.Month, 4),
                new DateTime(now.Year, now.Month, 4),
                new DateTime(now.Year, now.Month, 6),
                new DateTime(now.Year, now.Month, 17),
                new DateTime(now.Year, now.Month, 17)
            };

            /*  Initialize Mocks */
            var operationResult = new Mock<IOperationResult>();
            var eventRepository = new Mock<IEventRepository>();

            /*  Setup Mocks */
            eventRepository
                .Setup(x => x.GetAllEventDatesFromMonth(now.Year, now.Month))
                .Returns(mockEventDates.Distinct());

            eventRepository
                .Setup(x => x.Result.IsError)
                .Returns(false);

            /*  Initialize Service */
            EventService service = new EventService(
                operationResult.Object,
                eventRepository.Object
            );

            /*  Test Method */
            List<DateTime> results = service.GetAllEventDatesFromMonth(now.Year, now.Month);

            /*  Test to see returned events and mock events have the same number of elements */
            Assert.AreEqual(5, results.Count);

            /*  Test to see returned events are the same as mock events */
            foreach (DateTime ev in results)
            {
                Assert.IsTrue(mockEventDates.Contains(ev));
            }
        }
    }
}