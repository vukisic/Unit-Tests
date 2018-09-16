using System;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        //Test for parameter injection
        //[Test]
        //public void VideoServiceTest_EmptyFile_ReturnsErrorString()
        //{
        //    var service = new VideoService();

        //    var result=service.ReadVideoTitle(new FakeFileReader());
        //    Assert.That(result, Is.EqualTo("Error parsing the video."));
        //}

        //Test for Proprerty injection
        //[Test]
        //public void VideoServiceTest_EmptyFile_ReturnsErrorString()
        //{
        //    var service = new VideoService();
        //    service.fileReader = new FakeFileReader();

        //    var result = service.ReadVideoTitle();
        //    Assert.That(result, Is.EqualTo("Error parsing the video."));
        //}

        //Test for constructor injection
        private VideoService _service;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _service = new VideoService(_fileReader.Object);
        }

        [Test]
        public void VideoServiceTest_EmptyFile_ReturnsErrorString()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var result = _service.ReadVideoTitle();
            Assert.That(result, Is.EqualTo("Error parsing the video."));
        }
    }
}
