using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    public enum AnimationType
    {
        IDLE=0, RUN=1, WIN=2,DEAD=3,ATTACK=4,DANCE=5,ULTI=6
    }
    protected AnimationType currentAnimType = AnimationType.IDLE;
    [SerializeField] protected Animator animator;
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected SkinnedMeshRenderer characterMesh;
    [SerializeField] protected SkinnedMeshRenderer pantsMesh;
    [SerializeField] protected LayerMask myCharacter;
    protected bool isMoving;
    [SerializeField] protected Transform weaponPosition;
    public List<Material> pantMaterials;
    protected float speed =5;
    protected float radius = 14f;
    public float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected void OnInit()
    {
        ChangeAnim(AnimationType.IDLE);
        int temp=Random.Range(0,pantMaterials.Count);
        ChangeSkin(temp);
       
    }
    // Update is called once per frame
    public virtual void Update()
    {
        attackTime-=Time.deltaTime;
        if (attackTime < 0)
        {
            if (!isMoving && TheNearestCharacter(this.gameObject) != null)
            {
                Attack();

            }
        }
        
    }
    public void ChangeAnim(AnimationType _type)
    {
        if (currentAnimType != _type)
        {
            currentAnimType = _type;
            switch (_type)
            {
                case AnimationType.IDLE:
                    animator.SetTrigger("idle");
                    break;
                case AnimationType.RUN:
                    animator.SetTrigger("run");
                    break;
                case AnimationType.WIN:
                    animator.SetTrigger("win");
                    break;
                case AnimationType.DANCE:
                    animator.SetTrigger("dance");
                    break;
                case AnimationType.DEAD:
                    animator.SetTrigger("dead");
                    break;
                case AnimationType.ATTACK:
                    animator.SetTrigger("attack");
                    break;
                case AnimationType.ULTI:
                    animator.SetTrigger("ulti");
                    break;
            }
        }
    }
    protected void Attack()
    {
        attackTime = 3f;
        GameObject temp = TheNearestCharacter(this.gameObject);
        transform.LookAt(temp.transform.position);
        ChangeAnim(AnimationType.ATTACK);
        
        weapon.GetComponent<Weapon>().Fire(TheNearestCharacter(this.gameObject).transform.position);
        Debug.Log("attacking");
    }
    protected void Ulti()
    {

    }
    protected void OnDespawn()
    {

    }
    public void ChangeSkin(int colorID)
    {
        if (colorID < pantMaterials.Count)
        {
            characterMesh.material = pantMaterials[colorID];
            pantsMesh.material = pantMaterials[colorID];
        }
    }
    protected GameObject TheNearestCharacter(GameObject theGameObject)
    {
        Collider[] hitColliders = Physics.OverlapSphere(theGameObject.transform.position, radius / 2, myCharacter);
        if (hitColliders.Length > 1 && !isMoving)
        {
            float distance = 100000f;
            GameObject temp = null;
            foreach(Collider collider in hitColliders)
            {
                float tempDistance = Vector3.Distance(collider.transform.position, theGameObject.transform.position);
                if (collider.gameObject != theGameObject&&tempDistance<distance)
                {
                    temp = collider.gameObject;
                    distance = tempDistance;
                }
            }
            return temp;
            //transform.LookAt(temp.transform.position);
            //weapon.transform.position = Vector3.MoveTowards(weapon.transform.position, temp.transform.position, 3f * Time.deltaTime);
        }
        else
        {
            return null;
        }
    }
    public void ThrowWeapon()
    {

    }
    public void EndAttack()
    {

    }
   

}
