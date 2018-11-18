using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPickupScript : MonoBehaviour
{
    private int sceneIndex;
    private int count;
    private int mod;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        mod = 1;
        count = 45;
    }
    // Update is called once per frame
    void Update()
    {
        if (count > 0)
        {
            --count;
            transform.Rotate(new Vector3(0, 0, 45 * mod) * Time.deltaTime);
        }
        else
        {
            count = 45;
            mod *= -1;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Player"))
        {
            mod = 0;
            StartCoroutine(NextLevel()); 
        }
    }

    IEnumerator NextLevel()
    {
        //UnityEngine.Time.timeScale = 0.25f;
        for (int i = 0; i < 60; ++i)
        {
            transform.localScale += Vector3.one * 0.1f;
            transform.Rotate(new Vector3(0, 0, -5));
            yield return new WaitForSeconds(0.01f);
        }
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        UnityEngine.Time.timeScale = 1f;
        yield return 0;
    }

}