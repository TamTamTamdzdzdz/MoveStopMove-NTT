using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LosingMenu : MonoBehaviour
{
    public static LosingMenu instance { get; private set; }
    [SerializeField] TMP_Text theKiller;
    [SerializeField] Button continueButton;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DefineTheRank()
    {
        theKiller.text = "You are killed.\n Rank # " + AIManager.Instance.maxNumber;
    }
}
