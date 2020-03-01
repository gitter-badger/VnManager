using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnStaff
{
    public class DbVnStaffAliases
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public int? AliasId { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
    }
}
