using UnityEngine;

public class TeamB_Fighter_Move : Unit_Abstract<TeamB_Unit_FighterManager>
{
    public override void EnterState(TeamB_Unit_FighterManager manager)
    {
        if (manager == null || manager.enemyUnit == null || manager.currentTarget == null || !manager.enemyUnit.activeInHierarchy)
        {
            if (manager != null)
            {
                manager.SwitchState(manager.SearchState);
            }
        }
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
        if (distance <= Team_Base.fighterAttackRange)
        {
            manager.SwitchState(manager.AttackState);
            return;
        }

        manager.transform.position = Vector3.MoveTowards(
            manager.transform.position,
            manager.currentTarget.position,
            Team_Base.fighterMoveSpeed
        );

        Vector3 direction = (manager.currentTarget.position - manager.transform.position).normalized;
        if (direction != Vector3.zero)
        {
            manager.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public override void ExitState(TeamB_Unit_FighterManager manager)
    {
    }
}
