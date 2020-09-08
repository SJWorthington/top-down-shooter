using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour {

    [SerializeField] Transform playerTransform;
    [SerializeField] Transform homeBaseTransform;

    [SerializeField] GameObject crawlerEnemyPrefab;
    [SerializeField] GameObject chargerEnemyPrefab;
    [SerializeField] GameObject spawnPointPrefab;
    [SerializeField] float basicEnemyChance = 0.8f;
    //This way of determining enemy is janky

    enum gridSpace { empty, floor, wall };
    gridSpace[,] grid;
    int roomHeight, roomWidth;
    Vector2 roomSizeWorldUnits;
    float worldUnitsInOneGridCell = 1f;
    struct Walker {
        public Vector2 dir;
        public Vector2 pos;
    }
    List<Walker> walkers;

    //TODO - Should just use a vector2 - though mapping a grid Vector2 to world Vector2 is confusing
    struct GridCoordinates {
        public int x;
        public int y;
    }

    [SerializeField] float worldHeight = 30, worldWidth = 30;
    [SerializeField] float chanceWalkerChangeDir = 0.5f, chanceWalkerSpawn = 0.05f, chanceWalkerDestroy = 0.05f;
    [SerializeField] int maxWalkers = 10;
    [SerializeField] float areaFloorRatio = 0.3f;
    [SerializeField] GameObject wallObject, floorObject;
    [SerializeField] float chanceOfEnemySpawn = 0.03f;

    //TODO - too hard codey, need to do this better
    private GridCoordinates topRightPoint; 
    private GridCoordinates bottomLeftPoint;
    private GridCoordinates topLeftPoint;
    private GridCoordinates bottomRightPoint;

    // Start is called before the first frame update
    void Start() {
        roomSizeWorldUnits = new Vector2(worldWidth, worldHeight);
        //TODO - This is bad
        topRightPoint.x = (int)roomSizeWorldUnits.x / 2;
        topRightPoint.y = (int)roomSizeWorldUnits.y / 2;
        bottomLeftPoint.x = (int)roomSizeWorldUnits.x / 2;
        bottomLeftPoint.y = (int)roomSizeWorldUnits.y / 2;
        topLeftPoint.x = (int)roomSizeWorldUnits.x / 2;
        topLeftPoint.y = (int)roomSizeWorldUnits.y / 2;
        bottomRightPoint.x = (int)roomSizeWorldUnits.x / 2;
        bottomRightPoint.y = (int)roomSizeWorldUnits.y / 2;

        Setup();
        CreateFloors();
        CreateEnemySpawnPoints();
        CreateWalls();
        SpawnLevel();
        AstarPath.active.Scan();
    }

    // Update is called once per frame
    void Update() {

    }

    private void Setup() {
        roomHeight = Mathf.RoundToInt(roomSizeWorldUnits.x / worldUnitsInOneGridCell);
        roomWidth = Mathf.RoundToInt(roomSizeWorldUnits.y / worldUnitsInOneGridCell);

        grid = new gridSpace[roomWidth, roomHeight];

        for (int x = 0; x < roomWidth - 2; x++) {
            for (int y = 0; y < roomHeight - 2; y++) {
                grid[x, y] = gridSpace.empty;
            }
        }

        var halfWidth = roomWidth / 2;
        var halfHeight = roomHeight / 2;
        grid[halfWidth, halfHeight] = gridSpace.floor;

        for (int x = halfWidth - 2; x <= halfWidth + 2; x++) {
            for (int y = halfHeight - 2; y <= halfHeight + 2; y++) {
                grid[x, y] = gridSpace.floor;
            }
        }

        //TODO - this needs to be made nicer
        var midPoint = convertGridPositionToWorld(halfWidth, halfHeight);
        homeBaseTransform.position = midPoint;
        playerTransform.position = midPoint;

        walkers = new List<Walker>();

        Walker startingWalker = new Walker();
        Vector2 spawnPos = new Vector2(Mathf.RoundToInt(roomWidth / 2), Mathf.RoundToInt(roomHeight/2));
        startingWalker.dir = RandomDirection();
        startingWalker.pos = spawnPos;
        walkers.Add(startingWalker);
    }

    private void CreateFloors() {
        int iterations = 0;
        do {
            foreach (Walker walker in walkers) {
                grid[(int)walker.pos.x, (int)walker.pos.y] = gridSpace.floor;
                grid[(int)walker.pos.x + 1, (int)walker.pos.y] = gridSpace.floor;
                grid[(int)walker.pos.x, (int)walker.pos.y + 1] = gridSpace.floor;
                grid[(int)walker.pos.x + 1, (int)walker.pos.y + 1] = gridSpace.floor;
            }

            //Randomly remove walkers
            int numWalkers = walkers.Count;
            for (int i = 0; i < numWalkers; i++) {
                if (walkers.Count > 1 && Random.value < chanceWalkerDestroy) {
                    walkers.RemoveAt(i);
                    break;
                }
            }

            //Randomly change walker dir
            for (int i = 0; i < walkers.Count; i++) {
                if (Random.value < chanceWalkerChangeDir) {
                    Walker thisWalker = walkers[i];
                    thisWalker.dir = RandomDirection();
                    walkers[i] = thisWalker;
                }
            }

            //Randomly generate new walkers
            numWalkers = walkers.Count;
            for (int i = 0; i < numWalkers; i++) {
                if (walkers.Count < maxWalkers && Random.value < chanceWalkerSpawn) {
                    Walker newWalker = new Walker();
                    newWalker.dir = RandomDirection();
                    newWalker.pos = walkers[i].pos;
                    walkers.Add(newWalker);
                }
            }

            //Move walkers in their new directions
            for (int i = 0; i < walkers.Count; i++) {
                Walker thisWalker = walkers[i];
                var newPos = thisWalker.pos + thisWalker.dir;

                if (newPos.x > 2 && newPos.x < roomWidth - 3 && newPos.y > 2 && newPos.y < roomHeight - 3) {
                    thisWalker.pos = newPos;
                    walkers[i] = thisWalker;

                    var newPosSum = newPos.x + newPos.y;

                    //Check if walker is at new furthest point to corners
                    if (newPosSum > topRightPoint.x + topRightPoint.y) {
                        topRightPoint.x = (int)newPos.x;
                        topRightPoint.y = (int)newPos.y;
                    } else if (newPosSum < bottomLeftPoint.x + bottomLeftPoint.y) {
                        bottomLeftPoint.x = (int)newPos.x;
                        bottomLeftPoint.y = (int)newPos.y;
                    } else if (newPos.x < topLeftPoint.x || newPos.y > topLeftPoint.y) { // top left

                        //Can do this better with Vector2.distance
                        var newDistanceToTopLeft = worldHeight - newPos.y + newPos.x;
                        var previousDistanceToTopLeft = worldHeight - topLeftPoint.y + topLeftPoint.x;

                        if (newDistanceToTopLeft < previousDistanceToTopLeft) {
                            topLeftPoint.x = (int)newPos.x;
                            topLeftPoint.y = (int)newPos.y;
                        }
                    } else if (newPos.x > bottomRightPoint.x || newPos.y < bottomRightPoint.y) { // bottom right

                        var newDistanceToBottomRight = worldWidth - newPos.x + newPos.y;
                        var previousDistanceToBottomRight = worldWidth - bottomRightPoint.x + bottomRightPoint.y;

                        if (newDistanceToBottomRight < previousDistanceToBottomRight) {
                            bottomRightPoint.x = (int)newPos.x;
                            bottomRightPoint.y = (int)newPos.y;
                        }
                    }
                } 
            }

            if ((float)NumberOfFloors() / (float)grid.Length > areaFloorRatio) {
                break;
            }

            iterations++;
        } while (iterations < 10000);
    }

    //TODO - this isn't at all flexible, what if I want spawn points at another location? Needs heavy refactoring
    private void CreateEnemySpawnPoints() {
        //TODO - all of this is quite gross, let's get it working though, then refactor heavily
        //List of spawn points will be much cleaner for the 4 loops I have below

        Vector2 offset = roomSizeWorldUnits / 2f;
        Vector2 topRightSpawnPos = new Vector2(topRightPoint.x, topRightPoint.y) * worldUnitsInOneGridCell - offset;
        Vector2 bottomLeftSpawnPos = new Vector2(bottomLeftPoint.x, bottomLeftPoint.y) * worldUnitsInOneGridCell - offset;
        Vector2 bottomRightSpawnPos = new Vector2(bottomRightPoint.x, bottomRightPoint.y) * worldUnitsInOneGridCell - offset;
        Vector2 topLeftSpawnPos = new Vector2(topLeftPoint.x, topLeftPoint.y) * worldUnitsInOneGridCell - offset;

        Instantiate(spawnPointPrefab, topLeftSpawnPos, Quaternion.identity);
        Instantiate(spawnPointPrefab, topRightSpawnPos, Quaternion.identity);
        Instantiate(spawnPointPrefab, bottomLeftSpawnPos, Quaternion.identity);
        Instantiate(spawnPointPrefab, bottomRightSpawnPos, Quaternion.identity);

        for (int x = (int)topRightPoint.x - 1; x <= (int)topRightPoint.x + 1; x++) {
            for (int y = (int)topRightPoint.y - 1; y <= (int)topRightPoint.y + 1; y++) {
                grid[x, y] = gridSpace.floor;
            }
        }

        for (int x = (int)bottomLeftPoint.x - 1; x <= (int)bottomLeftPoint.x + 1; x++) {
            for (int y = (int)bottomLeftPoint.y - 1; y <= (int)bottomLeftPoint.y + 1; y++) {
                grid[x, y] = gridSpace.floor;
            }
        }

        for (int x = (int)topLeftPoint.x - 1; x <= (int)topLeftPoint.x + 1; x++) {
            for (int y = (int)topLeftPoint.y - 1; y <= (int)topLeftPoint.y + 1; y++) {
                grid[x, y] = gridSpace.floor;
            }
        }

        for (int x = (int)bottomRightPoint.x - 1; x <= (int)bottomRightPoint.x + 1; x++) {
            for (int y = (int)bottomRightPoint.y - 1; y <= (int)bottomRightPoint.y + 1; y++) {
                grid[x, y] = gridSpace.floor;
            }
        }
    }

    //TODO - this isn't being used, either use or delete when this class is refactored
    private void CreateEnemySpawnPoint(float x, float y) {
        Vector2 offset = roomSizeWorldUnits / 2f;
        Vector2 spawnPos = new Vector2(x, y) * worldUnitsInOneGridCell - offset;
        var instantiatedObject = Instantiate(spawnPointPrefab, spawnPos, Quaternion.identity);
    }

    //TODO - There are probably more efficient ways of doing this
    private void CreateWalls() {
        for (int x = 1; x < roomWidth - 1; x++) {
            for (int y = 1; y < roomHeight - 1; y++) {
                if (grid[x, y] == gridSpace.floor) {
                    if (grid[x, y + 1] == gridSpace.empty) {
                        grid[x, y + 1] = gridSpace.wall;
                    }
                    if (grid[x, y - 1] == gridSpace.empty) {
                        grid[x, y - 1] = gridSpace.wall;
                    }
                    if (grid[x + 1, y] == gridSpace.empty) {
                        grid[x + 1, y] = gridSpace.wall;
                    }
                    if (grid[x - 1, y] == gridSpace.empty) {
                        grid[x - 1, y] = gridSpace.wall;
                    }
                }
            }
        }
    }

    private void SpawnLevel() {
        for (int x = 0; x < roomWidth; x++) {
            for (int y = 0; y < roomHeight; y++) {
                switch (grid[x, y]) {
                    case gridSpace.empty:
                        break;
                    case gridSpace.floor:
                        SpawnSceneryObjectAtPos(x, y, floorObject);
                        break;
                    case gridSpace.wall:
                        SpawnSceneryObjectAtPos(x, y, wallObject);
                        break;
                }
            }
        }
    }

    private int NumberOfFloors() {
        int floorCount = 0;
        foreach (gridSpace space in grid) {
            if (space == gridSpace.floor) {
                floorCount++;
            }
        }
        return floorCount;
    }

    private Vector2 RandomDirection() {
        var dir = Random.Range(0, 4);
        switch (dir) {
            case 0:
                return Vector2.up;
            case 1:
                return Vector2.right;
            case 2:
                return Vector2.down;
            default:
                return Vector2.left;
        }
    }

    private void SpawnSceneryObjectAtPos(int x, int y, GameObject toSpawn) {
        Vector2 offset = roomSizeWorldUnits / 2f;
        Vector2 spawnPos = convertGridPositionToWorld(x, y);
        var instantiatedObject = Instantiate(toSpawn, spawnPos, Quaternion.identity);
        instantiatedObject.transform.parent = this.transform;
    }

    private Vector2 convertGridPositionToWorld(int x, int y) {
        Vector2 offset = roomSizeWorldUnits / 2f;
        Vector2 worldPosition = new Vector2(x, y) * worldUnitsInOneGridCell - offset;
        return worldPosition;
    }
}
