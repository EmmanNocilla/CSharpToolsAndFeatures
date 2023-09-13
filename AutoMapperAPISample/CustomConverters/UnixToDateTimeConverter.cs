using AutoMapper;

namespace AutoMapperAPISample.CustomConverters
{
    public class UnixToDateTimeConverter : IValueConverter<long, DateTime>
    {
        public DateTime Convert(long sourceMember, ResolutionContext context)
        {
            return DateTimeOffset.FromUnixTimeSeconds(sourceMember).DateTime;
        }
    }
}
