using AdvancedYoutube.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace AdvancedYoutube.Helpers
{
    public static class Helper
    {
        public static string NormalizeVideoId(string input)
        {
            if (!YoutubeClient.TryParseVideoId(input, out var id))
                id = input;
            return id;
        }

        public static string NormalizeFileSize(long fileSize)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            double size = fileSize;
            var unit = 0;

            while (size >= 1024)
            {
                size /= 1024;
                ++unit;
            }

            return $"{size:0.#} {units[unit]}";
        }

        public static List<Format> GetVideos(IEnumerable<MuxedStreamInfo> streamInfos)
        {
            return streamInfos.Select(video => new Format
            {
                url = video.Url,
                format = video.Container.GetFileExtension(),
                formatId = video.Itag,
                size = video.Size,
                ext = video.Container.GetFileExtension(),
                quality = video.VideoQuality.ToString(),
                qualityLabel = video.VideoQualityLabel,
                type = "video"
            }).ToList();
        }

        public static List<Format> GetAudios(IEnumerable<AudioStreamInfo> streamInfos)
        {
            return streamInfos.Select(audio => new Format
            {
                url = audio.Url,
                format = audio.Container.GetFileExtension(),
                formatId = audio.Itag,
                size = audio.Size,
                ext = audio.Container.GetFileExtension(),
                type = "audio",
                qualityLabel = "Audio track only"
            }).ToList();
        }
    }
}
