using System;
using VTMCLI.Model;
using System.Diagnostics;
using Newtonsoft.Json;


namespace VTMCLI
{
    class Program
    {
        enum HelpType
        {
            Main = 0, Search = 1
        }
        private static string _version = "1.0alpha";
        public static string Version { get { return _version; } }
        public async static Task Main(string[] args)
        {
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "version":
                        GetVersion();
                        break;
                    case "about":
                        Console.WriteLine("Nothing");
                        break;
                    case "help":
                        GetHelp();
                        break;
                    case "search":
                        await SearchInit(args);
                        break;
                    default:
                        Console.WriteLine("Error prompt");
                        break;
                }
            }
            else
            {
                CliInit();
            }
        }
        public static void CliInit()
        {

        }
        public static void GetVersion()
        {
            Console.WriteLine("VTM-CLI " + Version);
        }
        public static void GetHelp(int page = 0, int type = 0)
        {

        }
        public static async Task SearchInit(string[] args)
        {
            var arguments = new Dictionary<string, string>();
            arguments.Add("keyword", args[1]);
            for (int i = 2; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--type":
                        try
                        {
                            if (!arguments.ContainsKey("type"))
                                arguments.Add("type", args[i + 1]);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        i += 2;
                        break;
                    case "-t":
                        try
                        {
                            if (!arguments.ContainsKey("type"))
                                arguments.Add("type", args[i + 1]);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        i += 2;
                        break;
                    case "--limit":
                        try
                        {
                            if (!arguments.ContainsKey("limit"))
                                arguments.Add("limit", args[i + 1]);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        i += 2;
                        break;
                    case "-l":
                        try
                        {
                            if (!arguments.ContainsKey("limit"))
                                arguments.Add("limit", args[i + 1]);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.ToString());
                            return;
                        }
                        i += 2;
                        break;
                    default:
                        return;
                }
            }
            SearchType type = SearchType.song;
            if (arguments.ContainsKey("type"))
            {
                try
                {
                    type = (SearchType)Enum.Parse(typeof(SearchType), arguments["type"]);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    Console.WriteLine("Check your arguments");
                }
            }
            switch(type){
                case SearchType.song:
                    var a = await Search<SearchResultModel.Song>(arguments);
                    foreach(var data in a.Data){
                        Console.WriteLine(data.name);
                    }
                    break;
                case SearchType.artist:
                    var b = await Search<SearchResultModel.Artist>(arguments);
                    foreach(var data in b.Data){
                        Console.WriteLine(data.name.origin);
                    }
                    break;
                case SearchType.playlist:
                    var c = await Search<SearchResultModel.Playlist>(arguments);
                    foreach(var data in c.Data){
                        Console.WriteLine(data.name);
                    }
                    break;
                case SearchType.user:
                    var d = await Search<SearchResultModel.User>(arguments);
                    foreach(var data in d.Data){
                        Console.WriteLine(data.nickname);
                    }
                    break;
            }
        }
        enum SearchType { song = 0, artist = 1, playlist = 2, user = 3 }
        public async static Task<SearchResultModel.Root<T>> Search<T>(Dictionary<string, string> arguments)
        {
            string json = "";
            try
            {
                json = await Api.ApiRequest(Url.searchUrl, RestSharp.Method.Get, arguments);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Lack of arguments.\n Usage:vtmcli -s <Keywords> [Options]");
                Debug.WriteLine("Details:" + e.Message);
            }
            return JsonConvert.DeserializeObject<SearchResultModel.Root<T>>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}