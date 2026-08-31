using UnityEngine;

public class TeamB_Fighter_Search : Unit_Abstract<TeamB_Unit_FighterManager>
{
    public override void EnterState(TeamB_Unit_FighterManager manager)
    {
        if (manager == null) return;
        manager.enemyUnit = null;
        manager.currentTarget = null;
    }

    public override void UpdateState(TeamB_Unit_FighterManager manager)
    {
        if (manager == null || manager.gameObject == null) return;

        GameObject closestEnemy = null;
        float minDistance = float.MaxValue;

        void CheckTargets(string tagName)
        {
            try
            {
                GameObject[] targets = GameObject.FindGameObjectsWithTag(tagName);
                if (targets == null) return;

                foreach (GameObject target in targets)
                {
                    if (target == null || !target.activeInHierarchy || target == manager.gameObject) continue;

                    // Exclude friendly TeamB objects
                    if (target.CompareTag("UnitB") || target.name.Contains("TeamB")) continue;

                    float distance = Vector3.Distance(manager.transform.position, target.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestEnemy = target;
                    }
                }
            }
            catch (UnityException)
            {
                // Tag may not exist in TagManager
            }
        }

        CheckTargets("Destroyer");
        CheckTargets("Fighter");
        CheckTargets("UnitA");

        if (closestEnemy != null)
        {
            manager.enemyUnit = closestEnemy;
            manager.currentTarget = closestEnemy.transform;
            manager.SwitchState(manager.MoveState);
        }
    }

    public override void ExitState(TeamB_Unit_FighterManager manager)
    {
    }
}
