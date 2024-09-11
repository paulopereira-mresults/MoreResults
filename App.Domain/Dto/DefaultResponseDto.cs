using Flunt.Notifications;

namespace App.Domain.Dto;

public class DefaultResponseDto<T>
{
    public T Result { get; set; }
    public IEnumerable<Notification> Notifications { get; set; }
    public int Total { get; set; }
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

    public static DefaultResponseDto<T> Create(T content, int total = 1)
    {
        DefaultResponseDto<T> response = new DefaultResponseDto<T>(content);
        response.Total = total;
        return response;
    }
    

    public DefaultResponseDto<T> AddNotifications(IEnumerable<Notification> notifications)
    {
        Notifications = notifications;
        return this;
    }

    public DefaultResponseDto() { }
}
