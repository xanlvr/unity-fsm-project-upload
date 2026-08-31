using System.Collections;
using UnityEngine;

public class ParticleSelfDestroy : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }


    void Update()
    {
        
    }
}
