using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model;
using System.Text.Json;

namespace BoostBusinessApi.Extension
{
    public static class Extension
    {
        public static ApiModelResponse AsApiModelResponse(this object o)
        {
            if (o is null) return new ApiModelResponse();
            if (o is Exception) return new ApiModelResponse();

            ApiModelResponse response = new ApiModelResponse();
            response.data = o;
            return response;
        }

        public static string AsJson(this object o)
        {
            if (o is null) return "null";
            return JsonSerializer.Serialize(o);
        }

        public static SystemErrorEntity AsSystemError(this Exception ex)
        {
            SystemErrorEntity response = new SystemErrorEntity();
            response.Exception = ex.ToString();
            response.Message = ex.Message.ToString();
            return response;
        }
    }
}
