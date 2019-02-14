using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tools.PoolSystem
{
    public class PoolSystem : MonoBehaviour
    {
        public static Dictionary<string, Stack<GameObject>> pool = new Dictionary<string, Stack<GameObject>>();

        #region cached
        private static GameObject lastReturned;
        private static Stack<GameObject> lastUsedStack;
        #endregion

        public static GameObject GetElementFromPool(GameObject g)
        {
            if (pool.TryGetValue(g.name, out lastUsedStack))
            {
                if (pool[g.name].Count == 0)
                {
                    lastReturned = Instantiate(g) as GameObject;
                    lastReturned.name = g.name;
                }
                else
                {
                    lastReturned = pool[g.name].Pop();
                }
            }
            else
            {
                lastReturned = Instantiate(g) as GameObject;
                pool.Add(g.name, new Stack<GameObject>());
                lastReturned.name = g.name;
                return lastReturned;
            }

            return lastReturned;
        }

        public static void AddToPool(GameObject g)
        {
            if (!pool.ContainsKey(g.name))
            {
                pool.Add(g.name, new Stack<GameObject>());
            }
            pool[g.name].Push(g);
        }

    }
}
