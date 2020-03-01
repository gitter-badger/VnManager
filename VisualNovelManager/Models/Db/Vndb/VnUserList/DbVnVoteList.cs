using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnUserList
{
    public class DbVnVoteList
    {
        public int Id { get; set; }
        public uint UserId { get; set; }
        public uint VnId { get; set; }
        public uint Vote { get; set; }
        public string Added { get; set; }
    }
}
