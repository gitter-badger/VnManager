using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnCharacter
{
    public class DbVnCharacterVoiced
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int StaffAliasId { get; set; }
        public int VnId { get; set; }
        public string Note { get; set; }
    }
}
