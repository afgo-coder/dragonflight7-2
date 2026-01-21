using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
    }
}
