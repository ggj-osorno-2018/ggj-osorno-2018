using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comienzo_Nivel1 : MonoBehaviour {
    public GameObject players;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnBecameInvisible()
    {
        
        players.transform.position = new Vector3(-110.38f, -0.83f, 0f);
    }
}
