using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTypeFactory<T> : MonoBehaviour
{
    [Header("Lists for Factory dict")]   
    [SerializeField] List<T> typeList;
    [SerializeField] List<GameObject> prefabList;

    [SerializeField]
    internal Dictionary<T, GameObject> prefabDictionary = new Dictionary<T, GameObject>();

    private void Awake() {
        for (int i = 0; i < typeList.Count; i++) {
            prefabDictionary.Add(typeList[i], prefabList[i]);
        }
    }

    public virtual GameObject GetNewInstance(T type) {
        //need some defensive programming in here
        return Instantiate(prefabDictionary[type]);
    }
}
