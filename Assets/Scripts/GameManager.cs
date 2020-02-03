using System.Collections;
using System.Collections.Generic;
using Level2;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints = new List<Checkpoint>();
    public static GameManager instance;
    private PlayerMovement player;

    public Platforms platform;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        Debug.Log("Player: " + player);

        if (checkpoints.Count <= 0)
        {
            checkpoints.AddRange(FindObjectsOfType<Checkpoint>());
        }

        StartCoroutine(SpawnPlayer(0f));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     Fade.instance.FadeIn(1f, 0f);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     Fade.instance.FadeOut(1f, 0f);
        // }
    }
    
    private IEnumerator SpawnPlayer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        TextEffect3D.level1Collision = true;
        string lastPoint = PlayerPrefs.GetString("lastCheckpoint");

        if (lastPoint == null)
            lastPoint = "TWO_D";
        else
        {
            Transform spawnPoint = checkpoints.Find(x => x.currentCheckpoint.ToString().Contains(lastPoint)).transform;
            player.transform.position = spawnPoint.position;
        }
            
    }

    public void BringUpPlatform()
    {
        
        platform.platformEnterEvent.Invoke();
    }

    public void Death()
    {
        Fade.instance.FadeOut(1f, 0f);
        StartCoroutine(SpawnPlayer(1f));
        Fade.instance.FadeIn(1f, 1.5f);
        SceneManager.LoadScene(0);

    }

}
