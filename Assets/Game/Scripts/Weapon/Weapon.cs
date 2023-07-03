using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon Instance;
    protected float speed=10f;
    public Vector3 target;
    [SerializeField] Transform weaponPosition;
    [SerializeField] public GameObject weaponParent;
    public Vector3 direction;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Fire(Vector3 _target)
    {
     
        
        
        
        
        
        
        
        if (_target != null)
        {
            //    direction=new Vector3(_target.x-transform.position.x,)


            //target = _target;
            Vector3 temp = new Vector3(_target.x, this.transform.position.y, _target.z);
            float distance = Vector3.Distance(this.transform.position, temp);
            transform.LookAt(_target);
            LeanTween.move(gameObject, temp, distance / speed).setOnComplete(() =>
            {
                GameObject.Destroy(this.gameObject);
            });
        }
        Debug.Log("get component");


        
    }
    private void SetRotation(Vector3 upwards)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction, upwards);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * 1f);
        gameObject.transform.eulerAngles += new Vector3(-90, 0, 0);
    }
}
