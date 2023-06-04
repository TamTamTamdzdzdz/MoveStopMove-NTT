using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected float speed;
    public Vector3 target;
    [SerializeField] Transform weaponPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Fire()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(weaponPosition.position, target, speed * Time.deltaTime);
        }
    }
}
