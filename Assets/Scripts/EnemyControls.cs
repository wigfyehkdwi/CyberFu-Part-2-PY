using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float speed = 5f;
    public float attackingDistance = 1f;

    private Animator anim;
    private Rigidbody rb;
    private Transform target;
    public Vector3 direction;
    private float chasingPlayer = 0.01f;
    private float currentAttackingTime;
    private float maxAttackingTime = 2f;
    private bool followTarget;
    private bool attackTarget;
    private GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = GameObject.Find("Generic Man");
        followTarget = true;
        currentAttackingTime = maxAttackingTime;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player && player.activeInHierarchy)
        {
            target = player.transform;
        } else
        {
            target = null;
        }
        
    }

    private void Update()
    {
        Attack();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (!target) return;
        if (!followTarget)
        {
            rb.isKinematic = true;
            return;
        }

        if(!playerModel.activeInHierarchy){
            return;
        }

        if(Vector3.Distance(transform.position, target.position) >= attackingDistance)
        {
            rb.isKinematic = false;
            direction = target.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 100f);

            if (rb.velocity.sqrMagnitude != 0)
            {
                rb.velocity = transform.forward * speed;
                anim.SetBool("Walk", true);
            }
        }
        else if(Vector3.Distance(transform.position, target.position) <= attackingDistance)
        {
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            anim.SetBool("Walk", false);

            followTarget = false;
            attackTarget = true;
        }
    }

    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger("Attack1");
        }

        if (attack == 1)
        {
            anim.SetTrigger("Attack2");
        }

        if (attack == 2)
        {
            anim.SetTrigger("Attack3");
        }
    }

    void Attack()
    {
        
        if(!playerModel.activeInHierarchy){
            return;
        }
        if (!attackTarget)
        {
            return;
        }

        currentAttackingTime += Time.deltaTime;

        if(currentAttackingTime > maxAttackingTime)
        {
            EnemyAttack(Random.Range(0, 3));
            currentAttackingTime = 0f;
        }

        if(Vector3.Distance(transform.position, target.position) > attackingDistance + chasingPlayer)
        {
            attackTarget = false;
            followTarget = true;
        }
    }
}
