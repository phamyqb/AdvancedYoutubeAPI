using System;
using System.Collections.Generic;
using YoutubeExplode.Models;

namespace AdvancedYoutube.ResponseModels
{
    public class LinkInfos
    {
        public string title { get; set; }
        public string videoId { get; set; }
        public TimeSpan duration { get; set; }
        public ThumbnailSet thumbnails { get; set; }
        public List<Format> formats { get; set; }
    }

    public class Format
    {
        public string format { get; set; }
        public int formatId { get; set; }
        public string url { get; set; }
        public long size { get; set; }
        public string ext { get; set; }
        public string quality { get; set; }
        public string qualityLabel { get; set; }
    }
}
