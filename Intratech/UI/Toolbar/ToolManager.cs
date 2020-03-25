using Battlehub;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Intratech.UI.Toolbar
{
    public class ToolTriggerEvent : UnityEvent<GameObject>
    {

    }

    public class ToolManager : MonoBehaviour
    {
        public RectTransform bar;
        public string ToolbarName;
        private void Awake()
        {
            var asName = new AssemblyName();
            asName.Name = "Assembly-CSharp";
            Assembly csAssembly = Assembly.Load(asName);

            if (bar == null)
            {
                bar = (RectTransform)gameObject.transform;
            }

            Type[] toolDefinitions = csAssembly.GetTypesWithAttribute(typeof(ToolDefinitionAttribute)).ToArray();
            float xtrans = 0;
            float ytrans = 0;

            foreach (Type type in toolDefinitions)
            {
                MethodInfo[] methods = type.GetMethods();
                ToolDefinitionAttribute toolAtt = (ToolDefinitionAttribute)type.GetCustomAttribute(typeof(ToolDefinitionAttribute));
                if (toolAtt.Name != ToolbarName) continue;

                foreach (MethodInfo method in methods)
                {
                    ToolCommandAttribute att = (ToolCommandAttribute)method.GetCustomAttribute(typeof(ToolCommandAttribute));
                    if (att != null)
                    {
                        GameObject go = Resources.Load<GameObject>(att.PrefabPath);
                        GameObject clone = Instantiate(go);
                        clone.name = go.name;
                        //Button based = Resources.Load<Button>(prefab);
                        Button btn = clone.GetComponentsInChildren<Button>().Where(p => p.name == att.ButtonName).SingleOrDefault();

#if UNITY_EDITOR
                        if (btn == null) Debug.Log("[ToolManager] cannot found button " + att.ButtonName + " for prefab " + att.PrefabPath);
#endif

                        Action<GameObject> action = (Action<GameObject>)Delegate.CreateDelegate(typeof(Action<GameObject>), method, false);
                        btn.onClick.AddListener(() => action(clone));
                        clone.transform.SetParent(bar.transform);
                        RectTransform rect = (RectTransform)clone.transform;
                        
                        Vector2 position = rect.anchoredPosition;
                        position = new Vector2();
                        position.x += xtrans + att.Margin.Left;
                        position.y += ytrans + att.Margin.Top;
                        rect.anchoredPosition = position;
                        Vector2 size = new Vector2(Mathf.Abs(rect.rect.width), Mathf.Abs(rect.rect.height));

                        size.x = att.Size.x != -1 ? att.Size.x : size.x;
                        size.y = att.Size.y != -1 ? att.Size.y : size.y;

                        rect.sizeDelta = size;
                        xtrans += size.x + att.Margin.Right;

                        if (xtrans > Mathf.Abs(bar.rect.x))
                        {
                            xtrans = 0;
                            ytrans += 50;
                        }

                    }
                }

            }
        }

        private Button CreateButton(string prefab, string buttonName)
        {
            GameObject go = Resources.Load<GameObject>(prefab);
            GameObject clone = Instantiate(go);
            clone.name = go.name;
            //Button based = Resources.Load<Button>(prefab);
            Button btn = clone.GetComponentsInChildren<Button>().Where(p => p.name == buttonName).SingleOrDefault();

#if UNITY_EDITOR
            if (btn == null) Debug.Log("[ToolManager] cannot found button " + buttonName + " for prefab " + prefab);
#endif
            return btn;
        }
        
        // Start is called before the first frame update
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

