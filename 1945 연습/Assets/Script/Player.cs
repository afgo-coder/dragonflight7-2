using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 3f;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

     
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // 이동
        transform.Translate(x * moveSpeed * Time.deltaTime,y * moveSpeed * Time.deltaTime,0);

        if (x != 0)
        {
            animator.SetFloat("MoveX", x);
        }

        // 이동 중인지 여부
        bool isMoving = (x != 0 || y != 0);
        animator.SetBool("IsMoving", isMoving);
    }
}
