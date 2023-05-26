using System;
using VTMCLI.Model;
using System.Diagnostics;
using Newtonsoft.Json;

namespace VTMCLI
{
    class Program
    {
        enum HelpType{
            Main=0,Search=1
        }
        private static string _version = "1.0alpha";
        public static string Version{get{return _version;}}
        public async static Task Main(string[] args){
            if(args.Length!=0){
                switch(args[0]){
                    case "-v":
                    GetVersion();
                    break;
                    case "--version":
                    GetVersion();
                    break;
                    case "--about":
                    Console.WriteLine("Nothing");
                    break;
                    case "-h":
                    GetHelp();
                    break;
                    case "-s":
                    await Search(args);
                    break;
                default:
                    Console.WriteLine("Error prompt");
                    break;
                }
            }else{
                CliInit();
            }
        }
        public static void CliInit(){

        }
        public static void GetVersion(){
            Console.WriteLine("VTM-CLI " + Version);
        }
        public static void GetHelp(int page = 0, int type = 0)
        {

        }
        public static async Task Search(string[] args){
            var arguments = new Dictionary<string,string>();
            arguments.Add("keyword",args[1]);
            for(int i = 2;i<args.Length;i++){
                switch(args[i]){
                    case "--type":
                        try{
                            if(!arguments.ContainsKey("type"))
                            arguments.Add("type",args[i+1]);
                        }catch(IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        i+=2;
                        break;
                    case "-t":
                        try{
                            if(!arguments.ContainsKey("type"))
                            arguments.Add("type",args[i+1]);
                        }catch(IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        i+=2;
                        break;
                    case "--limit":
                        try{
                            if(!arguments.ContainsKey("limit"))
                            arguments.Add("limit",args[i+1]);
                        }catch(IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        i+=2;
                        break;
                    case "-l":
                        try{
                            if(!arguments.ContainsKey("limit"))
                            arguments.Add("limit",args[i+1]);
                        }catch(IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        i+=2;
                        break;
                    default:
                        return;
                }
            }
            string json = "";
            try{
                json = await Api.ApiRequest(Url.searchUrl,RestSharp.Method.Get,arguments);
            }catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Lack of arguments.\n Usage:vtmcli -s <Keywords> [Options]");
                Debug.WriteLine("Details:"+e.Message);
            }
            
            var output = JsonConvert.DeserializeObject<SearchResultModel.Root>(json,new JsonSerializerSettings{NullValueHandling=NullValueHandling.Ignore});
            foreach(var data in output.Data){
                Console.WriteLine(data.name);
            }
            return;
        }
    }
}