namespace CG.Events.Alarms
{
    using System;

    class MorningAlarmEvent: ParentEvent<MorningAlarmEvent, DateTime> { }
    class EventingAlarmEvent: ParentEvent<EventingAlarmEvent, DateTime> { }

    class Consumer
    {
        Consumer()
        {
            MorningAlarmEvent.AddListener(this.PrintClock);
        }

        void PrintClock(DateTime time)
        {
            Console.WriteLine(time);
        }

        void MorningArrived()
        {
            DateTime time = DateTime.Today;
            MorningAlarmEvent.PushEvent(time);
        }

        ~Consumer()  // finalizer
        {
            MorningAlarmEvent.RemoveListener(this.PrintClock);
        }
    }

    class Consumer2
    {
        private Action<DateTime> dateTimePrinter = time => Console.WriteLine(time);

        Consumer2()
        {
            EventingAlarmEvent.AddListener(this.dateTimePrinter);
        }

        void EveningArrived()
        {
            DateTime time = DateTime.Today;
            EventingAlarmEvent.PushEvent(time);
        }

        ~Consumer2()  // finalizer
        {
            EventingAlarmEvent.RemoveListener(this.dateTimePrinter);
        }
    }
}