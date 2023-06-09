using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon Instance;
    protected float speed;
    //public Vector3 target;
    [SerializeField] Transform weaponPosition;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Fire(Vector3 target)
    {
        if (target != null)
        {
            Vector3 temp=new Vector3(target.x,this.transform.position.y,target.z);
            LeanTween.move(gameObject, target, 1f).setOnComplete(() =>
            {
                transform.position = weaponPosition.position;
            });
        }
        Debug.Log("get component");
    }
}
