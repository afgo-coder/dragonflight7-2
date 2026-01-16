using UnityEngine;

public class BackGround : MonoBehaviour
{

    //스크롤이 되는 백그라운드
    public float scrollSpeed = 1f;
    private Material myMaterial;


    void Start()
    {
        //머터리얼 가지고오기
        myMaterial = GetComponent<Renderer>().material;


    }

     
    void Update()
    {
        //오프셋 머터리얼에서 가져오기
        Vector2 newOffset = myMaterial.mainTextureOffset;
        //새롭게 offset 바꿔주기
        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));

        //머터리얼에 오프셋 값을 넣어준다
        myMaterial.mainTextureOffset = newOffset;
    }
}
