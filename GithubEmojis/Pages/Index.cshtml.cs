using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GithubEmojis.Pages
{
    public class IndexModel : PageModel
    {
        private IGithubEmojiService emojiService;
        private readonly ILogger<IndexModel> logger;

        public IndexModel(ILogger<IndexModel> logger, IGithubEmojiService emojiService)
        {
            this.emojiService = emojiService;
            this.logger = logger;
        }

        public IList<Emoji> Emojis { get; set; }

        public async void OnGet()
        {
            Emojis = await emojiService.GetEmojis();
        }
    }
}
