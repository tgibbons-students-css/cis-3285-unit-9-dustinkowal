using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    class URLTradeDataProvider
    {
        private string url;
        public URLTradeDataProvider(string url)
        {
            this.url = url;
        }
        public IEnumerable<string> GetTradeData(string url)
        {
            var tradeData = new List<string>();
            // create a web client and use it to read the file stored at the given URL
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }

        public string getURL()
        {
            return this.url;
        }
    }
}
