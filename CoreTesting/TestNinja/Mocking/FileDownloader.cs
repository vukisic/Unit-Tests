using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace TestNinja.Mocking
{
    public class FileDownloader : IFileDownloader
    {
        public void Download(string url,string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
