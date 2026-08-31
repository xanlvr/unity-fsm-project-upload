using UnityEngine;

public class TeamB_Destroyer_Death : Unit_Abstract<TeamB_Unit_DestroyerManager>
{
    public override void EnterState(TeamB_Unit_DestroyerManager manager)
    {
        if (manager != null && manager.gameObject != null)
        {
            Object.Destroy(manager.gameObject);
        }
    }

    public override void UpdateState(TeamB_Unit_DestroyerManager manager)
    {
    }

    public override void ExitState(TeamB_Unit_DestroyerManager manager)
    {
    }
}
