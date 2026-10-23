using UnityEngine;

public class WorldItem : MonoBehaviour
{
    // private int uniqueId;
    // public int UniqueId
    // {
    //     get { return uniqueId; }
    //     set { uniqueId = value; }
    // }

    [SerializeField] private string uniqueId;
    public string UniqueId => uniqueId;

}
