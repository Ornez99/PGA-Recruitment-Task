using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float secondsToDestroy;

    public void SpawnObjectForSeconds(Vector3 position)
    {
        GameObject ins = Instantiate(objectToSpawn, position, Quaternion.Euler(0, 0, 0));
        Destroy(ins, secondsToDestroy);
    }
}
