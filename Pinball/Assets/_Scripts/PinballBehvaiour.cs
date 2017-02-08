using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinballBehvaiour : MonoBehaviour
{
    public GameManagerBehaviour manager;
    public void SetManager(GameObject mngr)
    {
        manager = mngr.GetComponent<GameManagerBehaviour>();
    }

    public void IncScore(int amt)
    {
        manager.IncScore(amt);
    }

    public void Lost()
    {
        manager.LostBall();
    }
}
