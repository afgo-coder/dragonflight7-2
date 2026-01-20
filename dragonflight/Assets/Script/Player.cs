using UnityEngine;

public class Player : MonoBehaviour
{

    //스피드
    public float moveSpeed = 3;

    void Start()
    {
        
    }

    
    void Update()
    {
        //x쪽 값 설정 vector 방향 * 시간 * 스피드
        float distanceX=Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //x쪽 이동설정
        transform.Translate(distanceX, 0, 0);
    }

    //둘다 트리거가 아닐때
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        //적 삭제
    //        Destroy(collision.gameObject);

    //        //플레이어 삭제
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //trigger 충돌일경우 한번 실행
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        //적충돌 및 삭제
    //        Destroy(collision.gameObject);

    //        //자기자신 삭제
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //trigger 충돌일경우 한번 실행
        if (collision.gameObject.tag == "Enemy")
        {
            //적충돌 및 삭제
            Destroy(collision.gameObject);

            //자기자신 삭제
            Destroy(gameObject);
        }
    }
}
