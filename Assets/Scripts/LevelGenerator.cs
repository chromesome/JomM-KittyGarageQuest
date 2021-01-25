using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL = 50f;

    [SerializeField] List<Transform> levelPartList;
    [SerializeField] CatController catPlayer;


    bool levelStarted = false;
    Transform lastLevelPartTransform;

    private void Awake()
    {
    }

    public void StartLevel()
    {
        lastLevelPartTransform = SpawnLevelPart(transform.position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        levelStarted = true;
    }

    private void Update()
    {
        if(levelStarted)
        {
            Vector3 lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;

            if (Vector3.Distance(catPlayer.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL)
            {
                SpawnLevelPart();
            }
        }
    }

    void SpawnLevelPart()
    {
        Vector3 lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform levelPartTransform = Instantiate(chosenLevelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

}
