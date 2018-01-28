using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour {
    public GameObject Ganaste;
    public GameObject Player;
    private Vector3 posiPlayer;
    private Vector3 ganasteActive;
    public Animator cierre;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        posiPlayer = Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        ganasteActive = new Vector3(202.23f, -1.78f, 0f);
        if ((int) posiPlayer.x == (int)  ganasteActive.x)
        {


            SceneManager.LoadScene(1);

        }

    }
}
