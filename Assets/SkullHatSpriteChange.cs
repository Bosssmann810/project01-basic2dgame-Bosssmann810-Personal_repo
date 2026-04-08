using UnityEngine;

public class SkullHatSpriteChange : MonoBehaviour
{
    private SkullyDiolouge skull;
    public SpriteRenderer spriteRenderer;
    public Sprite hatSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skull = gameObject.GetComponent<SkullyDiolouge>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (skull.GetFinishedStatus())
        {
            spriteRenderer.sprite = hatSprite;
        }
    }
}
