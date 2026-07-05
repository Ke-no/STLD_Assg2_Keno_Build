using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 10;

    [Header("Lava")]
    public bool isLava = false;
    public float damageInterval = 1f;

    private float nextDamageTime;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if (playerHealth == null)
        return;

        if (isLava)
        {
            playerHealth.TakeDamage(damage);
            nextDamageTime = Time.time + damageInterval;
        }
        else
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(!isLava)
        return;

        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if (playerHealth == null)
        return;

        if (Time.time >= nextDamageTime)
        {
            playerHealth.TakeDamage(damage);
            nextDamageTime = Time.time + damageInterval;
        }
    }
}