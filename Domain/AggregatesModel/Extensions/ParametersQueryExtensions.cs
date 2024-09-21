using SCRWebAPI_v4.Domain.AggregatesModel.Parameters;

namespace SCRWebAPI_v4.Domain.AggregatesModel.Extensions
{
    public static class ParametersQueryExtensions
    {
        public static void CalculateOffSet(this ParametersQuery parameters)
        {
            parameters.OffSet = (parameters.PageNumber - 1) * parameters.PageSize;
        }
    }
}
