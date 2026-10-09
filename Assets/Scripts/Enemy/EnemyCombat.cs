using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    [SerializeField]
    private float attackCooldown = 1f;

    private float nextAttackTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time < nextAttackTime)
        {
            return;
        }

        PlayerHealth playerHealth =
            collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }


}
