using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    public int HP = 100;
    public int currentHP;
    public float Speed = 3;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    SpwanManager spwanManager;

    //아이템 가져오기
    [SerializeField] //보안처리 유니티 편집할땐 보이는데 그외에는 안보이게함
    private GameObject Item;
    [SerializeField]
    private GameObject Effect;

    void Start()
    {
        spwanManager = FindAnyObjectByType<SpwanManager>();
        Invoke("CreateBullet",Delay);
        currentHP = HP;
    }
    public void Die()
    {
       
    }


    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);
        Invoke("CreateBullet", Delay);

    }

    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    
    public void Damage(int attack)
    {
        currentHP -= attack;

        GameObject go = Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(go,1f);
        if (currentHP <= 0)
        {
            //아이템 드롭
            ItemDrop();
            spwanManager.AddMonster1Kill();
            Destroy(gameObject);            
        }
    }

    public void ItemDrop()
    {
        Instantiate(Item, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //적충돌 및 삭제
            Destroy(collision.gameObject);

            //자기자신 삭제
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
