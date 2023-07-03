using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Character : MonoBehaviour
{
    public enum AnimationType
    {
        IDLE=0, RUN=1, WIN=2,DEAD=3,ATTACK=4,DANCE=5,ULTI=6
    }
    [SerializeField] protected AnimationType currentAnimType = AnimationType.IDLE;
    [SerializeField] protected Animator animator;
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected SkinnedMeshRenderer skinMesh;
    [SerializeField] protected SkinnedMeshRenderer pantsMesh;
    [SerializeField] protected LayerMask myCharacter;
    [SerializeField] Transform attachIndicatorPoint;
    [SerializeField] protected int level = 0;
    public int Level => level;
    
    public Transform AttachIndicatorPoint => attachIndicatorPoint;
    public bool isMoving=false;
    [SerializeField] protected Transform weaponTransform;
    [SerializeField] protected Transform weaponBase;
    //public List<Material> pantMaterials;
    protected float speed =10f;
    protected float radius = 14f;
    //public bool isDead=false;
    public float attackTime;
    public bool isAttack=false;
    
    [SerializeField] protected PantsData pantsData;
    [SerializeField] protected SkinData skinData;
    // Start is called before the first frame update
    void Start()
    {
        //OnInit();
    }
    public virtual void OnInit()
    {
        //isDead=false;
        
        pantsMesh.material= pantsData.GetPantsMat(Random.Range(0, pantsData.listMaterial.Count));
        skinMesh.material = skinData.GetSkinMat(Random.Range(0, skinData.listMaterial.Count));

    }
    // Update is called once per frame
    public virtual void Update()
    {
        //attackTime-=Time.deltaTime;
        //if (attackTime < 0)
        //{
        //    if (!isMoving && TheNearestCharacter(this.gameObject) != null&&GameManager.instance.gameIsPlaying)
        //    {
                
        //        Attack();

        //    }
        //    else
        //    {
        //        isAttack = false;
        //    }
        //}
        //else
        //{
        //    if (isMoving)
        //    {
        //        attackTime = 0;
        //    }
        //}

        //if (!isAttack && !isMoving)
        //{
        //    Debug.Log("2");
        //    ChangeAnim(AnimationType.IDLE);
        //}


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
                    Debug.Log("animation is idle");
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
    public void Attack()
    {
        
        
        GameObject temp = TheNearestCharacter(this.gameObject);
        transform.LookAt(new Vector3(temp.transform.position.x,this.transform.position.y,temp.transform.position.z));
        ChangeAnim(AnimationType.ATTACK);
        isAttack = true;
        
        StartCoroutine(ThrowWeapon());
        StartCoroutine(EndAttack());
        //StartCoroutine(EndAttack());


    }
    protected void Ulti()
    {

    }
    protected virtual void OnDeath()
    {
        
        ChangeAnim(AnimationType.DEAD);
        Invoke(nameof(OnDespawn), 0.5f);
    }
    protected virtual void OnDespawn()
    {
        
    }
    //public void ChangeSkin(int colorID,List<Material>)
    //{
    //    if (colorID < pantMaterials.Count)
    //    {
    //        //skinMesh.material = pantMaterials[colorID];
    //        pantsMesh.material = pantMaterials[colorID];
    //    }
    //}
    public GameObject TheNearestCharacter(GameObject theGameObject)
    {
        Collider[] hitColliders = Physics.OverlapSphere(theGameObject.transform.position, radius / 2, myCharacter);
        if (hitColliders.Length > 1 && !isMoving)
        {
            float distance = 100000f;
            GameObject temp = null;
            foreach(Collider collider in hitColliders)
            {
                Character character=collider.GetComponent<Character>();
                float tempDistance = Vector3.Distance(collider.transform.position, theGameObject.transform.position);
                if (collider.gameObject != theGameObject&&tempDistance<distance/*&&!character.isDead*/)
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
    public IEnumerator ThrowWeapon()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject target = TheNearestCharacter(this.gameObject);
        if (target != null)
        {
            
            GameObject weaponObject = GameObject.Instantiate(weapon);
            //weaponObject.transform.position = weaponBase.transform.position;
            //weaponObject.transform.rotation = weaponBase.transform.rotation;
            weaponObject.transform.position=weaponBase.transform.position;
           
            weaponObject.transform.LookAt(target.transform.position);
            
            weaponObject.GetComponent<Weapon>().Fire(target.transform.position);
            
            weaponBase.gameObject.SetActive(false);
            
        }
       

    }
    public IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(1f);
        ChangeAnim(AnimationType.IDLE);
        
        weaponBase.gameObject.SetActive(true);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Weapon weapon = other.GetComponent<Weapon>();
        if (weapon != null&&weapon.weaponParent!=gameObject)
        {
            Debug.Log(this.gameObject.name+ " other is "+other.gameObject.name);
            this.OnDeath();
        }
        
    }


}
