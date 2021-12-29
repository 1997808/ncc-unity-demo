using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCount : MonoBehaviour
{
    public int livesRemaining;
    // Start is called before the first frame update

    public void LoseLife()
    {
        livesRemaining--;
        if (livesRemaining <= 0)
        {
            Debug.Log("Dead");
            FindObjectOfType<PlayerMovement>().Die();
            StartCoroutine(ResetLevel());
        }
    }

    private IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(5);
        FindObjectOfType<LevelManager>().Restart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
