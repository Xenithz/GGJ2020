using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints = new List<Checkpoint>();
    private PlayerMovement player;


    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        if (checkpoints.Count <= 0)
        {
            checkpoints.AddRange(FindObjectsOfType<Checkpoint>());
        }

        SpawnPlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }
    }

    void SpawnPlayer()
    {
        string lastPoint = PlayerPrefs.GetString("lastCheckpoint");

        if (lastPoint != null)
        {
            Transform spawnPoint = checkpoints.Find(x => x.currentCheckpoint.ToString().Contains(lastPoint)).transform;
            player.transform.position = spawnPoint.position;
        }
    }
}
