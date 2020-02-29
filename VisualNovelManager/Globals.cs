using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using LiteDB;

namespace VisualNovelManager
{
    public static class Globals
    {
        public static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static uint VnId;
        public static bool NsfwEnabled = false;
        public static SpoilerLevel MaxSpoiler = SpoilerLevel.None;
        public static LiteDatabase LiteDbInstance = new LiteDatabase(@"MyData.db");
    }
    public enum SpoilerLevel
    {
        None,
        Minor,
        Major
    }
}
