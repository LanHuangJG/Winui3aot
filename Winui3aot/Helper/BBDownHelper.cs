using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Winui3aot.Model;

namespace Winui3aot.Helper
{
    public class BBDownHelper
    {
        private static readonly HttpClient Client = new();
        private static readonly string GetTasksApi = $"{Constants.BBDown_Api}/get-tasks";
        private static readonly string GetRunningTasksApi = $"{Constants.BBDown_Api}/get-tasks/running";
        private static readonly string GetFinishedTasksApi = $"{Constants.BBDown_Api}/get-tasks/finished";
        private static readonly string AddTasksApi = $"{Constants.BBDown_Api}/add-task";

        public static async Task<DownloadTaskCollection> GetTasksAsync(string id = null)
        {
            string paramsId = "";
            if (id != null)
            {
                paramsId = $"/{id}";
            }

            DownloadTaskCollection response = await Client.GetFromJsonAsync<DownloadTaskCollection>($"{GetTasksApi}{paramsId}");
            return response;
        }

        public static async Task<List<DownloadTask>> GetRunningTasksAsync()
        {
            List<DownloadTask> response = await Client.GetFromJsonAsync<List<DownloadTask>>(GetRunningTasksApi);
            return response;
        }

        public static async Task<List<DownloadTask>> GetFinishedTasksAsync()
        {
            List<DownloadTask> response = await Client.GetFromJsonAsync<List<DownloadTask>>(GetFinishedTasksApi);
            return response;
        }

        public static async Task<string> AddTaskAsync(string url)
        {
            string downloadPath = SqliteHelper.getValue("downloadPath");
            Dictionary<string, string> data = new()
            {
                { "Url", url },
                { "Cookie","SESSDATA=b6a68a5f,1735993173,4ed2a*71CjBYLNeT1K9IDN_uTX8ggaYN5JGSZxlr7SmjagDbcUns1m6xXCwa-ol9fLbU3m-HlUgSVlVaNXQ4Z2NmaTJKN0YwNlRwa29UOWNCUWFWTnlXM2lodzlNeGNkeWg2U091Rkl4eUlsTE1xTGNBZ2Fsb1BXZ2I4a1RoTHRITDBUb3VZdUtWZnBPQ2pRIIEC" },
                { "FilePattern",downloadPath+"\\<videoTitle>[<dfn>]" }
            };
            HttpResponseMessage response = await Client.PostAsJsonAsync(AddTasksApi, data);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
