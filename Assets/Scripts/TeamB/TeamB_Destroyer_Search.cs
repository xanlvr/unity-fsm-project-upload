using UnityEngine;

public class TeamB_Destroyer_Search : Unit_Abstract<TeamB_Unit_DestroyerManager>
{
    public override void EnterState(TeamB_Unit_DestroyerManager manager)
    {
        if (manager == null) return;
        manager.currentTarget = null;
        manager.enemyUnit = null;
    }

    public override void UpdateState(TeamB_Unit_DestroyerManager manager)
    {
        if (manager == null || manager.gameObject == null) return;

        GameObject closestTower = null;
        float minDistance = float.MaxValue;

        void CheckTowers(string tagName)
        {
            try
            {
                GameObject[] towers = GameObject.FindGameObjectsWithTag(tagName);
                if (towers == null) return;

                foreach (GameObject tower in towers)
                {
                    if (tower == null || !tower.activeInHierarchy || tower == manager.gameObject) continue;

                    // Exclude friendly TeamB towers
                    if (tower.CompareTag("TowerB") || tower.name.Contains("TeamB")) continue;

                    float distance = Vector3.Distance(manager.transform.position, tower.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestTower = tower;
                    }
                }
            }
            catch (UnityException)
            {
                // Tag may not exist in TagManager
            }
        }

        CheckTowers("Tower");
        CheckTowers("TowerA");

        if (closestTower != null)
        {
            manager.enemyUnit = closestTower;
            manager.currentTarget = closestTower.transform;
            manager.SwitchState(manager.MoveState);
        }
    }

    public override void ExitState(TeamB_Unit_DestroyerManager manager)
    {
    }
}
