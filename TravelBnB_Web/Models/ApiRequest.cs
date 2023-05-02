using static TravelBnB_Utility.StaticData;

namespace TravelBnB_Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
