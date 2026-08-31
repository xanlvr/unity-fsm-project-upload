using UnityEngine;

public class TeamB_Destroyer_Attack : Unit_Abstract<TeamB_Unit_DestroyerManager>
{
    private float attackTimer = 0f;

    public override void EnterState(TeamB_Unit_DestroyerManager manager)
    {
        attackTimer = 0f;
    }

    public override void UpdateState(TeamB_Unit_DestroyerManager manager)
    {
        if (manager == null || manager.gameObject == null) return;

        if (manager.currentTarget == null || manager.enemyUnit == null || !manager.enemyUnit.activeInHierarchy)
        {
            manager.SwitchState(manager.SearchState);
            return;
        }

        float distance = Vector3.Distance(manager.transform.position, manager.currentTarget.position);
        if (distance > Team_Base.destroyerAttackRange)
        {
            manager.SwitchState(manager.MoveState);
            return;
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= Team_Base.destroyerAttackInterval)
        {
            attackTimer = 0f;

            TeamA_Health teamAHealth = manager.enemyUnit.GetComponent<TeamA_Health>();
            if (teamAHealth == null) teamAHealth = manager.enemyUnit.GetComponentInParent<TeamA_Health>();
            if (teamAHealth == null) teamAHealth = manager.enemyUnit.GetComponentInChildren<TeamA_Health>();

            if (teamAHealth != null)
            {
                teamAHealth.TakeDamage(Team_Base.destroyerAttackDamage);
            }
            else
            {
                Unit_Health targetHealth = manager.enemyUnit.GetComponent<Unit_Health>();
                if (targetHealth == null) targetHealth = manager.enemyUnit.GetComponentInParent<Unit_Health>();
                if (targetHealth == null) targetHealth = manager.enemyUnit.GetComponentInChildren<Unit_Health>();

                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(Team_Base.destroyerAttackDamage);
                }
            }
        }
    }

    public override void ExitState(TeamB_Unit_DestroyerManager manager)
    {
    }
}
