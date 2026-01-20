using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = -1f;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        //움직임을 변수로 만들기
        float distanceY = moveSpeed * Time.deltaTime;
        transform.Translate(0, distanceY, 0);
    }

    //(컨트롤 + 쉬프트 + M) 유니티 명령어 찾기
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //trigger 충돌일경우 한번 실행
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        //미사일충돌 및 삭제
    //        Destroy(collision.gameObject);

    //        //자기자신 삭제
    //        Destroy(gameObject);
    //    }   
    //}

    




}
