using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnCharacter
{
    public class DbVnCharacterVns
    {
        public int Id { get; set; }
        public uint CharacterId { get; set; }
        public uint VnId { get; set; }
        public uint ReleaseId { get; set; }
        public byte SpoilerLevel { get; set; }
        public string Role { get; set; }
    }
}
