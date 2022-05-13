using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubEmojis
{
    public interface IGithubEmojiService
    {
        Task<IList<Emoji>> GetEmojis();
    }
}