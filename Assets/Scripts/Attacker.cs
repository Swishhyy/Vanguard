using UnityEngine;

public class Attacker : MonoBehaviour
{
    public float attackRange = 1f; // The range at which the attacker can attack
    public float attackDamage = 10f; // The amount of damage dealt by each attack
    public float detectionRange = 99999f; //Range of Detection for the AI

    void Update()
    {
        // Find all colliders within the detection range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);

        GameObject closestFriendly = null;
        float closestDistance = Mathf.Infinity;

        // Find the closest "Friendly" object
        foreach (Collider col in hitColliders)
        {
            if (col.gameObject.tag == "Friendly")
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestFriendly = col.gameObject;
                }
            }
        }   
        // If a "Friendly" object was found, chase it
        if (closestFriendly != null)
        {
            // Move towards the closest "Friendly" object
            transform.position = Vector3.MoveTowards(transform.position, closestFriendly.transform.position, Time.deltaTime);

            // Check if the attacker is within range of the "Friendly" object
            if (Vector3.Distance(transform.position, closestFriendly.transform.position) < attackRange)
            {
                // Send the damage to the "Friendly" object's "playerhealth" component
                closestFriendly.GetComponent<playerhealth>().damageReceived += attackDamage;
            }
        }
    }
}



