using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{

    public Text score;
    public Text highScore;
    public int scorePt;
    public float highScorePt;
    private Player playerObj;
    private GameObject player;
    [SerializeField] private float multPt=1.3f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerObj = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(playerObj.startPos.y player.transform.position.y)
        scorePt = (int)(Mathf.Abs((int)player.transform.position.y)*multPt - Mathf.Abs((int)playerObj.startPos.y));
        ShowTheScore();
            ShowHighScore();
    }

    public void ShowTheScore()
    {
        score.text = "Score:" + scorePt.ToString();
    }
     public void ShowHighScore()
    {
        highScore.text ="Highscore:"+ Score.highScore.ToString() ;
    }


}
