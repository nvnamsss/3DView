using Assets.Hierachy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Intratech
{
    public class Main : MonoBehaviour
    {
        public GameObject Parent;
        public GameObject HierachyBase;
        private void Start()
        {
            HierachyData root = new HierachyData("root");
            UIHierachy view = UIHierachy.Create(HierachyBase, root);
            Debug.Log("Hi mom2");
            view.transform.SetParent(Parent.transform);
            view.name = root.Value;
            RectTransform rect = (RectTransform)view.transform;
            Vector2 size = rect.sizeDelta;
            size.x = 128;
            size.y = 32;
            rect.sizeDelta = size;

            //view.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            HierachyData node1 = new HierachyData("node1");
            root.Add(node1);
            UIHierachy view1 = UIHierachy.Create(HierachyBase, node1);
            rect = (RectTransform)view1.transform;
            size = rect.sizeDelta;
            size.x = 128;
            size.y = 32;
            rect.sizeDelta = size;
            //view1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            HierachyData node2 = new HierachyData("node2");
            root.Add(node2);
            UIHierachy view2 = UIHierachy.Create(HierachyBase, node2);
            view2.name = node2.Value;
            rect = (RectTransform)view2.transform;
            size = rect.sizeDelta;
            size.x = 128;
            size.y = 32;
            rect.sizeDelta = size;
            //view2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            HierachyData node21 = new HierachyData("node21");
            node2.Add(node21);
            UIHierachy view21 = UIHierachy.Create(HierachyBase, node21);
            view21.name = node21.Value;
            rect = (RectTransform)view21.transform;
            size = rect.sizeDelta;
            size.x = 128;
            size.y = 32;
            rect.sizeDelta = size;
            //view21.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            HierachyData node3 = new HierachyData("node3");
            root.Add(node3);
            UIHierachy view3 = UIHierachy.Create(HierachyBase, node3);
            view3.name = node3.Value;
            rect = (RectTransform)view3.transform;
            size = rect.sizeDelta;
            size.x = 128;
            size.y = 32;
            rect.sizeDelta = size;
            //view3.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
