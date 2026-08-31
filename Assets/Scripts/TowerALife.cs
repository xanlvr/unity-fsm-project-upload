using TMPro;
using UnityEngine;

public class TowerALife : MonoBehaviour
{
    public TeamA_Health health;
    public TMP_Text text;
    void Start()
    {
        
    }

    void Update()
    {
        
        text.SetText(health.baseCurrentHitPoints.ToString()); 

    }
}
