using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public int NextLevel;
    public float TimeUntilNextLevel;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            source.Play();
            StartCoroutine(WaitdAndChangeLevel());
        }
    }  
    IEnumerator WaitdAndChangeLevel()
    {
        yield return new WaitForSeconds(TimeUntilNextLevel);
        SceneManager.LoadScene(NextLevel);
    }
}
