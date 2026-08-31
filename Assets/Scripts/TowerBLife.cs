using TMPro;
using UnityEngine;

public class TowerBLife : MonoBehaviour
{
    public TeamB_Health health;
    public TMP_Text text;
    void Start()
    {
        
    }

    void Update()
    {
        
        text.SetText(health.baseCurrentHitPoints.ToString()); 

    }
}
