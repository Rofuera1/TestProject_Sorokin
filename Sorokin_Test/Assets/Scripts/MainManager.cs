using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public GameObject CubePrefab;
    public Transform CubeInstantiateOriginTR;

    private float spawnTimeDelay;
    public float SpawnTimeDelay { get { return spawnTimeDelay; } set { spawnTimeDelay = value; ChangeValuesForAllCubes(); } }
    private float cubeSpeed;
    public float CubeSpeed { get { return cubeSpeed; } set { cubeSpeed = value; ChangeValuesForAllCubes(); } }
    private float cubeDistance;
    public float CubeDistance { get { return cubeDistance; } set { cubeDistance = value; ChangeValuesForAllCubes(); } }

    private List<CubeScript> InGameCubes;
    float time = 0f;


    private void Awake()
    {
        if (Instance)
            Destroy(Instance);
        if (!Instance)
            Instance = this;
    }

    private void Start()
    {
        spawnTimeDelay = 1;
        cubeSpeed = 1;
        cubeDistance = 5;

        InGameCubes = new List<CubeScript>();
    }

    // Could've used Coroutine and yield return WaitForSeconds, but it wouldn't be dynamic
    // Could've also used Coroutne, other bool & onChange() calculate time, but this way it's easier
    private void Update()
    {
        if (time < SpawnTimeDelay)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;

            spawnCube();
        }
    }

    public void ChangeValuesForAllCubes()
    {
        for (int i = 0; i < InGameCubes.Count; i++)
            InGameCubes[i].SetSpeedDistanceValues(cubeSpeed, cubeDistance);
    }

    public void RemoveCubeFromScene(CubeScript cubeCS)
    {
        InGameCubes.Remove(cubeCS); 
        Destroy(cubeCS.gameObject);
    }

    private void spawnCube()
    {
        GameObject newCubeInstance = Instantiate(CubePrefab, CubeInstantiateOriginTR.position, CubeInstantiateOriginTR.rotation);
        InGameCubes.Add(newCubeInstance.GetComponent<CubeScript>());
        newCubeInstance.GetComponent<CubeScript>().SetSpeedDistanceValues(cubeSpeed, cubeDistance);
    }
}
