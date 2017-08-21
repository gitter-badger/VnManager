﻿using System.ComponentModel.DataAnnotations;

namespace VisualNovelManagerv2.EF.Entity.VnTagTrait
{
    public class VnTraitData: IEntity
    {        
        public int Id { get; set; }
        public int? TraitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public int? Chars { get; set; }
        public string Aliases { get; set; }
        public string Parents { get; set; }
    }
}
