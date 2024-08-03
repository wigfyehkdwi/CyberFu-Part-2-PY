using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddScore.score += 1;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
