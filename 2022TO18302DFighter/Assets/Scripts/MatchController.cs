using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public Transform p1Spawn, p2Spawn;
    public CameraManager cManager;
    GameObject player1;
    GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameManager.Instance.player1;
        player2 = GameManager.Instance.player2;
        CreatePlayers();
    }

    public void CreatePlayers(){
        player1 = Instantiate(player1, p1Spawn.position,Quaternion.identity);
        player2 = Instantiate(player2, p2Spawn.position,Quaternion.identity);
        
        player1.GetComponent<Movement>().enemy = player2.transform;
        player2.GetComponent<Movement>().enemy = player1.transform;
        cManager.SetCamera(player1, player2);
    }
}
