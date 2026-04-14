using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    private int leftPaddleScore = 0;
    private int rightPaddleScore = 0;
    private string player;
    private List<PlayerParams> playerParams; 

    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public Text leftScore;
    public Text rightScore;

    public class PlayerParams
    {
        private string playerVert;
        private string playerHor;
        private float playerOrigin;
        private AudioSource sound;
    }

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        leftScore.text = leftPaddleScore.ToString();
        rightScore.text = rightPaddleScore.ToString();
 
        DontDestroyOnLoad(gameObject);
    }
    void InitPlayers()
    {

    }

    public void Score(int scorer)
    {
        if (scorer == 1)
            leftPaddleScore = ++leftPaddleScore;
        else
            rightPaddleScore = ++rightPaddleScore;
        leftScore.text = leftPaddleScore.ToString();
        rightScore.text = rightPaddleScore.ToString();

    }
    void Update()
    {
    }
}
