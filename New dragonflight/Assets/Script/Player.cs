using UnityEngine;

public class Plater : MonoBehaviour
{
    
    public float moveSpeed = 1.0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float distanceX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(distanceX, 0,0);
    }

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
