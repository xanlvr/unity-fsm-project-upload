using UnityEngine;

public class TeamB_Unit_FighterManager : MonoBehaviour
{

    public TeamB_Manager teamManager;
    public Unit_Health health;
    public GameObject particle;


    public TeamB_Unit_FighterFSM_Search SearchState = new TeamB_Unit_FighterFSM_Search();
    public TeamB_Unit_FighterFSM_Move MoveState = new TeamB_Unit_FighterFSM_Move();
    public TeamB_Unit_FighterFSM_Attack AttackState = new TeamB_Unit_FighterFSM_Attack();
    public TeamB_Unit_FighterFSM_Death DeathState = new TeamB_Unit_FighterFSM_Death();

    public LayerMask targetLayer;
    public Transform enemyTower;
    public GameObject enemyUnit;



    Unit_Abstract<TeamB_Unit_FighterManager> currentState;

    void Start()
    {
        gameObject.SetActive(true);

        health.Init(Team_Base.fighterMaxHealth, OnDeath);

        currentState = SearchState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(Unit_Abstract<TeamB_Unit_FighterManager> newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void OnDeath()
    {
        Instantiate(particle, transform.position, transform.rotation);
        SwitchState(DeathState);
    }

    //Criei um método OnDeath. Este método será passado como parâmetro para a classe de health.
    //Quando a vida acabar, dentro do script do health, ele irá invocar o OnDeath() do manager.
    //Desta forma conseguimos mudar o estado concreto a partir do Manager da unidade através do health.
    //Assim, conseguimos ter um script genérico de gerenciamento de vida para todos os tipos de unidades, ao invés de criar um para cada.

    //=====Metodo Antigo ficava no Manager. Agora virou o OnDeath, que é chamado pelo Unit_Health dentro do gameobject quando ele tiver < 0 de health.
    //public void UnitTakeDamage(int damageAmount)
    //{
    //    currentHealth -= damageAmount;
    //    if (currentHealth <= 0)
    //    {
    //        SwitchState(DeathState);
    //    }
    //}

}
