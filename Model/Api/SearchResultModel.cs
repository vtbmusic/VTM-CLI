namespace VTMCLI.Model
{
    class SearchResultModel
    {
        public class Name
        {
            public string origin { get; set; }
            public string cn { get; set; }
            public string jp { get; set; }
            public string en { get; set; }
        }

        public class Artists
        {

            public string id { get; set; }
            public string uid { get; set; }
            public string imgUrl { get; set; }
            public Name name { get; set; }
            public string groupId { get; set; }
            public string groupName { get; set; }
            public string picUrl { get; set; }
            public bool followed { get; set; }
            public int musicSize { get; set; }
            public int albumSize { get; set; }
            public int likeSize { get; set; }
        }

        public class Statis
        {
            public int playCount { get; set; }
            public int commentCount { get; set; }
            public int likeCount { get; set; }
            public int shareCount { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public string name { get; set; }
            public string alias { get; set; }
            public string picUrl { get; set; }
            public string vrcUrl { get; set; }
            public bool like { get; set; }
            public int time { get; set; }
            public double duration { get; set; }
            public List<Artists> artists { get; set; }
            public Statis statis { get; set; }
        }

        public class Root
        {
            public int Total { get; set; }
            public List<Data> Data { get; set; }
            public bool Success { get; set; }
            public int ErrorCode { get; set; }
            public string Msg { get; set; }
        }

    }
}