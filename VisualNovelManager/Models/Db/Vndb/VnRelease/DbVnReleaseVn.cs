using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnRelease
{
    public class DbVnReleaseVn
    {
        public int Id { get; set; }
        public uint ReleaseId { get; set; }
        public uint? VnId { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
    }
}
