using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        
        
        agent.speed = speed;
        base.OnInit();
        aIPooling = FindObjectOfType<AIPooling>();
        aIManager = FindObjectOfType<AIManager>();
        transform.position = AIManager.Instance.FindTheSpawnPosition(7f);
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
        if (!GameManager.instance.gameIsPlaying)
        {
            ChangeState(new IdleState());
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
    public Vector3 RandomPoint( float range)
    {
        Vector3 result;
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
            {
                result = hit.position;
                return result;
            }
        }
        //result = Vector3.zero;
        return RandomPoint(range);
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
