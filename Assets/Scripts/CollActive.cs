using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollActive : MonoBehaviour {

    public Siguejugador follow;

    public GameObject Wall;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            follow.minCamPos = new Vector3(111.6f, 1.17f, -10f);
            follow.maxCamPos = new Vector3(111.6f, 1.17f, -10f);

            Wall.SetActive(true);
        }
    }

}
