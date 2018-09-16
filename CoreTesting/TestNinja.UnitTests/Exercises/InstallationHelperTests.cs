using System;
using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Exercises
{
    [TestFixture]
    public class InstallationHelperTests
    {
        private Mock<IFileDownloader> _downloader;
        private InstallerHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _downloader = new Mock<IFileDownloader>();
            _helper = new InstallerHelper(_downloader.Object);
        }

        [Test]
        public void IHTest_WrongUrl_ReturnsFalse()
        {
            _downloader.Setup(d => d.Download(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            var result = _helper.DownloadInstaller("customer", "helper");
            Assert.That(result, Is.False);

        }

        [Test]
        public void IHTest_OkUrl_ReturnsTrue()
        {
            _downloader.Setup(d => d.Download(It.IsAny<string>(), It.IsAny<string>()));
            var result = _helper.DownloadInstaller("customer", "helper");
            Assert.That(result, Is.True);

        }
    }
}
