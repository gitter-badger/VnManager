using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManager.Initializers
{
    public class Startup
    {
        public void RunStartupTasks()
        {
            CreateFolders();
        }
        
        private void CreateFolders()
        {
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\config");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\Database");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\images\characters");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\images\cover");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\images\screenshots");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\images\vnlist");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\images\userlist");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\libs\");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\res\icons");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\res\icons\country_flags");
            Directory.CreateDirectory(Globals.DirectoryPath + @"\Data\logs");            
        }
    }
}
