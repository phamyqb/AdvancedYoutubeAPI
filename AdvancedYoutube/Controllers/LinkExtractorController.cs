using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedYoutube.Helpers;
using AdvancedYoutube.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;

namespace AdvancedYoutube.Controllers
{
    [Produces("application/json")]
    [Route("api/linkextractor")]
    [ApiController]
    public class LinkExtractorController : ControllerBase
    {
        private readonly YoutubeClient _youtubeClient;
        public LinkExtractorController()
        {
            _youtubeClient = new YoutubeClient();
        }

        // GET api/linkextractor/5
        /// <summary>
        /// Id of Video
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<LinkInfos> GetLinks(string id)
        {
            var formats = new List<Format>();
            var videoId = Helper.NormalizeVideoId(id);
            var videoInfo = await _youtubeClient.GetVideoAsync(id);
            var streamInfoSet = await _youtubeClient.GetVideoMediaStreamInfosAsync(id);
            var streamAudios = Helper.GetAudios(streamInfoSet.Audio);
            var streamVideos = Helper.GetVideos(streamInfoSet.Muxed);

            formats.AddRange(streamAudios);
            formats.AddRange(streamVideos);

            return new LinkInfos
            {
                title = videoInfo.Title,
                videoId = videoInfo.Id,
                duration = videoInfo.Duration,
                formats = formats,
                thumbnails = videoInfo.Thumbnails
            };
        }
    }
}
