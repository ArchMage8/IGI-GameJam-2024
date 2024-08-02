using UnityEngine;
using System.Collections;

public class DebrisGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    public float rotationSpeed = 30f;
    public float spawnDelay = 2f;
    public GameObject destination;
    public float moveSpeed = 5f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            GenerateObject();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void GenerateObject()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject obj = Instantiate(prefabs[randomIndex], transform.position, Quaternion.identity);
        obj.AddComponent<ObjectMover>().Initialize(destination.transform, moveSpeed, rotationSpeed);
    }
}

public class ObjectMover : MonoBehaviour
{
    private Transform destination;
    private float moveSpeed;
    private float rotationSpeed;

    public void Initialize(Transform destination, float moveSpeed, float rotationSpeed)
    {
        this.destination = destination;
        this.moveSpeed = moveSpeed;
        this.rotationSpeed = rotationSpeed;
    }

    private void Update()
    {
        MoveTowardsDestination();
        RotateObject();
    }

    private void MoveTowardsDestination()
    {
        if (destination != null)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

            if (Vector3.Distance(transform.position, destination.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void RotateObject()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
