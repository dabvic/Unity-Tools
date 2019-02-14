using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tools.PoolSystem
{
    public class PoolableElement : MonoBehaviour
    {

        public virtual void OnDisable()
        {
            ReturnToPool();
        }

        public void ReturnToPool()
        {
            PoolSystem.AddToPool(gameObject);
        }
    }
}
