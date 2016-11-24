namespace BestPractices.StartPoint
{
    using System;

    public class YearProvider
    {
        public int CurrentYear => DateTime.Now.Year;

        public int NextYear => this.CurrentYear + 1;
    }
}