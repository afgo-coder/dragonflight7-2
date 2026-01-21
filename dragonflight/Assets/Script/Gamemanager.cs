using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    //ΩÃ±€≈Ê
    public static Gamemanager instance;
    public Text scoreText;

    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score: "+score;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
