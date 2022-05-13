using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace GithubEmojis {
    public class GithubEmojiService : IGithubEmojiService
    {
        const string GithubEmojiUrl = "https://api.github.com/emojis";

        private readonly HttpClient httpClient;
        private IList<Emoji> emojis;

        public GithubEmojiService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "mgeorgiou-github-emojis");
        }

        public async Task<IList<Emoji>> GetEmojis()
        {
            if (emojis == null || emojis.Count <= 0)
            {
                var response = await httpClient.GetStringAsync(GithubEmojiUrl);
                try
                {
                    emojis = GetEmojisFrom(response);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"error: {ex}");
                }
            }

            return emojis;
        }

        private IList<Emoji> GetEmojisFrom(string response)
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            var results = new List<Emoji>();

            foreach (var key in dictionary.Keys)
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    results.Add(new Emoji { Key = key, Url = dictionary[key] });
                }
            }

            return results;
        }
    }
}
