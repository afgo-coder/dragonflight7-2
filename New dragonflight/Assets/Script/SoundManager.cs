using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance; //싱글톤변수

    AudioSource myAudio; //AudioSource 컴포넌트 변수로 담는다.


    public AudioClip die; 
    public AudioClip soundBullet;
    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void SoundDie()
    {
        myAudio.PlayOneShot(die); //몬스터 죽는소리
    }
    public void SoundShoot()
    {
        myAudio.PlayOneShot(soundBullet);
    }

    void Update()
    {
        
    }
}
