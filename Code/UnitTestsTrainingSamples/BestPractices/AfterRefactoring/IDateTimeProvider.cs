namespace BestPractices.AfterRefactoring
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}