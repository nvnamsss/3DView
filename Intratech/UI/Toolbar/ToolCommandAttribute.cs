using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Intratech.UI.Toolbar
{
    public class ToolCommandAttribute : Attribute
    {
        public string PrefabPath { get; }
        public string ButtonName { get; }
        public Size Size { get; }
        public Margin Margin { get; }

        public ToolCommandAttribute(string prefabPath, string buttonName) : this(prefabPath, buttonName, -1, -1, 0, 0, 0, 0)
        {

        }


        public ToolCommandAttribute(string prefabPath, string buttonName, float left, float right, float top, float bottom) : this(prefabPath, buttonName, -1, -1, left, top, right, bottom)
        {
        }

        public ToolCommandAttribute(string prefabPath, string buttonName, float width, float height) : this(prefabPath, buttonName, width, height, 0, 0, 0, 0)
        {

        }
        public ToolCommandAttribute(string prefabPath, string buttonName, float width, float height, float left, float right, float top, float bottom)
        {
            PrefabPath = prefabPath;
            ButtonName = buttonName;
            Size = new Size(width, height);
            Margin = new Margin(left, top, right, bottom);
        }

    }

    public struct Size
    {
        public float Width;
        public float Height;

        public Size(float width, float height)
        {
            Width = width;
            Height = height;
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

        public Margin(float horizontal, float vertical) : this(horizontal, vertical, horizontal, vertical)
        {

        }

        public Margin(float left, float top, float right, float bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public static Margin Zero => new Margin();
        public static Margin Create()
        {
            return new Margin();
        }
    }
}
