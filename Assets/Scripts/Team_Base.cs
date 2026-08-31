using UnityEngine;

public class Team_Base : MonoBehaviour
{
    //Propriedades da Base Principal
    public const float unitSpawnTimer = 5f;
    public const int baseHitPoints = 500; 
    
    
    //Propriedades para o Destroyer
    public const float destroyerMoveSpeed =0.005f;
    public const float destroyerAttackRange = 1.25f;
    public const float destroyerAttackInterval = 3f;
    public const float destroyerSearchRay = 30f;
    public const int destroyerAttackDamage = 15;
    public const int destroyerMaxHealth = 125;
    

    //Propriedades para o Fighter
    public const float fighterMoveSpeed = 0.01f;
    public const float fighterAttackRange = 1.25f;
    public const float fighterAttackInterval = 1f;
    public const float fighterSearchRay = 1f;
    public const int fighterAttackDamage = 20;
    public const int fighterMaxHealth = 45;
    

}
