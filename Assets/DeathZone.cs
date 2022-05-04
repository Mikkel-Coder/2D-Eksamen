using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public float TimeUntilRestart;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            source.Play();
            StartCoroutine(WaitdAndRestart());





        }
    }
    IEnumerator WaitdAndRestart()
    {
        yield return new WaitForSeconds(TimeUntilRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
