using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Intratech.UI.Toolbar
{
    [ToolDefinition]
    public static class MarkupToolbar
    {
        [ToolCommand("Toolbar/IconOpen", "IconOpen")]
        public static void Open(GameObject sender)
        {

        }

        [ToolCommand("Toolbar/IconPrint", "IconPrint")]
        public static void Print(GameObject sender) 
        {

        }

        [ToolCommand("Toolbar/IconSave", "IconSave")]
        public static void Save(GameObject sender)
        {
            
        }

        [ToolCommand("Toolbar/CommonButton", "CommonButton")]
        public static void ZoomIn(GameObject sender)
        {

            Debug.Log("Zoom in");
        }

        [ToolCommand("Toolbar/Icon1", "Icon1")]
        public static void Mark(GameObject sender)
        {
            Debug.Log("Mark");
        }

        [ToolCommand("Toolbar/SearchBar", "Search")]
        public static void Search(GameObject sender)
        {
            Text text = sender.GetComponentInChildren<Text>();

            Debug.Log("Search with value: " + text.text);
        }
    }
}
