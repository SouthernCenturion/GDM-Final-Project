using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private List<GameObject> availableObjects;
    
    public ObjectPool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
        availableObjects = new List<GameObject>();
        
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            availableObjects.Add(obj);
        }
    }
    
    public GameObject Get()
    {
        foreach (GameObject obj in availableObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                Debug.Log("Reactivating object from pool");
                return obj;
            }
        }
        
        GameObject newObj = GameObject.Instantiate(prefab);
        availableObjects.Add(newObj);
        Debug.Log("Instantiating new object");
        return newObj;
    }
    
    public void Return(GameObject obj)
    {
        Debug.Log("Returning object to pool");
        obj.SetActive(false);
    }
}