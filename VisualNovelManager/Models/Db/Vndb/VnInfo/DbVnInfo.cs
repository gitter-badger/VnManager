using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelManager.Models.Db.Vndb.VnCharacter;

namespace VisualNovelManager.Models.Db.Vndb.VnInfo
{
    public class DbVnInfo
    {
        public int Id { get; set; }
        public uint VnId { get; set; }
        public string Title { get; set; }
        public string Original { get; set; }
        public string Released { get; set; }
        public string Languages { get; set; }
        public string OriginalLanguages { get; set; }
        public string Platforms { get; set; }
        public string Aliases { get; set; }
        public string Length { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public bool ImageNsfw { get; set; }
        public double? Popularity { get; set; }
        public uint Rating { get; set; }
        public int VoteCount { get; set; }
        public virtual DbVnInfoAnime DbVnInfoAnime { get; set; }
        public virtual DbVnInfoLinks DbVnInfoLinks { get; set; }
        public virtual DbVnInfoRelations DbVnInfoRelations { get; set; }
        public virtual DbVnInfoScreens DbVnInfoScreens { get; set; }
        public virtual DbVnInfoStaff DbVnInfoStaff { get; set; }
        public virtual ICollection<DbVnInfoTags> DbVnInfoTags { get; set; }
        public virtual ICollection<DbVnCharacterInfo> DbVnCharacters { get; set; }
        public virtual ICollection<VnRelease.DbVnRelease> DbVnReleases { get; set; }
        public virtual ICollection<DbVnInfoScreens> DbVnInfoScreensCollection { get; set; }
    }
}
