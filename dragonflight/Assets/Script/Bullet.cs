using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.8f;
    public GameObject effect;

    void Start()
    {
        
    }


    void Update()
    {
        //y축 이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    //화면밖으로 나가면 호출되는 함수
    private void OnBecameInvisible()
    {
        //미사일 지우기
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //trigger 충돌일경우 한번 실행
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //이펙트 생성 및 사운드출력
            GameObject go = Instantiate(effect,transform.position,Quaternion.identity);
            SoundManager.instance.SoundDie();
            Destroy(go,1);

            //점수
            Gamemanager.instance.AddScore(100);

            //미사일충돌 및 삭제
            Destroy(collision.gameObject);

            //자기자신 삭제
            Destroy(gameObject);
        }
    }

}
