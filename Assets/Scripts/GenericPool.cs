using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool<T>
{
    [SerializeField] public T poolObjectType;
    [SerializeField] public int initialSize;
    internal Queue<GameObject> poolQueue;
    internal HashSet<int> storedIDs = new HashSet<int>();
    GenericTypeFactory<T> factory;

    internal void initialisePool(GenericTypeFactory<T> factory) {
        poolQueue = new Queue<GameObject>();
        this.factory = factory;
        addObjectsToPool(initialSize);
    }

    internal GameObject Get() {
        if (poolQueue.Count == 0) {
            addObjectsToPool(1);
        }

        var objectFromPool = poolQueue.Dequeue();
        storedIDs.Remove(objectFromPool.GetInstanceID());
        return objectFromPool;
    }

    internal void returnToQueue(GameObject objectToReturn) {
        storeObject(objectToReturn);
    }

    //2 Options - factory to instantiate, or have the pooler instantiate the object
    //Latter option isn't great I'd say
    //So maybe we've got a solid reason to use our factory
    private void addObjectsToPool(int count) {
        for (int i = 0; i < count; i++) {
            var instantiatedObject = factory.GetNewInstance(poolObjectType);
            storeObject(instantiatedObject);
        }
    }

    private void storeObject(GameObject objectToStore) {
        var objectId = objectToStore.GetInstanceID();
        if (storedIDs.Contains(objectId)) return;
        objectToStore.SetActive(false);
        storedIDs.Add(objectId);
        poolQueue.Enqueue(objectToStore);
    }
}
