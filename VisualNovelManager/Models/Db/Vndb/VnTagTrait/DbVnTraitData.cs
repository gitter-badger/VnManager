﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Models.Db.Vndb.VnTagTrait
{
    public class DbVnTraitData
    {
        public int Id { get; set; }
        public uint TraitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public uint Chars { get; set; }
        public string Aliases { get; set; }
        public string Parents { get; set; }

        public override bool Equals(object obj)
        {
            DbVnTraitData vnTraitDataObj = (DbVnTraitData)obj;
            if (obj == null) return false;
            if (obj.GetType() != typeof(DbVnTraitData)) return false;
            return (TraitId == vnTraitDataObj.TraitId && Name == vnTraitDataObj.Name &&
                    Description == vnTraitDataObj.Description && Meta == vnTraitDataObj.Meta
                    && Chars == vnTraitDataObj.Chars && Aliases == vnTraitDataObj.Aliases &&
                    Parents == vnTraitDataObj.Parents);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int hashingBase = (int)2166136261;
                const int hashingMultiplier = 16777619;
                int hashCode = hashingBase;
                hashCode = (hashCode * hashingMultiplier) + TraitId.GetHashCode();
                hashCode = (hashCode * hashingMultiplier) + Name.GetHashCode();
                hashCode = (hashCode * hashingMultiplier) + Description.GetHashCode();
                hashCode = (hashCode * hashingMultiplier) + Meta.GetHashCode();
                hashCode = (hashCode * hashingMultiplier) + Chars.GetHashCode();
                hashCode = (hashCode * hashingMultiplier) + Aliases.GetHashCode();
                hashCode = (hashCode * hashingMultiplier) + Parents.GetHashCode();
                return hashCode;
            }
        }
    }
}
