using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnStaff
{
    public class DbVnStaff
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int? MainAlias { get; set; }
        public virtual DbVnStaffAliases DbVnStaffAliases { get; set; }
        public virtual DbVnStaffLinks DbVnStaffLinks { get; set; }
    }
}
