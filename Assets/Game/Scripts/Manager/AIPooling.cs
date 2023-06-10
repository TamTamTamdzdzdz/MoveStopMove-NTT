using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPooling : MonoBehaviour
{
    private Dictionary<string,Queue<GameObject>>aiPool = new Dictionary<string,Queue<GameObject>>();
    private GameObject CreateNewObject(GameObject gameObject)
    {
        GameObject newGO=Instantiate(gameObject);
        newGO.name = gameObject.name;
        newGO.transform.parent=this.transform;
        return newGO;
    }
    public GameObject GetObject(GameObject gameObject)
    {
        if(aiPool.TryGetValue(gameObject.name, out Queue<GameObject> aiList))
        {
            if(aiList.Count > 0)
            {
                GameObject _object= aiList.Dequeue();
                
                _object.SetActive(true); 
                return _object;
            }
            else
            {
                return CreateNewObject(gameObject);
            }
        }
        else
        {
            return CreateNewObject(gameObject);
        }
        
    }
    public void ReturnAI(GameObject gameObject)
    {
        if(aiPool.TryGetValue(gameObject.name,out Queue<GameObject> aiList))
        {
            aiList.Enqueue(gameObject);
        }
        else
        {
            Queue<GameObject>queue= new Queue<GameObject>();
            queue.Enqueue(gameObject);
            aiPool.Add(gameObject.name, queue);
        }
        gameObject.SetActive(false);
    }
}
