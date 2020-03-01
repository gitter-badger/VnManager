using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnCharacter
{
    public class DbVnCharacterTraits
    {
        public int Id { get; set; }
        public uint CharacterId { get; set; }
        public uint TraitId { get; set; }
        public byte SpoilerLevel { get; set; }
    }
}
