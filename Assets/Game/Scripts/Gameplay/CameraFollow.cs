using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float speed = 20, asixY, asixZ;
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(target.position.x, target.position.y, target.position.z);

        //target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, offset + target.position, Time.deltaTime * speed);
        this.transform.position = new Vector3(target.position.x, target.position.y +asixY, target.position.z + asixZ);
    }
}