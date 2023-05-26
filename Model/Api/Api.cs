using RestSharp;
namespace VTMCLI.Model{
    class Api{
        static RestClient client = new RestClient();
        public static async Task<string> ApiRequest(string url,Method method,Dictionary<string,string> arguments){
            RestRequest req = new RestRequest(url,method);
            RestResponse res = new RestResponse();
            foreach(var argument in arguments){
                req.AddParameter(argument.Key,argument.Value);
            }
            res = await client.ExecuteAsync(req);
            if(res.StatusCode==System.Net.HttpStatusCode.OK){
                    string responseJson = res.Content!.ToString();
                    return responseJson;
            }else{
                return "Request error:"+res.StatusCode;
            }
        }
    }
}