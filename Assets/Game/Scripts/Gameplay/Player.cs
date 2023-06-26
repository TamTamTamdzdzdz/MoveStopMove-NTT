using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Player : Character
{
    [SerializeField] VariableJoystick variableJoystick;
    Vector3 dir;
    [SerializeField] GameObject cylinder;
    [SerializeField]Rigidbody rb;
    [SerializeField] private TextMeshPro playerName;
    

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
        
    }
    public override void OnInit()
    {
        base.OnInit();
        isMoving = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0)
        {
            
            dir = new Vector3(this.transform.position.x + variableJoystick.Horizontal * speed * Time.deltaTime,
               this.transform.position.y, this.transform.position.z + variableJoystick.Vertical * speed * Time.deltaTime);

            isMoving = true;
            this.transform.LookAt(dir);
            Moving();
            

        }
        else if (!isAttack||!isMoving)
        {
            isMoving = false;
            rb.velocity = Vector3.zero;
            ChangeAnim(AnimationType.IDLE);
        }
        
        cylinder.transform.localScale=new Vector3(radius,cylinder.transform.localScale.y,radius);
        if (!isMoving)
        {
            if(TheNearestCharacter(this.gameObject) == null)
            {
                Debug.Log("not found");
            }
            else
            {
                Debug.Log(TheNearestCharacter(this.gameObject).name);
            }
        }

    }
    public void Moving()
    {
        ChangeAnim(AnimationType.RUN);
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.velocity=direction*speed;
    }
    protected override void OnDespawn()
    {
        base.OnDespawn();
        GameManager.instance.LosingGame();
    }
    public void ChangerPlayerName(string newPlayerName)
    {
        playerName.text=newPlayerName;
    }


}
