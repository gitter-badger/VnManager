using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnRelease
{
    public class DbVnReleaseMedia
    {
        public int Id { get; set; }
        public uint ReleaseId { get; set; }
        public string Medium { get; set; }
        public uint? Quantity { get; set; }
    }
}
