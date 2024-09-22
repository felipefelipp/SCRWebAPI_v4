namespace SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

public class Parameters
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; }
    private int _pageSize;

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = value > maxPageSize ? maxPageSize : value;
        }
    }
    public int OffSet { get; set; }
}