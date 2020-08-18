using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public Card prefab;
        public int size;
    }

    public List<Pool> pools = new List<Pool>(5);

    

    public Dictionary<string, Queue<GameObject>> poolDictionary;



    public void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

    
}
