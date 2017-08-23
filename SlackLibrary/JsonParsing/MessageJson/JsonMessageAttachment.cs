﻿using Newtonsoft.Json;

namespace SlackITSupport.SlackLibrary.JsonParsing.MessageJson
{
    public class JsonMessageAttachment
    {
        [JsonProperty("fallback")]
        public string Fallback { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("pretext")]
        public string Pretext { get; set; }
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }
        [JsonProperty("author_link")]
        public string AuthorLink { get; set; }
        [JsonProperty("author_icon")]
        public string AuthorIcon { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("title_link")]
        public string TitleLink { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("fields")]
        public JsonMessageAttachmentField[] Fields { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
        [JsonProperty("footer")]
        public string Footer { get; set; }
        [JsonProperty("footer_icon")]
        public string FooterIcon { get; set; }
        [JsonProperty("ts")]
        public string Ts { get; set; }
        [JsonProperty("actions")]
        public JsonMessageAction[] Actions { get; set; }
    }
}