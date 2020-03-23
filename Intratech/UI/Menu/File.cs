using Battlehub.UIControls.MenuControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intratech.UI.Menu
{
    [MenuDefinition(1)]
    public static class File
    {
        [MenuCommand("File/Open")]
        public static void Open()
        {
            Debug.Log("Open");
        }
        [MenuCommand("File/Save")]
        public static void Save()
        {
            Debug.Log("Save");

        }
        [MenuCommand("File/Save Image")]
        public static void SaveImage()
        {
            Debug.Log("Save Image");

        }
        [MenuCommand("File/Print")]
        public static void Print()
        {
            Debug.Log("Print");

        }
        [MenuCommand("File/Exit")]
        public static void Exit()
        {
            Debug.Log("Exit");

        }

    }
}

