using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public GameObject railPrefab;
    public int offsetToCreateTiles = 5;

    public int distanceCreateStationFromPlayer = 8;
    public List<GameObject> stationsListPrefab = new List<GameObject>();
    public int goldSpawnPercent;
    GameObject tailHolder;
    const int columnAmount = 25;
    const int rowAmount = 4;

    public int minDistanceBetweenStations = 3;
    public int maxDistanceBetweenStations = 5;

    int spawnedNewRowsAmount = 0;
    int nearlyRowAmountToSpawnStation = 0;

    List<GameObject> tailsList = new List<GameObject>();
    List<int> stationsListIndex = new List<int>();
    List<int> rowListIndex = new List<int>();
    public GameObject player;
    public GameObject goldPrefab;

    public List<GameObject> terrainTiles = new List<GameObject>();
    public float TerrainDensity = 30.0f;

    private void Awake()
    {
        instance = this;
        tailHolder = new GameObject("SpawnHolder");
        FillListsIndex();
        SpawnStartRails();
    }

    void SpawnStartRails()
    {
        for (int y = 0; y < rowAmount * 2; y += 2)
            for (int x = 0; x < columnAmount; x++)
                CreateTail(x, y, railPrefab);
    }

    public void CreateTail(int xPos, int yPos, GameObject tileToSpawn)
    {
        Vector2 tilePosition = new Vector2(xPos, yPos);
        GameObject newTile = Instantiate(tileToSpawn, tilePosition, Quaternion.identity);
        tailsList.Add(newTile);
        newTile.transform.SetParent(tailHolder.transform);
    }

    public void SpawnNewRow(int playerPosition)
    {
        SpawnRails(playerPosition);

        int row;
        if (CheckIfTimeToSpawnStation())
        {
            GameObject station = RandomStation();
            row = RandomRow(true);
            CreateTail(playerPosition + distanceCreateStationFromPlayer, row, station);
            SetNewRowAmountToSpawnStation();
        }

        GoldSpawner(playerPosition);
        TerrainSpawner(playerPosition);
        spawnedNewRowsAmount++;
    }

    void SpawnRails(int playerPosition)
    {
        for (int y = 0; y < rowAmount * 2; y += 2)
            CreateTail(playerPosition + offsetToCreateTiles, y, railPrefab);
    }

    bool CheckIfTimeToSpawnStation()
    {
        return spawnedNewRowsAmount == nearlyRowAmountToSpawnStation;
    }

    void SetNewRowAmountToSpawnStation()
    {
        nearlyRowAmountToSpawnStation = spawnedNewRowsAmount + RandomDistanceBetweenStations();
    }

    GameObject RandomStation()
    {
        if (stationsListIndex.Count == 0) FillListsIndex();

        int index = Random.Range(0, stationsListIndex.Count);
        GameObject randomStation = stationsListPrefab[stationsListIndex[index]];
        stationsListIndex.RemoveAt(index);
        return randomStation;
    }

    int RandomRow(bool removeFromList)
    {
        if (rowListIndex.Count == 0) FillListsIndex();
        int indexRandom = Random.Range(0, rowListIndex.Count);
        int listIndex = rowListIndex[indexRandom];

        if (removeFromList)
            rowListIndex.RemoveAt(indexRandom);

        return listIndex * 2;
    }

    int RandomDistanceBetweenStations()
    {
        return Random.Range(minDistanceBetweenStations, maxDistanceBetweenStations);
    }

    void FillListsIndex()
    {
        for (int i = 0; i < rowAmount; i++)
        {
            rowListIndex.Add(i);
            stationsListIndex.Add(i);
        }
    }

    void GoldSpawner(int x)
    {
        float random = Random.Range(0, 100);
        int row = RandomRow(false);
        if (random > goldSpawnPercent) return;
        Instantiate(goldPrefab, new Vector2(x + distanceCreateStationFromPlayer, row), Quaternion.identity);
    }

    void TerrainSpawner(int x)
    {
        float chanceToSpawnTerrain = Random.Range(0, 100);

        if (chanceToSpawnTerrain < TerrainDensity)
        {
            GameObject elementToSpawn = terrainTiles[Random.Range(0, terrainTiles.Count)];
            float scale = Random.Range(0.1f, 0.25f);
            float rotate = Random.Range(-30f, 30f);

            
           GameObject spawned = Instantiate(elementToSpawn, new Vector2(x + distanceCreateStationFromPlayer + Random.Range(0, 5), RandomRow(false)+1), Quaternion.identity);

            spawned.transform.localScale = new Vector3(scale, scale, scale);
            spawned.transform.Rotate(rotate, 0.0f, 0.0f);
        }        
    }
}