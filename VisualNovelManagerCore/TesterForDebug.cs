using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelManagerCore
{
    public class TesterForDebug
    {
        public void CallTestMethods()
        {
#if DEBUG
            Test1();
            Test2();
            Test3();
#else

#endif
        }

        private void Test1()
        {
            Debug.WriteLine("method works");
        }
        private void Test2()
        {

        }
        private void Test3()
        {

        }
    }
}
