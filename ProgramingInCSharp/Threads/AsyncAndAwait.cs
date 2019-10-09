using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingInCSharp.Threads
{
    class AsyncAndAwait : ICommand
    {
        public string Description => "Using async and await method";
        private async Task<string> FetchWebPage(string url)
        {
            HttpClient httpClient = new HttpClient();

            return await httpClient.GetStringAsync(url);
        }

        private async Task<IEnumerable<string>> FetchWebPages(string[] urls)
        {
            var tasks = new List<Task<String>>();

            foreach (string url in urls)
            {
                tasks.Add(FetchWebPage(url));
            }

            return await Task.WhenAll(tasks);
        }

        public void StartCommand()
        {
            string[] urls = new string[]
            {
                "http://google.com",
                "https://www.pinterest.com.mx/",
            };

            IEnumerable<string> listTask = this.FetchWebPages(urls).Result;

            Console.WriteLine("Wait for response pages({0}).", urls.Length);

            foreach (var pageString in listTask)
                Console.WriteLine("\tSize of page {0}", pageString.Length);

            Console.ReadKey();
        }
    }
}
