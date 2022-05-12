using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get;set;}
    public GameObject player1;
    public GameObject player2;

  
    void Awake()
    {
        if(Instance != null && Instance != this)
         {
             Destroy(this.gameObject);
         }
         else{
             Instance = this;
         }

         DontDestroyOnLoad(this.gameObject);
    }

    public void SetPlayer1(GameObject p){
        player1 = p;
    }
}
