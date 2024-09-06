using Flunt.Notifications;

namespace MoreResults.App.Domain.Dto;

public class DefaultResponseDto<T>
{
    public T Result { get; set; }
    public IEnumerable<Notification> Notifications { get; set; }
    public bool IsValid { get
        {
            return (Notifications != null && Notifications.Any()) ? false: true ;
        }
    }
    public bool IsInvalid
    {
        get
        {
            return (Notifications != null && Notifications.Any()) ? true: false;
        }
    }

    public DefaultResponseDto(T result)
    {
        Result = result;
    }

    public static DefaultResponseDto<T> Create(T result) => new DefaultResponseDto<T>(result);
    

    public DefaultResponseDto<T> AddNotifications(IEnumerable<Notification> notifications)
    {
        Notifications = notifications;
        return this;
    }

    public DefaultResponseDto() { }
}
