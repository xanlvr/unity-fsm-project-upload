using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    public CrowdJump[] crowdJump;

    public void Jump()
    {
        foreach (var item in crowdJump)
        {
            item.enabled = true;
            item.gameObject.isStatic = false;
        }
    }


}
