using System.Collections;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public GameObject Monster1;   // 적 프리팹
    public GameObject Monster2;   // 적 프리팹
    public GameObject Boss;
    //보스
    public float spawnInterval = 1.5f; // 생성 간격
    public float spawnY = 5f;          // 화면 상단 Y 위치
    public float minX = -2.5f;         // 왼쪽 경계
    public float maxX = 2.5f;          // 오른쪽 경계
    public float spawnStop = 80f;

    private int monster1KillCount = 0;
    private bool spawnMonster2 = false;

    [SerializeField]
    GameObject textBossWarning;

    private void Awake()
    {
        textBossWarning.SetActive(false);
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
        Invoke("Stopspawn", spawnStop);
    }
 
    void SpawnEnemy()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);

        // Monster2 차례면
        if (spawnMonster2)
        {
            Instantiate(Monster2, spawnPos, Quaternion.identity);
            spawnMonster2 = false; // 다시 Monster1로 돌아감
        }
        else
        {
            Instantiate(Monster1, spawnPos, Quaternion.identity);
        }
    }
    // Monster1이 죽을 때 호출
    public void AddMonster1Kill()
    {
        monster1KillCount++;

        if (monster1KillCount >= 5)
        {
            spawnMonster2 = true;
            monster1KillCount = 0; // 다시 카운트 초기화
        }
    }
    void Stopspawn()
    {
        CancelInvoke("SpawnEnemy");
        textBossWarning.SetActive(true);
        StartCoroutine("Shake");
        Debug.Log("스폰 중지됨");
        Vector3 pos = new Vector3(0, 3f, 0);
        Instantiate(Boss, pos, Quaternion.identity);

    }

    IEnumerator Shake()
    {
        int shakeCnt = 30;
        while (shakeCnt > 0)
        {
            CameraImpulse.Instance.CameraShakeShow();
            yield return new WaitForSeconds(0.1f);
            shakeCnt--;
        }

    }


    void Update()
    {
        
    }
}
