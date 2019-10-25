using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VndbSharp.Models.Common;

namespace VisualNovelManagerCore.Database.Model.VNDB.VnInfo
{
    public class VnInfoTags
    {
        public int Id { get; set; }
        public uint? VnId { get; set; }
        public uint TagId { get; set; }
        public double Score { get; set; }
        public VndbSharp.Models.Common.SpoilerLevel Spoiler { get; set; }
    }
}
