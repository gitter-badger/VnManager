using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnProducer
{
    public class DbVnProducer
    {
        public int Id { get; set; }
        public int? ProducerId { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
        public string ProducerType { get; set; }
        public string Language { get; set; }
        public string Aliases { get; set; }
        public string Description { get; set; }
        public virtual DbVnProducerLinks DbVnProducerLinks { get; set; }
        public virtual DbVnProducerRelations DbVnProducerRelations { get; set; }
    }
}
