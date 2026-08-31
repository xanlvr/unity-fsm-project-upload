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
    public Transform currentTarget;


    Unit_Abstract<TeamB_Unit_FighterManager> currentState;

    void Start()
    {
        gameObject.SetActive(true);

        if (health != null)
        {
            health.Init(Team_Base.fighterMaxHealth, OnDeath);
        }

        currentState = SearchState;

        if (currentState != null)
        {
            currentState.EnterState(this);
        }
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void SwitchState(Unit_Abstract<TeamB_Unit_FighterManager> newState)
    {
        if (newState == null) return;
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = newState;
        currentState.EnterState(this);
    }

    public void OnDeath()
    {
        if (particle != null)
        {
            Instantiate(particle, transform.position, transform.rotation);
        }
        SwitchState(DeathState);
    }

    //Criei um m�todo OnDeath. Este m�todo ser� passado como par�metro para a classe de health.
    //Quando a vida acabar, dentro do script do health, ele ir� invocar o OnDeath() do manager.
    //Desta forma conseguimos mudar o estado concreto a partir do Manager da unidade atrav�s do health.
    //Assim, conseguimos ter um script gen�rico de gerenciamento de vida para todos os tipos de unidades, ao inv�s de criar um para cada.

    //=====Metodo Antigo ficava no Manager. Agora virou o OnDeath, que � chamado pelo Unit_Health dentro do gameobject quando ele tiver < 0 de health.
    //public void UnitTakeDamage(int damageAmount)
    //{
    //    currentHealth -= damageAmount;
    //    if (currentHealth <= 0)
    //    {
    //        SwitchState(DeathState);
    //    }
    //}

}
