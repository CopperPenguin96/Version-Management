using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Version_Management
{
    public class VersionChecker
    {
        /// <summary>
        /// Gets the latest version
        /// </summary>
        /// <param name="scriptLocation">The url location of the php script</param>
        /// <returns>The current version</returns>
        public Version GetLatest(string scriptLocation)
        {
            using WebClient client = new();
            string s = client.DownloadString(scriptLocation);
            return Version.FromString(s);
        }
    }
}
