using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //public int enemyHealth;
    public int currentEnemyHealth = 3;
    public int damageToGive = 1;
    private Animator anim;
    public EnemyExplosionParticles explosionParticles;
    // Start is called before the first frame update

    public void HurtEnemy()
    {
        {
            currentEnemyHealth -= damageToGive;
        }
    }
    void Start()
    {
        //currentHealth = 10;
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHitCollider")
        {
            anim.SetTrigger("Hit");
            HurtEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyHealth <= 0)
        {
            explosionParticles.Explode();
        }

    }
}
