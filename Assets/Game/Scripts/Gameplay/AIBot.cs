using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBot : Character
{
    private IState currentState;
    [SerializeField] public NavMeshAgent agent;
    public bool IsAttacking => isAttack;
    private AIPooling aIPooling;
    private AIManager aIManager;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        //if (Time.timeScale < 0.01f)
        //{
        //    return;
        //}
        //IndicatorManager.Instance.CreateNewIndicator(this);
        //if (indicatorController != null)
        //{
        //    indicatorController.gameObject.SetActive(true);
        //}
        this.gameObject.SetActive(true);
        agent.speed = speed;
        base.OnInit();
        aIPooling = FindObjectOfType<AIPooling>();
        aIManager = FindObjectOfType<AIManager>();
        transform.position= new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));
        ChangeState(new IdleState());
        if (this != null)
        {
            IndicatorManager.Instance.CreateNewIndicator(this);
        }
        
    }
    // Update is called once per frame
    public override void Update()
    {
        if (Time.timeScale < 0.01f)
        {
            return;
        }
        base.Update();
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.OnExit(this);
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    protected override void OnDeath()
    {
        base.OnDeath();

    }
    protected override void OnDespawn()
    {
        //IndicatorManager.Instance.RemoveIndicator(this);
        //IndicatorController indicatorController = GetComponent<IndicatorController>();
        //if (indicatorController != null)
        //{
        //    indicatorController.gameObject.SetActive(false);
        //}
        //else
        //{
        //    Debug.Log("indicator is null");
        //}
        base.OnDespawn();
        aIManager.DespawnAI(this.gameObject);
        IndicatorManager.Instance.RemoveIndicator(this);
    }
}
