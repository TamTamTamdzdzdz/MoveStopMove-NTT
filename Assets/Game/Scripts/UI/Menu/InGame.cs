using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGame : MonoBehaviour
{
    [SerializeField] private TMP_Text aliveAmount;



    private void Update()
    {
        if(AIManager.Instance != null)
        {
            aliveAmount.text = "Alive: " + AIManager.Instance.maxNumber;
        }
        else
        {
            Debug.LogWarning("aimanager is null");
        }
    }
}
