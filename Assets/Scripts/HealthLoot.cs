using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph.currentPlayerHealth < 10)
            {
                ph.currentPlayerHealth += 1;
            }
        }
        Destroy(this.gameObject);
    }
}
