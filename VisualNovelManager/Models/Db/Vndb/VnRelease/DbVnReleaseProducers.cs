using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnRelease
{
    public class DbVnReleaseProducers
    {
        public int Id { get; set; }
        public uint ReleaseId { get; set; }
        public uint ProducerId { get; set; }
        public bool Developer { get; set; }
        public bool Publisher { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
        public string ProducerType { get; set; }
    }
}
