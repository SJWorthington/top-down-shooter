using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTypeFactory<T> : MonoBehaviour
{
    [Header("List from which Factory dictionary is built")]   
    [SerializeField] List<T> typeList;
    [SerializeField] List<GameObject> prefabList;

    [SerializeField]
    private Dictionary<T, GameObject> prefabDictionary = new Dictionary<T, GameObject>();

    private void Awake() {
        for (int i = 0; i < typeList.Count; i++) {
            prefabDictionary.Add(typeList[i], prefabList[i]);
        }
    }

    public GameObject GetNewInstance(T type) {
        //need some defensive programming in here
        return Instantiate(prefabDictionary[type]);
    }
}
