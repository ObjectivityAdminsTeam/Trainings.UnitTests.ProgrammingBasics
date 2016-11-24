namespace EasyTests
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}