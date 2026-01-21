using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Material myMaterial;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newOffset = myMaterial.mainTextureOffset;
        newOffset.Set(0, newOffset.y + (moveSpeed * Time.deltaTime));
        myMaterial.mainTextureOffset = newOffset;
    }
}
