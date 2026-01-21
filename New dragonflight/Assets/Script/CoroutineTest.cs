using System.Collections;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
//코루틴: 유니티에서 여러 프레임에 걸쳐 동작을 나눠 처리하는 방법.스레드가 아니라 메인 루프에서 시간 지연을 쉽게 구현.
//시작: StartCoroutine(코루틴메서드());
//멈춤: StopCoroutine(참조) 또는 StopAllCoroutines();
//자주 쓰는 yield: yield return null(다음 프레임까지 대기), yield return new WaitForSeconds(초),
//yield return new WaitUntil(()=>조건).


    void Start()
    {
        StartCoroutine(ChangeText());

    }

    //코루틴쓸때 이건 외워야함 
    //코루틴은 지연을 주면서 표시할게 있다면 유용할듯
    IEnumerator ChangeText()
    {
        Debug.Log("준비");

        yield return new WaitForSeconds(1f);

        Debug.Log("시작");

        yield return new WaitForSeconds(1f);

        Debug.Log("끝");
    }



    void Update()
    {
        
    }
}
