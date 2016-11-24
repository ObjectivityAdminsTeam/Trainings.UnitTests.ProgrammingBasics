using System;

namespace BestPractices.StartPoint
{
    public class TimeOfDayProvider
    {
        public TimeOfDay TimeOfDay
        {
            get
            {
                var currentTime = DateTime.Now;
                if (currentTime.Hour < 6)
                {
                    return TimeOfDay.Night;
                }

                if (currentTime.Hour < 12)
                {
                    return TimeOfDay.Morning; ;
                }

                if (currentTime.Hour < 18)
                {
                    return TimeOfDay.Afternoon;
                }

                return TimeOfDay.Evening;
            }
        }
    }
}
