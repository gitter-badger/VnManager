using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnInfo
{
    public class DbVnInfoScreens
    {
        public int Id { get; set; }
        public uint? VnId { get; set; }
        public string ImageUrl { get; set; }
        public string ReleaseId { get; set; }
        public bool Nsfw { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
}
