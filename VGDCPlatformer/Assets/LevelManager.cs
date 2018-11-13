using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
 
    public GameObject playerObject;

    public Text respawnText;

    public float sceneDelay = 0f;

	// Use this for initialization
	void Start () {
        respawnText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObject.activeSelf == false)
            reloadLevelOnInput();
	}

    public void reloadLevelOnInput()
    {
        respawnText.gameObject.SetActive(true);
        if(Input.GetButton("Jump"))
        {
            StartCoroutine(DelayReload(sceneDelay));
        }
    }

    IEnumerator DelayReload(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
