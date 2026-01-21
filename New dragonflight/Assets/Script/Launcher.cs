using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 0.6f);
    }

    void Shoot()
    {
        SoundManager.instance.SoundShoot();
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
