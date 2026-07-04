using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    public int damage = 10;

    public bool continuousDamage = false;
    public float damageInterval = 1f;

    private float nextDamageTime;

    private void OnTriggerEnter(Collider other)
    {
        if(continuousDamage)
        return;

        PlayerHealth playerHealth = 
            other.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(!continuousDamage)
        return;

        PlayerHealth playerHealth =
        other.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null)
        {
            if (Time.time >= nextDamageTime)
            {
                playerHealth.TakeDamage(damage);
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}
