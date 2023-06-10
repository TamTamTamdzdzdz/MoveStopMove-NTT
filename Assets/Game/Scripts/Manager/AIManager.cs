using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
   [SerializeField] private int maxNumber = 100;
   [SerializeField] private int currentNumber = 5;
    private AIPooling aIPooling;
    [SerializeField] GameObject aIPrefab;
    // Start is called before the first frame update
    void Start()
    {
        aIPooling=FindObjectOfType<AIPooling>();
        
        for(int i = 0; i< currentNumber; i++)
        {
            GameObject aiBot= aIPooling.GetObject(aIPrefab);    
            if(aiBot!=null)
            {
                
                    
            }
            else
            {
                Debug.Log("aibot is null");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DespawnAI(GameObject aIBot)
    {
        if (maxNumber > 0)
        {
            maxNumber--;
            aIPooling.ReturnAI(aIBot);
            StartCoroutine(RespawnAI(aIBot));
        }
        else
        {
            Debug.Log("end game");
        }
    }
    public IEnumerator RespawnAI(GameObject aIBot)
    {
        yield return new WaitForSeconds(2f);
        GameObject newAI = aIPooling.GetObject(aIPrefab);
        newAI.GetComponent<AIBot>().OnInit();
    }
}
