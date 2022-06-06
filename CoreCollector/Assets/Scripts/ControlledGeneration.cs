using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledGeneration : MonoBehaviour
{
    [SerializeField] List<CubeStats> _cubes = new List<CubeStats>();
    [SerializeField] Vector3 mineSize;
    [SerializeField] int minePos;
    public GameObject player;
    public GameObject playerSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {

        //Make sure to comment out one function call

        //3D generation
        //GenerateLevel(Mathf.RoundToInt(mineSize.x), Mathf.RoundToInt(mineSize.y), Mathf.RoundToInt(mineSize.z));
        //2D generation
        GenerateLevel(Mathf.RoundToInt(mineSize.x), Mathf.RoundToInt(mineSize.y));
    }

    // Update is called once per frame
    void Update()
    {

    }


    //2D overload function
    public void GenerateLevel(int xSize, int ySize)
    {
        

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                float cubeNumber = Random.Range(0, 120);

                foreach (CubeStats aCubeStat in _cubes)
                {
                    if (aCubeStat._spawnChance.x <= cubeNumber && aCubeStat._spawnChance.y >= cubeNumber)
                    {

                        GameObject.Instantiate(aCubeStat._aCube, new Vector3(i, j - minePos, 0), Quaternion.identity);
                    }
                }
            }
        }

    }

    //3D overload function


    [System.Serializable]
    public struct CubeStats
    {
        public GameObject _aCube;
        public Vector2 _spawnChance;

    }
}
