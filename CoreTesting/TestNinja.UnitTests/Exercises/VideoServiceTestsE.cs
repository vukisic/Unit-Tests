using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Exercises
{
    [TestFixture]
    public class VideoServiceTestsE
    {
        private Mock<IVideoRepository> _repository;
        private VideoService _service;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _service = new VideoService(_fileReader.Object,_repository.Object);
        }

        [Test]
        public void VideoService_EmptyList_EmptyString()
        {
            _repository.Setup(v => v.GetVideos()).Returns(new List<Video>());
            var result = _service.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void VideoService_NotEmptyList_NotEmptyString()
        {
            _repository.Setup(v => v.GetVideos()).Returns(new List<Video>
            {
                new Video{Id=1},
                new Video{Id=2},
                new Video{Id=3}

            });

            var result = _service.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
