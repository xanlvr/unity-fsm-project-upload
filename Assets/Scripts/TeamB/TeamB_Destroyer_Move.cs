using UnityEngine;

public class TeamB_Destroyer_Move : Unit_Abstract<TeamB_Unit_DestroyerManager>
{
    public override void EnterState(TeamB_Unit_DestroyerManager manager)
    {
        if (manager == null || manager.currentTarget == null || manager.enemyUnit == null || !manager.enemyUnit.activeInHierarchy)
        {
            if (manager != null)
            {
                manager.SwitchState(manager.SearchState);
            }
        }
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
        if (distance <= Team_Base.destroyerAttackRange)
        {
            manager.SwitchState(manager.AttackState);
            return;
        }

        manager.transform.position = Vector3.MoveTowards(
            manager.transform.position,
            manager.currentTarget.position,
            Team_Base.destroyerMoveSpeed
        );

        Vector3 direction = (manager.currentTarget.position - manager.transform.position).normalized;
        if (direction != Vector3.zero)
        {
            manager.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public override void ExitState(TeamB_Unit_DestroyerManager manager)
    {
    }
}
