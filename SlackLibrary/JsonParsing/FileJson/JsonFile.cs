using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.JsonParsing;

namespace SlackITSupport.SlackLibrary.SearchJson.FileJson
{
    public class JsonFile : JsonSlackItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("created")]
        public string Created { get; set; }
        [JsonProperty("timestamp")]
        public string Ts { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("Title")]
        public string title { get; set; }
        [JsonProperty("mimetype")]
        public string Mimetype { get; set; }
        [JsonProperty("filetype")]
        public string FileType { get; set; }
        [JsonProperty("pretty_type")]
        public string PrettyType { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("editable")]
        public bool Editable { get; set; }
        [JsonProperty("is_external")]
        public bool IsExternal { get; set; }
        [JsonProperty("external_type")]
        public string ExternalType { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("url_private")]
        public string UrlPrivate { get; set; }
        [JsonProperty("url_private_download")]
        public string UrlPrivateDownload { get; set; }
        [JsonProperty("thumb_64")]
        public string Thumb64 { get; set; }
        [JsonProperty("thumb_80")]
        public string Thumb80 { get; set; }
        [JsonProperty("thumb_360")]
        public string Thumb360 { get; set; }
        [JsonProperty("thumb_460_gif")]
        public string ThumbGif { get; set; }
        [JsonProperty("thumb_360_w")]
        public string Thumb360W { get; set; }
        [JsonProperty("thumb_360_h")]
        public string Thumb360H { get; set; }
        [JsonProperty("thumb_480")]
        public string Thumb480 { get; set; }
        [JsonProperty("thumb_480_w")]
        public string Thumb480W { get; set; }
        [JsonProperty("thumb_480_h")]
        public string Thumb480H { get; set; }
        [JsonProperty("thumb_160")]
        public string Thumb160 { get; set; }
        [JsonProperty("permalink_public")]
        public string PermalinkPublic { get; set; }
        [JsonProperty("edit_link")]
        public string EditLink { get; set; }
        [JsonProperty("preivew")]
        public string Preview { get; set; }
        [JsonProperty("preview_highlight")]
        public string PreviewHightlight { get; set; }
        [JsonProperty("lines")]
        public int Lines { get; set; }
        [JsonProperty("lines_more")]
        public int LinesMore { get; set; }
        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }
        [JsonProperty("public_url_shared")]
        public bool PublicUrlShared { get; set; }
        [JsonProperty("display_as_bot")]
        public bool DisplayAsBot { get; set; }
        [JsonProperty("channels")]
        public string[] Channels { get; set; }
        [JsonProperty("groups")]
        public string[] PrivateChannels { get; set; }
        [JsonProperty("ims")]
        public string[] Directs { get; set; }
        [JsonProperty("initial_comment")]
        public JsonComment InitialComment { get; set; }
        [JsonProperty("num_stars")]
        public int NumStars { get; set; }
        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }
    }
}