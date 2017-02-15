using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioViewer.Utils.Misc
{
    public class AssemblyUtils
    {
        public static string ExecutingAssemblyPath
            => new FileInfo(new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath).DirectoryName;
    }
}
