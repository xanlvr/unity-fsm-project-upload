using UnityEngine;

public class TeamB_Fighter_Attack : Unit_Abstract<TeamB_Unit_FighterManager>
{
    private float attackTimer = 0f;

    public override void EnterState(TeamB_Unit_FighterManager manager)
    {
        attackTimer = 0f;
    }

    public override void UpdateState(TeamB_Unit_FighterManager manager)
    {
        if (manager == null || manager.gameObject == null) return;

        if (manager.enemyUnit == null || manager.currentTarget == null || !manager.enemyUnit.activeInHierarchy)
        {
            manager.SwitchState(manager.SearchState);
            return;
        }

        float distance = Vector3.Distance(manager.transform.position, manager.currentTarget.position);
        if (distance > Team_Base.fighterAttackRange)
        {
            manager.SwitchState(manager.MoveState);
            return;
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= Team_Base.fighterAttackInterval)
        {
            attackTimer = 0f;

            Unit_Health targetHealth = manager.enemyUnit.GetComponent<Unit_Health>();
            if (targetHealth == null)
            {
                targetHealth = manager.enemyUnit.GetComponentInParent<Unit_Health>();
            }
            if (targetHealth == null)
            {
                targetHealth = manager.enemyUnit.GetComponentInChildren<Unit_Health>();
            }

            if (targetHealth != null)
            {
                targetHealth.TakeDamage(Team_Base.fighterAttackDamage);
            }
            else
            {
                TeamA_Health teamAHealth = manager.enemyUnit.GetComponent<TeamA_Health>();
                if (teamAHealth == null) teamAHealth = manager.enemyUnit.GetComponentInParent<TeamA_Health>();
                if (teamAHealth == null) teamAHealth = manager.enemyUnit.GetComponentInChildren<TeamA_Health>();

                if (teamAHealth != null)
                {
                    teamAHealth.TakeDamage(Team_Base.fighterAttackDamage);
                }
            }
        }
    }

    public override void ExitState(TeamB_Unit_FighterManager manager)
    {
    }
}
