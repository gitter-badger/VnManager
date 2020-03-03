using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VndbSharp.Models.Common;

namespace VisualNovelManager.Models.Db.Vndb.VnInfo
{
    public class DbVnInfoTags
    {
        public int Id { get; set; }
        public uint? VnId { get; set; }
        public uint TagId { get; set; }
        public double Score { get; set; }
        public VndbSharp.Models.Common.SpoilerLevel Spoiler { get; set; }
    }
}
