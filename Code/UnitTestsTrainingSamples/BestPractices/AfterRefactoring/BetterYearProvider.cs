namespace BestPractices.AfterRefactoring
{
    public class BetterYearProvider
    {
        private readonly IDateTimeProvider dateTimeProvider;

        public BetterYearProvider(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public int CurrentYear => this.dateTimeProvider.Now.Year;

        public int NextYear => this.CurrentYear + 1;

        public bool IsLeap => ((this.CurrentYear % 4 == 0 && this.CurrentYear % 100 != 0) || this.CurrentYear % 400 == 0);
    }
}
