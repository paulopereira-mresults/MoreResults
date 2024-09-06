namespace MoreResults.App.Domain.Dto;

public class DefaultResultDto<T>
{
    public T Result { get; set; }

    public DefaultResultDto(T result)
    {
        Result = result;
    }
}
