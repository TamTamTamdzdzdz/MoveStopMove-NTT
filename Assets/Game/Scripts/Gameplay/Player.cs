using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Player : Character
{
    [SerializeField] public VariableJoystick variableJoystick;
    Vector3 dir;
    [SerializeField] GameObject cylinder;
    [SerializeField]public Rigidbody rb;
    [SerializeField] private TextMeshPro playerName;
    private PlayerState currentState;
    
    

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
        
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new PlayerIdleState());
        this.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
        if (!GameManager.instance.gameIsPlaying)
        {
            ChangeState(new PlayerIdleState());
        }






        
        base.Update();
        
        
        // if (!isAttack||!isMoving)
        //{
        //    isMoving = false;
        //    rb.velocity = Vector3.zero;
        //    ChangeAnim(AnimationType.IDLE);
        //}
        
        cylinder.transform.localScale=new Vector3(radius,cylinder.transform.localScale.y,radius);
        

    }
    public void Moving()
    {
        dir = new Vector3(this.transform.position.x + variableJoystick.Horizontal * speed * Time.deltaTime,
               this.transform.position.y, this.transform.position.z + variableJoystick.Vertical * speed * Time.deltaTime);

        isMoving = true;
        this.transform.LookAt(dir);
        ChangeAnim(AnimationType.RUN);
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.velocity=direction*speed;
    }
    protected override void OnDespawn()
    {
        if(LosingMenu.instance != null)
        {
            LosingMenu.instance.DefineTheRank();
        }
        else
        {
            Debug.Log("losing menu is null");
        }
        
        base.OnDespawn();
        
        GameManager.instance.LosingGame();
        ChangeState(new PlayerDeathState());
        
        
    }
    public void ChangerPlayerName(string newPlayerName)
    {
        playerName.text=newPlayerName;
    }
    public void Revive()
    {
        
        ChangeState(new PlayerIdleState());
    }
    public void ChangeState(PlayerState newState)
    {
        if (currentState != null)
            currentState.OnExit(this);
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }


}
