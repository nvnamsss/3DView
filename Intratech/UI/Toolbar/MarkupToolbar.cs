using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Intratech.UI.Toolbar
{
    [ToolDefinition]
    public static class MarkupToolbar
    {
        [ToolCommand("Toolbar/CommonButton", "CommonButton")]
        public static void ZoomIn()
        {
            Debug.Log("Zoom in");
        }

        [ToolCommand("Toolbar/Icon1", "Icon1")]
        public static void Mark()
        {
            Debug.Log("Mark");
        }

        [ToolCommand("Toolbar/SearchBar", "Search")]
        public static void Search()

        {
            Debug.Log("Search");
        }
    }
}
