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

        public class Artist
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

        public class Song
        {
            public string id { get; set; }
            public string name { get; set; }
            public string alias { get; set; }
            public string picUrl { get; set; }
            public string vrcUrl { get; set; }
            public bool like { get; set; }
            public int time { get; set; }
            public double duration { get; set; }
            public List<Artist> artists { get; set; }
            public Statis statis { get; set; }
        }

        public class Playlist
        {
            public string id { get; set; }
            public string name { get; set; }
            public int status { get; set; }
            public int userId { get; set; }
            public int createTime { get; set; }
            public int updateTime { get; set; }
            public int subscribedCount { get; set; }
            public string coverImgUrl { get; set; }
            public int coverImgId { get; set; }
            public string description { get; set; }
            public string tags { get; set; }
            public int playCount { get; set; }
            public int trackUpdateTime { get; set; }
            public User creator { get; set; }
            public string subscribers { get; set; }
            public bool subscribed { get; set; }
            public int privacy { get; set; }
            public string recommendInfo { get; set; }
            public int shareCount { get; set; }
            public int commentCount { get; set; }
            public bool like { get; set; }
            public int trackCount { get; set; }
        }

        public class User
        {

            public string userId { get; set; }
            public int userType { get; set; }
            public string nickname { get; set; }
            public int avatarImgId { get; set; }
            public string avatarUrl { get; set; }
            public int backgroundImgId { get; set; }
            public string backgroundUrl { get; set; }
            public string level { get; set; }
            public string experience { get; set; }
            public string nextexperience { get; set; }
            public string signature { get; set; }
            public int createTime { get; set; }
            public string userName { get; set; }
            public int accountType { get; set; }
            public int birthday { get; set; }
            public int gender { get; set; }
            public int authStatus { get; set; }
            public string description { get; set; }
            public bool followed { get; set; }
            public bool allfollowed { get; set; }
            public int followeds { get; set; }
            public int fans { get; set; }
            public string remarkName { get; set; }
        }

        public class Root<T>
        {
            public int Total { get; set; }
            public List<T> Data { get; set; }
            public bool Success { get; set; }
            public int ErrorCode { get; set; }
            public string Msg { get; set; }
        }

    }
}