using UnityEngine;

public class TeamB_Destroyer_Attack : Unit_Abstract<TeamB_Destroyer_Manager>
{
    [SerializeField] private float attackDamage = 30f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 2.5f;
    private float lastAttackTime = 0f;
    private GameObject targetTower;

    public override void EnterState(TeamB_Destroyer_Manager manager)
    {
        // Inicia estado de ataque contra a torre
        targetTower = FindTargetTower();
    }

    public override void UpdateState(TeamB_Destroyer_Manager manager)
    {
        if (targetTower == null)
        {
            // Torre foi destruída, volta para Search
            manager.SetState(manager.searchState);
            return;
        }

        float distanceToTower = Vector3.Distance(transform.position, targetTower.transform.position);

        if (distanceToTower > attackRange)
        {
            // Torre se afastou, volta para Move
            manager.SetState(manager.moveState);
            return;
        }

        // Ataca a torre se cooldown passou
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            AttackTower();
            lastAttackTime = Time.time;
        }
    }

    public override void ExitState(TeamB_Destroyer_Manager manager)
    {
        // Para o ataque
    }

    private void AttackTower()
    {
        if (targetTower != null)
        {
            // Tenta obter o Health da torre
            TowerBLife towerHealth = targetTower.GetComponent<TowerBLife>();

            if (towerHealth != null)
            {
                towerHealth.TakeDamage(attackDamage);
            }
        }
    }

    private GameObject FindTargetTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        GameObject closest = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject tower in towers)
        {
            if (tower != null)
            {
                float distance = Vector3.Distance(transform.position, tower.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = tower;
                }
            }
        }

        return closest;
    }
}
