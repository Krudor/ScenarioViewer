using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioViewer.Model.Files;

namespace ScenarioViewer
{
    public interface IDBDataProvider
    {
        string GetCreatureName(uint entry);
        string GetGameobjectName(uint entry);
    }
}
