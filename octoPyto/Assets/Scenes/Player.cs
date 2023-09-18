using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    [SerializeField] private float vel = 1;
    [SerializeField] private float acc = 0.001f;
    private Vector2 input;
    private Rigidbody2D playerRB;
    public Vector2 startPos;
    public int points = 0;
    
    ShowScore scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        startPos = transform.position;
        scoreboard=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShowScore>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
       // input.y = Input.GetAxis("Vertical");

        
    }
    private void FixedUpdate()
    {
       // playerRB.gravityScale = playerRB.gravityScale + 0.01;
        playerRB.velocity = new Vector2(input.x * vel, (float)(playerRB.velocity.y+acc));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Rock"))
        {
            if(scoreboard.scorePt> Score.highScore) Score.highScore = (int)scoreboard.scorePt;
            Restart();
        }
    }

    void Restart()
    {
        transform.position = startPos;
        SceneManager.LoadScene("SampleScene");
    }
}
