using System;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public static bool LetsPlay;

    

    void Start()
    {
        LetsPlay = true;
    }

    public static void EndGame(string winner)
    {
        LetsPlay = false;

            //Debug.Log("WORK IN PROGRESS -> AQUI EXISTIRÁ UMA INTERFACE DE VITÓRIA" + winner);
            DestroyUnits();
    }

    public static void DestroyUnits()
    {
        var UnitsTeamA = GameObject.FindGameObjectsWithTag("UnitA");
        var UnitsTeamB = GameObject.FindGameObjectsWithTag("UnitB");

        foreach (var unit in UnitsTeamA)
        {
            Destroy(unit);
        }

        foreach (var unit in UnitsTeamB)
        {
            Destroy(unit);
        }
    }
}
