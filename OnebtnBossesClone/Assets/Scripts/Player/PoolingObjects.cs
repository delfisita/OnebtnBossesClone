using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;

public class PoolingObjects : MonoBehaviour
{
   
    public static PoolingObjects Instance;

    public List<ObjectPooling> objectsToPool;
    private Dictionary<string, Queue<GameObject>> pooledObjectsDictionary;

    private void Awake()
    {
        if 
            (Instance == null)
            Instance = this;
        
        else
            Destroy(gameObject);

        InitializePool();
    }

    private void InitializePool()
    {
        pooledObjectsDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pooledObject in objectsToPool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pooledObject.amountToPool; i++)
            {
                GameObject obj = Instantiate(pooledObject.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            pooledObjectsDictionary.Add(pooledObject.prefab.name, objectPool);
        }
    }

    public GameObject GetPooledObject(string prefabName)
    {
        if (pooledObjectsDictionary.ContainsKey(prefabName) )
        {
            Queue<GameObject>objectPool = pooledObjectsDictionary[prefabName];
            if(objectPool.Count > 0)
            {
                GameObject ObjectToReuse = objectPool.Dequeue();
                ObjectToReuse.SetActive(true);
                objectPool.Enqueue(ObjectToReuse); 
                return ObjectToReuse;

            }
            else
            {
                foreach (var pooledObject in objectsToPool)
                {
                    if(pooledObject.prefab.name == prefabName)
                    {
                        GameObject newObject = Instantiate(pooledObject.prefab);
                        newObject.SetActive(true);
                        pooledObjectsDictionary[prefabName].Enqueue(newObject);
                        return newObject;
                    }
                }
            }
        }

       return null;
    }
   
}
