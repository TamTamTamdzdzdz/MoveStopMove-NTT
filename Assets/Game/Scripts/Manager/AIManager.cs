using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager Instance { get; private set; }
   [SerializeField] public int maxNumber = 25;
   [SerializeField] private int currentMax = 10;
    private AIPooling aIPooling;
    [SerializeField] GameObject aIPrefab;
    public List<GameObject> listAI = new List<GameObject>();
    private int alive;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        alive = maxNumber;
    }
    public void SpawnAIBot()
    {
        maxNumber = alive;
        aIPooling = FindObjectOfType<AIPooling>();
        
        for (int i = 0; i < currentMax; i++)
        {
            GameObject aiBot = aIPooling.GetObject(aIPrefab);

            listAI.Add(aiBot);

            
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

            listAI.Remove(aIBot);
            aIPooling.ReturnAI(aIBot);
            if (listAI.Count > 0)
            {

                StartCoroutine(RespawnAI(aIBot));
            }
        }
        else
        {
            GameManager.instance.WinningGame();
        }
    }
    public IEnumerator RespawnAI(GameObject aIBot)
    {
        yield return new WaitForSeconds(2f);
        GameObject newAI = aIPooling.GetObject(aIPrefab);
        newAI.GetComponent<AIBot>().OnInit();
        listAI.Add(newAI);
        maxNumber--;
    }
    public void ClearAIBot()
    {
        foreach(var ai in listAI)
        {
            aIPooling.ReturnAI(ai);

        }
        listAI.Clear();
    }
}
