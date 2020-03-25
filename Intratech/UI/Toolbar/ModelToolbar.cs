using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Intratech.UI.Toolbar
{
    [ToolDefinition(Name = "Model Toolbar")]
    public static class ModelToolbar
    {
        [ToolCommand("Toolbar/IconOpen", "IconOpen", 16, 16, 0, 8, 0, 0)]
        public static void Color(GameObject sender)
        {
            Debug.Log("Color");
        }
    }
}
