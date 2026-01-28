using UnityEngine;

public class Homing : MonoBehaviour
{
    //A - B 벡터빼기는
    //A를 바라보는 벡터가 나온다.

    //B - A 벡터
    //B를 바라보는 벡터가 나온다.

    //적미사일이 플레이어를 바라보는 벡터

    public GameObject target; //플레이어
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        //첫 발사때만 계산해서 유도
        //Update에 넣는다면 평생 유도

        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");

        //A - B A를 바라보는 벡터 플레이어 - 미사일
        dir = target.transform.position - transform.position;

        //방향벡터만 구하기 단위벡터 정규화 노말 1의 크기로 만든다.
        dirNo = dir.normalized; //위에서 찾은 벡터의 방향만 찾는다.


    }

     
    void Update()
    {
        transform.Translate(dirNo * Speed * Time.deltaTime);
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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
