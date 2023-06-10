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
        base.OnInit();
        aIPooling = FindObjectOfType<AIPooling>();
        aIManager = FindObjectOfType<AIManager>();
        transform.position= new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));
        ChangeState(new IdleState());
        
    }
    // Update is called once per frame
    public override void Update()
    {
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
        base.OnDespawn();
        aIManager.DespawnAI(this.gameObject);
    }
}
