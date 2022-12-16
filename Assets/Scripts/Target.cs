using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public Text healthText;

    public void TakeDamage (float amount)
    {
        if (gameObject.tag == "Friendly")
        {
            return;
        }
        else
        {
            if (gameObject.tag == "Enemy")
            {
                health -= amount;
                if (health <= 0f)
                {
                    Destroy(gameObject); 
                } 
            }  
            else
            {
                return;
            }    
        }
    }
}
