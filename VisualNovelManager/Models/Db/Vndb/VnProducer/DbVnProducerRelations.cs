using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnProducer
{
    public class DbVnProducerRelations
    {
        public int Id { get; set; }
        public int? RelationId { get; set; }
        public int? ProducerId { get; set; }
        public string Relation { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
    }
}
