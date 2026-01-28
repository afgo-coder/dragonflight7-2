using UnityEngine;

public class BossBullet : MonoBehaviour
{
    //총알 속도
    public float Speed = 3f;
    //총알 방향
    Vector2 vec2 = Vector2.down;
    void Start()
    {
        
    }

    
    void Update()
    {
        //총알 이동
        transform.Translate(vec2*Speed*Time.deltaTime);
    }

    public void Move(Vector2 vec)
    {
        //이동방향 설정
        vec2 = vec;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Bomb"))
        {

            //미사일 지우기
            Destroy(gameObject);
        }
    }

}
