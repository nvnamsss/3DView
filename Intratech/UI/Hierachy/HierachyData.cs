
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

namespace Assets.Hierachy
{
    public class HierachyData : IEnumerable
    {
        public string Value;
        public int Order
        {
            get
            {
                if (parent == null) return 1;
                return parent.collection.IndexOf(this) + 1;
            }
        }
        public int Level => level;
        public HierachyData Parent => parent;
        public UIHierachy View
        {
            get; set;
        }
        public int Count => collection.Count;
        private volatile List<HierachyData> collection;
        private int level
        {
            get
            {
                if (Parent == null) return 1;
                return Parent.level;
            }
        }

        private HierachyData parent;

        public HierachyData(string value)
        {
            Value = value;
            collection = new List<HierachyData>();
        }


        public void Add(HierachyData item)
        {
            collection.Add(item);
            item.parent = this;
        }

        public void Remove(HierachyData item)
        {
            for (int loop = 0; loop < Count; loop++)
            {
                if (collection[loop] == item)
                {
                    collection.RemoveAt(loop);
                    item.parent = null;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
#if UNITY_EDITOR
                Debug.LogError(GetType().Name + " - index is out of range");
#endif
                return;
            }
            collection.RemoveAt(index);
        }

        public HierachyData this[int index]
        {
            get
            {
                return collection[index];
            }
        }
        public IEnumerator GetEnumerator()
        {
            return collection.GetEnumerator();
        }
    }
}
