using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        //Injection by property
        //public IFileReader fileReader { get; set; }

        //Injection by constructor
        private IFileReader fileReader;
        private IVideoRepository _repository;

        public VideoService(IFileReader tempFileReader=null,IVideoRepository repos=null)
        {
            fileReader = tempFileReader??new FileReader();
            _repository = repos?? new VideoRepository();
        }
        public string ReadVideoTitle()
        {
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        //Injection by parameter
        //public string ReadVideoTitle(IFileReader fileReader)
        //{
        //    var str = fileReader.Read("video.txt");
        //    var video = JsonConvert.DeserializeObject<Video>(str);
        //    if (video == null)
        //        return "Error parsing the video.";
        //    return video.Title;
        //}

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            var videos = _repository.GetVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}