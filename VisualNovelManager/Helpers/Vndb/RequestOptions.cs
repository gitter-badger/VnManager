using VndbSharp.Interfaces;

namespace VisualNovelManager.Helpers.Vndb
{
    public class RequestOptions : IRequestOptions
    {
        public int? Page { get; set; }
        public int? Count { get; set; }
        public string Sort { get; set; }
        public bool? Reverse { get; set; }
    }
}
