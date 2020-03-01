using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnCharacter
{
    public class DbVnCharacterInstances
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public byte Spoiler { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
    }
}
