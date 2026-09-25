using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyType = "Goblin";
    public int damage = 25;
    public int healthPotion = 100;
    void Start()
    {
        Debug.Log("Enemy: " + enemyType);
        Debug.Log("Damage: " + damage);
        Debug.Log("HP: " + healthPotion);
    }

    // Update is called once per frame
    void Update()
    {

    }   
}
