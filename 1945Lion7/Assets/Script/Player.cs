using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator ani; //애니메이터 컴포넌트

    public GameObject[] bullet; //미사일프리팹 배열로구성
    public Transform pos = null;
    //미사일 파워업
    public int power = 0;
    [SerializeField]
    private GameObject powerup; //파워업문구
    public GameObject lazer;
    public GameObject bomb;
    [Header("레이저")]    
    public float gValue = 0;
    public Image Gage;
    public float cooldownDuration = 3f;
    bool canCharge = true;
    public float slowTimeScale = 0.2f;
    float normalFixedDeltaTime;

    void Start()
    {
        ani = GetComponent<Animator>();
        // 플레이어 액티브 애니메이터는 언스케일드 타임으로 업데이트하여 슬로우모션에 영향 받지 않음
        ani.updateMode = AnimatorUpdateMode.UnscaledTime;
        // 초기 FixedDeltaTime 저장
        normalFixedDeltaTime = Time.fixedDeltaTime;
    }

    
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        //-1 0 1
        // Left Shift 누르면 전체 시간 느리게 (플레이어 제외)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = slowTimeScale;
            Time.fixedDeltaTime = normalFixedDeltaTime * slowTimeScale;
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = normalFixedDeltaTime;
        }
        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani .SetBool("left", false);
        }


        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }
        transform.Translate(moveX, moveY, 0);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(bomb, Vector3.zero, Quaternion.identity);
        }
        //미사일 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //미사일생성
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            // 충전 허용 상태에서만 게이지 증가 (게이지는 타임스케일의 영향을 받음)
            if (canCharge)
            {
                gValue += Time.deltaTime;
                Gage.fillAmount = gValue;
                if (gValue >= 1)
                {
                    GameObject go = Instantiate(lazer, pos.position, Quaternion.identity);
                    Destroy(go, 3);
                    gValue = 0;
                    // 충전 비활성화 및 쿨다운 코루틴 시작 (쿨다운은 시간 스케일 영향을 받음)
                    StartCoroutine(LazerCooldown());
                }
            }
            else
            {
                // 쿨다운 중이면 게이지는 유지
                Gage.fillAmount = gValue;
            }
        }
        else
        {
            gValue -= Time.deltaTime;

            if (gValue <= 0)
            {
                gValue = 0;
            }

            //게이지바 UI표시
            Gage.fillAmount = gValue;

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
    System.Collections.IEnumerator LazerCooldown()
    {
        canCharge = false;
        yield return new WaitForSeconds(cooldownDuration);
        canCharge = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            power += 1;
            if (power >= 3)
            {
                power = 3;
            }
            else
            {
                GameObject go = Instantiate(powerup, transform.position, Quaternion.identity);
                Destroy(go, 1);
            }          
                Destroy(collision.gameObject);
        }
        //if (collision.CompareTag("MBullet"))
        //{
        //    Destroy(collision.gameObject);

        //    Destroy(gameObject);
        //}
    }









}
