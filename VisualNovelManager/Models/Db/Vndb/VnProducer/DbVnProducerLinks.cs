using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnProducer
{
    public class DbVnProducerLinks
    {
        public int Id { get; set; }
        public int? ProducerId { get; set; }
        public string Homepage { get; set; }
        public string Wikipedia { get; set; }
    }
}
