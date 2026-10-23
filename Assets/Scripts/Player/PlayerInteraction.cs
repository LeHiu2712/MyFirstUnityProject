using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameScore gameScore;

    private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }
    // [SerializeField]
    // private int attackDamage = 10;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("You hit: " + collision.gameObject.name);
        }
        // else if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        //     if (enemyHealth != null)
        //     {
        //         enemyHealth.TakeDamage(attackDamage);
        //     }
        // }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerInventory == null)
        {
            return;
        }

        //1.Xu ly coin
        if (collision.CompareTag("Coin"))
        {
            if (gameScore == null)
            {
                return;
            }

            string coinName = collision.gameObject.name.Trim();

            var points = coinName switch
            {
                "BronzeCoin" => 1,
                "SilverCoin" => 5,
                "GoldenCoin" => 10,
                _ => 1,
            };
            playerInventory.AddCoin(1);
            gameScore.AddScore(points);

            Destroy(collision.gameObject);
            return;
        }

        //2.Xu ly item
        ItemPickup itemPickup = collision.GetComponent<ItemPickup>();
        if (itemPickup != null)
        {
            Item item = itemPickup.CreateItem();
            playerInventory.AddItem(item);
            Debug.Log("Picked up: " + item.ItemName);
            Destroy(collision.gameObject);
        }

        // Debug.Log("You received a coin!");
    }
}
