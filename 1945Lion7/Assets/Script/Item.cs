using UnityEngine;

public class Item : MonoBehaviour
{
    //아이템 가속 속도
    public float Itemvelocity = 100f;
    Rigidbody2D rig = null;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(Itemvelocity, Itemvelocity, 0f));
    }

    
    void Update()
    {
        
    }
}
