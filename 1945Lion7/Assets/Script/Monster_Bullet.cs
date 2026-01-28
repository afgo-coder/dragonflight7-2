using UnityEngine;

public class Monster_Bullet : MonoBehaviour
{
    public float Speed = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            //미사일 지우기
            Destroy(gameObject);
        }
        if (collision.CompareTag("Bomb"))
        {

            //미사일 지우기
            Destroy(gameObject);
        }
    }

}
