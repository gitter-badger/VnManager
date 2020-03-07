using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using LiteDB;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using VisualNovelManager.Converters;

namespace VisualNovelManager
{
    public static class Globals
    {
        public static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static uint VnId;
        public static bool NsfwEnabled = false;
        public static SpoilerLevel MaxSpoiler = SpoilerLevel.None;
        public static LiteDatabase LiteDbInstance = new LiteDatabase(@"MyData.db");
        public static LogLevel Loglevel = LogLevel.Normal;
        public static ILogger Logger = new LoggerConfiguration().WriteTo.File(new SerilogFormatter(), string.Format(@"{0}\Data\logs\{1}-{2}-{3}_{4}.log", DirectoryPath, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, Loglevel.ToString())).CreateLogger();
    }

    public enum SpoilerLevel
    {
        None,
        Minor,
        Major
    }
    public enum LogLevel
    {
        Verbose, //writes basic data plus all exception info and property info
        Debug, //writes basic plus exception info
        Normal//writes basic data, no exception info
    }
}
