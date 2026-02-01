using UnityEngine;

public class levelmanager : MonoBehaviour
{
    private GameObject player;
    public GameObject starterLevel;
    public GameObject otherLevel1;
    public GameObject otherLevel2;
    private GameObject currentLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Servicehub.Instance.player.gameObject;
        starterLevel.SetActive(true);
        otherLevel1.SetActive(false);
        otherLevel2.SetActive(false);

        currentLevel = starterLevel;
         
    }

    //when the level is updated

    public void LoadLevel(GameObject levelToLoad, Transform spawn)
    {
        currentLevel.SetActive(false);
        levelToLoad.SetActive(true);
        currentLevel = levelToLoad;
        player.transform.position = spawn.position;
    }
}
