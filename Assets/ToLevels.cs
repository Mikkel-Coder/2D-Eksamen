using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevels : MonoBehaviour
{
    
    public float TimeUntil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeUntil > 0)
        {
            TimeUntil -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    IEnumerator WaitdAndChangel()
    {
        yield return new WaitForSeconds(TimeUntil);
        
    }

}
