using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

namespace SCRWebAPI_v4.Domain.AggregatesModel.Extensions
{
    public static class ParametersExtensions
    {
        public static void CalculateOffSet(this Parameters parameters)
        {
            parameters.OffSet = (parameters.PageNumber - 1) * parameters.PageSize;
        }
    }
}
