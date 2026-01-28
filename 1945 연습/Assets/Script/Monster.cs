using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public GameObject effect;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //trigger 충돌일경우 한번 실행
        if (collision.gameObject.CompareTag("Bullet"))
        {

            //적충돌 및 삭제
            Destroy(collision.gameObject);

            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);

            //자기자신 삭제
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
