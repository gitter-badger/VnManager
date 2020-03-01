﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnTagTrait
{
    public class DbVnTagData
    {
        public int Id { get; set; }
        public uint TagId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public uint Vns { get; set; }
        public string Cat { get; set; }
        public string Aliases { get; set; }
        public string Parents { get; set; }

        public override bool Equals(object obj)
        {
            DbVnTagData vnTagDataObj = (DbVnTagData)obj;
            if (obj == null) return false;
            if (obj.GetType() != typeof(DbVnTagData)) return false;
            return TagId == vnTagDataObj.TagId && Name == vnTagDataObj.Name &&
                   Description == vnTagDataObj.Description && Meta == vnTagDataObj.Meta &&
                   Vns == vnTagDataObj.Vns && Cat == vnTagDataObj.Cat && Aliases == vnTagDataObj.Aliases
                   && Parents == vnTagDataObj.Parents;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int hashingBase = (int)2166136261;
                const int hashingMultiplier = 16777619;
                int hash = hashingBase;
                hash = (hash * hashingMultiplier) + TagId.GetHashCode();
                hash = (hash * hashingMultiplier) + Name.GetHashCode();
                hash = (hash * hashingMultiplier) + Description.GetHashCode();
                hash = (hash * hashingMultiplier) + Meta.GetHashCode();
                hash = (hash * hashingMultiplier) + Vns.GetHashCode();
                hash = (hash * hashingMultiplier) + Cat.GetHashCode();
                hash = (hash * hashingMultiplier) + Aliases.GetHashCode();
                hash = (hash * hashingMultiplier) + Parents.GetHashCode();
                return hash;
            }
        }
    }
}
