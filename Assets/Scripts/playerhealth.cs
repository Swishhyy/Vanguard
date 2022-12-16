using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    public float health = 100f;
    public float damageReceived; // New field to receive the damage
    public Text healthText;

    public void TakeDamage ()
    {
        if (gameObject.tag == "Friendly")
        {
            health -= damageReceived; // Decrease the health by the received damage
            
            if (health <= 0f)
            {
                Destroy(gameObject); 
            } 
        }
    }

    void Update()
    {
        healthText.text = health.ToString();
    }
}
