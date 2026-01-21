using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public static GameManager instance;
    public Text scoreText;

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
        scoreText.text = "Score: " + score;

        //if (score > 1000)
        //{
        //    SceneManager.LoadScene(1); //두번째 씬전환 index 1
        //}

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
