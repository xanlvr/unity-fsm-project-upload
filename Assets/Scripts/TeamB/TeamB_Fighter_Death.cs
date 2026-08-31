using UnityEngine;

public class TeamB_Fighter_Death : Unit_Abstract<TeamB_Unit_FighterManager>
{
    public override void EnterState(TeamB_Unit_FighterManager manager)
    {
        if (manager != null && manager.gameObject != null)
        {
            Object.Destroy(manager.gameObject);
        }
    }

    public override void UpdateState(TeamB_Unit_FighterManager manager)
    {
    }

    public override void ExitState(TeamB_Unit_FighterManager manager)
    {
    }
}
