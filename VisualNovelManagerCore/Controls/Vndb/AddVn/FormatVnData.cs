using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelManagerCore.Database.Model.VNDB.VnInfo;
using VndbSharp.Models;
using VndbSharp.Models.Common;
using VndbSharp.Models.VisualNovel;

namespace VisualNovelManagerCore.Controls.Vndb.AddVn
{
    public class FormatVnData
    {
        internal VnInfo FormatVnInfo(VndbResponse<VisualNovel> visualNovels)
        {
            if (visualNovels.FirstOrDefault() == null) return new VnInfo();
            VisualNovel visualNovel = visualNovels.FirstOrDefault();

            if (visualNovel != null)
            {
                VnInfo vnInfo = new VnInfo()
                {
                    VnId = visualNovel.Id,
                    Title = visualNovel.Name,
                    Original = visualNovel.OriginalName,
                    Released = visualNovel.Released?.ToString() ?? null,
                    Languages = ConvertToCsv(visualNovel.Languages),
                    OriginalLanguages = ConvertToCsv(visualNovel.OriginalLanguages),
                    Platforms = ConvertToCsv(visualNovel.Platforms),
                    Aliases = ConvertToCsv(visualNovel.Aliases),
                    Length = visualNovel.Length?.ToString(),
                    Description = visualNovel.Description,
                    ImageLink = visualNovel.Image,
                    ImageNsfw = visualNovel.IsImageNsfw,
                    Popularity = visualNovel.Popularity,
                    Rating = visualNovel.Rating,
                    VoteCount = -1 //TODO: Not implemented in vndbsharp
                };

                return vnInfo;
            }
        }

        internal List<VnInfoAnime> FormatVnInfoAnime(VndbResponse<VisualNovel> visualNovels)
        {
            List<VnInfoAnime> vnAnime = new List<VnInfoAnime>();
            if (visualNovels.FirstOrDefault() == null) return new List<VnInfoAnime>();
            VisualNovel visualNovel = visualNovels.FirstOrDefault();
            if (visualNovel != null)
                vnAnime.AddRange(visualNovel.Anime.Select(anime => new VnInfoAnime()
                {
                    VnId = visualNovel.Id,
                    AniDbId = anime.AniDbId,
                    AnnId = anime.AnimeNewsNetworkId,
                    AniNfoId = anime.AnimeNfoId,
                    TitleEng = anime.RomajiTitle,
                    TitleJpn = anime.KanjiTitle,
                    Year = anime.AiringYear?.ToString() ?? null,
                    AnimeType = anime.Type
                }));

            return vnAnime;

        }



        private string ConvertBirthday(SimpleDate birthday)
        {
            string formatted = string.Empty;
            if (birthday == null) return formatted;
            if (birthday.Month == null) return birthday.Month == null ? birthday.Day.ToString() : string.Empty;
            string month = System.Globalization.DateTimeFormatInfo.InvariantInfo.GetMonthName(Convert.ToInt32(birthday.Month));
            formatted = $"{month} {birthday.Day}";
            return formatted;
        }

        string ConvertToCsv(ReadOnlyCollection<string> input)
        {
            return input != null ? string.Join(",", input) : null;
        }
    }
}
