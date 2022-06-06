using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{

    [SerializeField] GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(gameManager);


        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
