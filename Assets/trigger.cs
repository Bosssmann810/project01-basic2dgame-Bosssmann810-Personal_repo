using UnityEngine;

public class trigger : MonoBehaviour
{
    private GameObject player;
    public levelmanager manager;
    public GameObject Leveltoactivate;
    public Transform spawn;
    public Servicehub servicehub;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = servicehub.player.gameObject;
        manager = servicehub.levelmanager;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.LoadLevel(Leveltoactivate, spawn);
            Debug.Log("Entered");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
