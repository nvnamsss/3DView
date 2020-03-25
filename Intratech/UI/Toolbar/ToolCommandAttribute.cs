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
        public Margin Margin { get; }
        
        public ToolCommandAttribute(string prefabPath, string buttonName) : this(prefabPath, buttonName, new Margin())
        {

        }

        public ToolCommandAttribute(string prefabPath, string buttonName, Margin margin) : this(prefabPath, buttonName, -1, margin)
        {
        }

        public ToolCommandAttribute(string prefabPath, string buttonName, int width, Margin margin)
        {
            PrefabPath = prefabPath;
            ButtonName = buttonName;
            Width = width;
            Margin = margin;
        }

    }

    public struct Margin
    {
        public float Left;
        public float Top;
        public float Right;
        public float Bottom;

        public Margin(float margin) : this(margin, margin, margin, margin)
        {
        }

        public Margin(float horizontal, float vertical) : this (horizontal, vertical, horizontal, vertical)
        {

        }

        public Margin(float left, float top, float right, float bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}
