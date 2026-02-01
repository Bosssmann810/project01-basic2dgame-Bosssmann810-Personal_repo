using UnityEngine;

public class spawnpoiunt : MonoBehaviour
{
    private GameObject player;
    private levelmanager manager;
    public GameObject Leveltoactivate;
    public Transform spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Servicehub.Instance.player.gameObject;
        manager = Servicehub.Instance.levelmanager;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.LoadLevel(Leveltoactivate, spawn); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
