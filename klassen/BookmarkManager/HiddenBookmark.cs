using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkManager
{
    class HiddenBookmark:BookMark
    {
        public override void OpenSite()
        {
            Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "-incognito " + URL);
        }
    }
}
