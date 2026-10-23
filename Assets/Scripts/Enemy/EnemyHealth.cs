using System;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int scoreReward = 20;

    private GameScore gameScore;

    [SerializeField]
    private int maxHealth = 50;

    [SerializeField]
    private float knockbackForce = 5f;
    [SerializedField]

    private float knockbackDuration = 0.2f;

    private int currentHealth;

    private bool isDead = false;

    private EnemySpawner enemySpawner;

    private Rigidbody2D rb;


    private EnemyMovement enemyMovement;

    [System.Obsolete]
    private void Awake()
    {
        currentHealth = maxHealth;
        // enemySpawner = FindFirstObjectByType<EnemySpawner>();
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();

        gameScore = FindAnyObjectByType<GameScore>();
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        enemySpawner = spawner;
    }

    public void TakeDamage(int damage, Vector2 attackerPosition)
    {
        if (isDead || damage < 0)
        {
            return;
        }

        currentHealth =
            Mathf.Max(currentHealth - damage, 0);

        Debug.Log("Enemy Health: " + currentHealth);

        if (currentHealth == 0)
        {
            Die();
        }
        ApplyKnockback(attackerPosition);
    }

    private void ApplyKnockback(Vector2 attackerPosition)
    {
        if (rb == null)
        {
            return;
        }

        Vector2 direction =
            (rb.position - attackerPosition).normalized;

        if (enemyMovement != null)
        {
            enemyMovement.ApplyKnockbackDelay(knockbackDuration);
        }

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(
            direction * knockbackForce,
            ForceMode2D.Impulse
        );
    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;

        if (gameScore != null)
        {
            gameScore.AddScore(scoreReward);
        }

        if (enemySpawner != null)
            enemySpawner.SpawnEnemy();

        Destroy(gameObject);
    }
}

internal class SerializedFieldAttribute : Attribute
{
}