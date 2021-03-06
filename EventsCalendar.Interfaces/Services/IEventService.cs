﻿using EventsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCalendar.Interfaces.Services
{
    public partial interface IEventService
    {
        IOperationResult Result { get; set; }

        IOperationResult CreateEvent(Event ev);

        Event ReadEvent(long eventId);

        IOperationResult UpdateEvent(Event ev);

        IOperationResult DeleteEvent(Event ev);

        List<Event> GetAllEvents();

        List<Event> GetAllEventsFromMonth(int year, int month);

        List<DateTime> GetAllEventDatesFromMonth(int year, int month);
    }
}
