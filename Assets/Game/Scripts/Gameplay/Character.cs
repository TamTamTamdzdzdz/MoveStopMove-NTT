using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<Material> pantMaterials;
    protected float speed = 5;
    protected float radius = 14f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected void OnInit()
    {
        ChangeAnim(AnimationType.IDLE);
        int temp=Random.Range(0,8);
        ChangeSkin(temp);
       
    }
    // Update is called once per frame
    void Update()
    {
        
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

    }
    protected void Ulti()
    {

    }
    protected void OnDespawn()
    {

    }
    protected void ChangeSkin(int colorID)
    {
        if (colorID < pantMaterials.Count)
        {
            characterMesh.material = pantMaterials[colorID];
            pantsMesh.material = pantMaterials[colorID];
        }
    }
   

}
