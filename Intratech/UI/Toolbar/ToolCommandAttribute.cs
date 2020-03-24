using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Intratech.UI.Toolbar
{
    public class ToolCommandAttribute : Attribute
    {
        public string PrefabPath { get; }
        public string ButtonName { get; }
        public int Width { get; }
        public ToolCommandAttribute(string prefabPath, string buttonName) : this(prefabPath, buttonName, -1)
        {
        }

        public ToolCommandAttribute(string prefabPath, string buttonName, int width)
        {
            PrefabPath = prefabPath;
            ButtonName = buttonName;
            Width = width;
        }
    }
}
