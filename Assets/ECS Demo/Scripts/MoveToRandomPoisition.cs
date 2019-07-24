using UnityEngine;

public class MoveToRandomPoisition : MonoBehaviour
{
    public Vector3 origin = Vector3.zero;
    [SerializeField]
    private float radius = 5f;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float delayBetweenUpdates = 0.1f;

    private Vector3 movement;
    private float time = 0f;
    void GetRandomMotion()
    {
        movement = origin + Random.onUnitSphere * radius*2;
    }

    void Update()
    {
        if (time <= 0f)
        {
            GetRandomMotion();
            time = delayBetweenUpdates;
        }
        else
        {
            time -= Time.deltaTime;
        }
        transform.position = Vector3.MoveTowards(transform.position, movement, Time.deltaTime * speed);
    }
}