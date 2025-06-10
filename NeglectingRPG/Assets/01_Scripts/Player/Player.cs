using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_STATE
{
    IDLE,
    ATTACK,
    MOVE,
    DEATH,
}
public class Player : MonoBehaviour
{
    public PlayerStatHandler statHandler;
    public PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
