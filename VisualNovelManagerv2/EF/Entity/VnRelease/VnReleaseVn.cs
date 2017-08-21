﻿using System.ComponentModel.DataAnnotations;

namespace VisualNovelManagerv2.EF.Entity.VnRelease
{
    public class VnReleaseVn: IEntity
    {        
        public int Id { get; set; }
        public int? ReleaseId { get; set; }
        public int? VnId { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
    }
}
