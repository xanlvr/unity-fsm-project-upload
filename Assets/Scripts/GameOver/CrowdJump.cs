using UnityEngine;

public class CrowdJump : MonoBehaviour
{
    public float amplitude = 0.5f;   // Altura do pulo
    public float frequency = 2f;     // Velocidade do pulo
    public float randomOffset = 0f;  // Offset para não pularem iguais

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        // Pequena variação para cada objeto pular em tempos diferentes
        randomOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Abs(Mathf.Sin(Time.time * frequency + randomOffset)) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
