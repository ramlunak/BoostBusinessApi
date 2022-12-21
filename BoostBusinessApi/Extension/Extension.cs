using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model;

namespace BoostBusinessApi.Extension
{
    public static class Extension
    {
        public static ApiModelResponse AsApiModelResponse(this object o)
        {
            if (o is null) return new ApiModelResponse();
            ApiModelResponse response = new ApiModelResponse();
            response.data = o;
            return response;
        }

        public static SystemErrorEntity AsSystemError(this Exception ex)
        {

            SystemErrorEntity response = new SystemErrorEntity();
            response.Message = ex.ToString();
            return response;
        }
    }
}
