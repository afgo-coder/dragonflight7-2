using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 3f;
    public GameObject Bullet;
    public Transform pos = null;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

     
    void Update()
    {
        float x = moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime;
        float y = moveSpeed*Input.GetAxis("Vertical")* Time.deltaTime;

        transform.Translate(x,y,0);


        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            animator.SetBool("left", true);
        }
        else
        {
            animator.SetBool("left", false);
        }

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            animator.SetBool("right", true);
        }
        else
        {
            animator.SetBool("right", false);
        }      

        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            animator.SetBool("up", true);
        }
        else
        {
            animator.SetBool("up", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet,pos.position,Quaternion.identity);
        }


        // 화면 밖으로 나가지 않도록 월드 좌표를 뷰포트 좌표로 변환합니다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        // 뷰포트 x 값을 0~1 범위로 클램프합니다.
        viewPos.x = Mathf.Clamp01(viewPos.x);
        // 뷰포트 y 값을 0~1 범위로 클램프합니다.
        viewPos.y = Mathf.Clamp01(viewPos.y);
        // 클램프된 뷰포트 좌표를 다시 월드 좌표로 변환하여 적용합니다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos; // 위치 갱신
    }
    

}
