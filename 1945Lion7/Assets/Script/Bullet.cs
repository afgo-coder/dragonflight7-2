using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.0f;
    //공격력
    public int attack = 20;
    //이펙트
    public GameObject effect;

    void Start()
    {
        
    }

    void Update()
    {
        //미사일 위쪽방향으로 움직이기
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Monster enemy = collision.GetComponent<Monster>();
            Monster2 enemy2 = collision.GetComponent<Monster2>();
            if (enemy != null)
            {
                enemy.Damage(attack); // 체력 감소
             
            }
            if (enemy2 != null)
            {
                enemy2.Damage(attack); // 체력 감소

            }


            //미사일 지우기
            Destroy(gameObject);          
        }
        if (collision.CompareTag("Boss"))
        {
            Boss boss = collision.GetComponent<Boss>();

            if (boss != null)
            {
                boss.Damage(attack); // 체력 감소
                GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(go, 1f);
            }


            //미사일 지우기
            Destroy(gameObject);
        }
    }



}
