using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 10;
    public string gender = "male";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Player started!!!");
        Debug.Log("Player Level: " + level);
        Debug.Log("Player gender:" + gender);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
