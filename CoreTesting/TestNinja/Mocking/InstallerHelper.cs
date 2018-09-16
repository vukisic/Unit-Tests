using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IFileDownloader _downloader;

        public InstallerHelper(IFileDownloader fileDownloader=null)
        {
            _downloader = fileDownloader ?? new FileDownloader();
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _downloader.Download(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}