using UnityEngine;

public class TeamA_Health : Team_Base
{
    //Variáveis relativas à Base
    public int baseCurrentHitPoints;

    public GameObject popup;
    public CrowdManager crowdManager;


    void Start()
    {
        baseCurrentHitPoints = baseHitPoints;
    }

    void Update()
    {
        if (baseCurrentHitPoints <= 0)
        {
            //Abaixo, tirei licenca poetica para resolver o endgame da forma mais direta possivel. (:

            popup.SetActive(true);
            crowdManager.Jump();
            GameOver();
        }
    }

    public void TakeDamage(int damageHit)
    {
        baseCurrentHitPoints -= damageHit;
    }

    public void GameOver()
    {
        Game_Manager.EndGame("TeamB");
        Destroy(gameObject);
    }
}
