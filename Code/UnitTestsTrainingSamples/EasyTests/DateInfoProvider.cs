namespace EasyTests
{
    public class DateInfoProvider
    {
        private readonly IDateTimeProvider dateTimeProvider;

        public DateInfoProvider(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public int Year => this.dateTimeProvider.Now.Year;
    }
}
