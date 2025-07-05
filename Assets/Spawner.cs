using UnityEngine;

public class FollowerSpawner : MonoBehaviour
{
    public GameObject followerPrefab;
    public Transform leader;
    public int followerCount = 10;

    void Start()
    {
        for (int i = 0; i < followerCount; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-2f, -1f));


            GameObject follower = Instantiate(followerPrefab, leader.position + spawnOffset, Quaternion.identity);
            var ai = follower.GetComponent<FollowerAI>();
            ai.leader = leader;
            ai.offset = spawnOffset;
        }
    }
}
