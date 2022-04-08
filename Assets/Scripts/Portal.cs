using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log("Portal entered by: " + coll.name);

        if (coll.name == "Player")
        {
            GameManager.instance.SaveState();
            Debug.Log("Teleport Player");
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
