using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int Attack = 10;

    void Start()
    {
        //플레이어를 계속 찾는 레이저
        pos = GameObject.FindWithTag("Player").GetComponent<Player>().pos;
    }


    void Update()
    {
        //플레이어 포지션 넣어주기
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Monster enemy = collision.GetComponent<Monster>();
            Monster2 enemy2 = collision.GetComponent<Monster2>();
            if (enemy != null)
            {
                enemy.Damage(Attack++); // 체력 감소
                CreateEffect(collision.transform.position);
            }
            if (enemy2 != null)
            {
                enemy2.Damage(Attack++); // 체력 감소
                CreateEffect(collision.transform.position);
            }

        }

        if (collision.CompareTag("Boss"))
        {
            Boss boss = collision.GetComponent<Boss>();

            if (boss != null)
            {
                boss.Damage(Attack++); // 체력 감소
                CreateEffect(collision.transform.position);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Monster enemy = collision.GetComponent<Monster>();
            Monster2 enemy2 = collision.GetComponent<Monster2>();
            if (enemy != null)
            {
                enemy.Damage(Attack++); // 체력 감소
                CreateEffect(collision.transform.position);
            }
            if (enemy2 != null)
            {
                enemy2.Damage(Attack++); // 체력 감소
                CreateEffect(collision.transform.position);
            }
           
        }       
      
        if (collision.CompareTag("Boss"))
        {
            Boss boss = collision.GetComponent<Boss>();

            if (boss != null)
            {
                boss.Damage(Attack++); // 체력 감소
                CreateEffect(collision.transform.position);
            }         
        }
    }

    void CreateEffect(Vector3 position)
    {
        GameObject go = Instantiate(effect, position, Quaternion.identity);
        Destroy(go, 1);
    }

}