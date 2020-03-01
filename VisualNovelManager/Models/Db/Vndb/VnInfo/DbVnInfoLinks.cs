using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnInfo
{
    public class DbVnInfoLinks
    {
        public int Id { get; set; }
        public uint VnId { get; set; }
        public string Wikipedia { get; set; }
        public string Encubed { get; set; }
        public string Renai { get; set; }
    }
}
