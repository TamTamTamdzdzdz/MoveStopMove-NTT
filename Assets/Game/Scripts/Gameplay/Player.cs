using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Player : Character
{
    [SerializeField] VariableJoystick variableJoystick;
    Vector3 dir;
    [SerializeField] GameObject cylinder;
    [SerializeField]Rigidbody rb;
    protected bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        base.OnInit();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0)
        {
            
            dir = new Vector3(this.transform.position.x + variableJoystick.Horizontal * speed * Time.deltaTime,
               this.transform.position.y, this.transform.position.z + variableJoystick.Vertical * speed * Time.deltaTime);

            isMoving = true;
            this.transform.LookAt(dir);
            Moving();
            

        }
        else
        {
            isMoving=false;
            rb.velocity = Vector3.zero;
            ChangeAnim(AnimationType.IDLE);
        }
        cylinder.transform.localScale=new Vector3(radius,cylinder.transform.localScale.y,radius);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius/2);
        if(hitColliders.Length > 0&&!isMoving)
        {
            Debug.Log("the number of list is "+hitColliders.Length);
            GameObject temp = hitColliders[0].gameObject;
            transform.LookAt(temp.transform.position);
            weapon.transform.position=Vector3.MoveTowards(weapon.transform.position,temp.transform.position,3f*Time.deltaTime);
        }
        
    }
    public void Moving()
    {
        ChangeAnim(AnimationType.RUN);
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.velocity=direction*speed;
    }

}
