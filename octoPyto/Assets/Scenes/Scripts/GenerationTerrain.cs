using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationTerrain : MonoBehaviour
{

    [SerializeField] private int width = 20, height = 20;
    [SerializeField] private GameObject rock, deepRock,baseRock;
    [SerializeField] private bool left;
    private GameObject playerObj;
    [SerializeField] private float lastRow = 0;
    private bool layerf = false;
    // Start is called before the first frame update
    void Start()
    {
        //width += (int)this.transform.position.x ;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        if(20>= (Mathf.Abs(lastRow) - Mathf.Abs((int)playerObj.transform.position.y )))
        {
            GenerateTerrain();
        }
    }

    void GenerateTerrain()
    {
        for (int i=0; i<height;i++) //i=y
        {
            int minWidth = width - 1;
            int maxWidth = width + 2;
            if (width <=7) width = width + 2;
            else if (width >= 30) width = width - 1;
            else width = Random.Range(minWidth, maxWidth);
            int minDeepRockWidth = width - 3;
            int maxDeepRockWidth = width - 4;
            int rockDis = Random.Range(minDeepRockWidth, maxDeepRockWidth);

            for (int j = 0; j < width; j++) //j=x
            {
                if (i!=0 || layerf)
                {
                    if (left)
                    {
                        if (j < rockDis)
                        {
                            SpawnerLeft(baseRock, j, i);
                        }
                        else
                        {
                            SpawnerLeft(deepRock, j, i);
                        }
                    }
                    else
                    {
                        if (j < rockDis)
                        {
                            SpawnerRight(baseRock, j, i);
                        }
                        else
                        {
                            SpawnerRight(deepRock, j, i);
                        }
                    } 
                }
                else
                {
                    layerf = true;
                    if (left) SpawnerLeft(rock, j, i);
                    else SpawnerRight(rock, j, i);
                }
                // Spawner(deepRock, j, i);
                //Instantiate(deepRock, new Vector2(j, i),Quaternion.identity);
            }

            if(left)SpawnerLeft(rock, width, i);
            else SpawnerRight(rock, width, i);

            if (i >= height-1) lastRow = lastRow + height + (int)this.transform.position.y;
            //Instantiate(rock, new Vector2(height, i), Quaternion.identity);
        }
    }

    void SpawnerLeft(GameObject obj, int _width, int _height)
    {
        obj = Instantiate(obj, new Vector2((int)this.transform.position.x+_width,  -_height+ (int)this.transform.position.y - (int)lastRow), Quaternion.identity);
        obj.transform.parent = this.transform;
    }


    void SpawnerRight(GameObject obj, int _width, int _height)
    {
        obj = Instantiate(obj, new Vector2(-_width+ (int)this.transform.position.x  , -_height + (int)this.transform.position.y - (int)lastRow), Quaternion.identity);
        obj.transform.parent = this.transform;
    }

}
