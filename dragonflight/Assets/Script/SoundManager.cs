using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    //싱글톤 활용
    public static SoundManager instance; //싱글톤 변수

    AudioSource myAudio; //AudioSource 컴포넌트 변수로 담는다.

    public AudioClip soundBullet;
    public AudioClip soundDie;

    private void Awake()
    {
        if (instance == null)
        instance = this;
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>(); //AudioSource 컴포넌트 가져오기
    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie); //몬스터 죽는소리
    }
    public void SoundBullet()
    {
        myAudio.PlayOneShot(soundBullet);
    }
    void Update()
    {
        
    }
}
