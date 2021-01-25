using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerData
{
    public int solvesAmount;
    public string lastTime;
    public string bestTime;
    public string lastScramble;
    public int currentSpeed;

    public float zoom;
    public float x, y, z;


    public PlayerData(CubeManager cubeManager)
    {
        solvesAmount =cubeManager.solvesAmount;
        lastTime = cubeManager.LastTime.text;
        bestTime = cubeManager.BestTime.text;
        lastScramble = cubeManager.LastScramble.text;
        currentSpeed = cubeManager.current_speed;
    }

    

    public PlayerData(MoveCamera moveCamera)
    {
        zoom = moveCamera.zoom.value;
        x = moveCamera.transform.position.x;
        y = moveCamera.transform.position.y;
        z = moveCamera.transform.position.z;
    }
}
