﻿using System.ComponentModel.DataAnnotations;

namespace VisualNovelManagerv2.EntityFramework.Entity.VnInfo
{
    public class VnInfo: IEntity
    {
        [Key]
        public int PkId { get; set; }
        public int VnId { get; set; }
        public string Title { get; set; }
        public string Original { get; set; }
        public string Released { get; set; }
        public string Languages { get; set; }
        public string OriginalLanguage { get; set; }
        public string Platforms { get; set; }
        public string Aliases { get; set; }
        public string Length { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string ImageNsfw { get; set; }
        public double? Popularity { get; set; }
        public int? Rating { get; set; }
    }
}
