using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Vector2 playerInitPosition;

    void Start()
    {
        playerInitPosition = FindObjectOfType<PlayerMovement>().transform.position;
    }

    public void Restart()
    {
        //restart scenes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //restart player position
        FindObjectOfType<PlayerMovement>().transform.position = playerInitPosition;
        //save player position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
