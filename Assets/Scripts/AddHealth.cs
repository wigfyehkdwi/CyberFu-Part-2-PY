using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddHealth : MonoBehaviour
{
    public Text healthText;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
private void Start()
    {
        GameObject BluePlayer = GameObject.Find("BluePlayer");

        playerHealth = BluePlayer.GetComponent<PlayerHealth>();
        if (!playerHealth)
        {
            healthText.text = "error";
        }

    }
    



    // Update is called once per frame
    void Update()
    {
        if(playerHealth){
            //Debug.Log(playerHealth.currentPlayerHealth);
            healthText.text = playerHealth.currentPlayerHealth.ToString();
        }
    }

    // public void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Health")
    //     {
    //         if (playerHealth.currentHealth < 10)
    //         {
    //             playerHealth.currentHealth += playerHealth.healthToGive;
    //             print("Healed!");
    //         }
    //         else if (playerHealth.currentHealth == 10)
    //         {
    //             return;
    //         }
    //     }
    //}
}
