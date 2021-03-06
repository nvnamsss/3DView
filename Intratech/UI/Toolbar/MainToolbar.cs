﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Intratech.UI.Toolbar
{
    [ToolDefinition(Name ="Main Toolbar")]
    public static class MainToolbar
    {
        [ToolCommand("Toolbar/IconOpen", "IconOpen", 8, 0, 16, 0)]
        public static void Open(GameObject sender)
        {
            Debug.Log("Open");
        }

        [ToolCommand("Toolbar/IconPrint", "IconPrint", 32, 32)]
        public static void Print(GameObject sender) 
        {
            Debug.Log("Print");
        }

        [ToolCommand("Toolbar/IconSave", "IconSave")]
        public static void Save(GameObject sender)
        {
            Debug.Log("Save");
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

        //[ToolCommand("Toolbar/VoiceChat", "VoiceChat", 16, 0, 0, 0)]
        //public static void VoiceChat(GameObject sender)
        //{

        //}
    }
}
