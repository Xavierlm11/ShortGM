using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{

    private GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerObj.transform.position,gameObject.transform.position)>150)
        {
            Destroy(gameObject);
        }
    }
}
