using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject effect;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.up*moveSpeed*Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    


}
