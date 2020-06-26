using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public BoxSpawner boxSpawenr;
    [HideInInspector]
    public BoxScript boxScript;
    public GameObject GameOverScreen;
    public CamerFollow camScript;
    private int moveCount;
    void Awake()
    {
        if(instance==null){
            instance = this;
        }
    }

    void Start()
    {
        boxSpawenr.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            boxScript.ReleaseBox();
        }
    }

    public void SpawnNextBox()
    {
        Invoke("NextBox",0f);
    }

    void NextBox()
    {
        boxSpawenr.SpawnBox();
    }
    public void moveCamera()
    {
        moveCount++;
        if(moveCount==3){
            moveCount = 0;
            camScript.targetPos.y += 3f;
        }


    }
    public void RestartGame()
    {
        GameOverScreen.SetActive(true);
    }


   



}
