using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class BackgroundRandom : MonoBehaviour
{
    public List<Sprite> backgrounds;
    public SpriteRenderer backgroundRenderer;

    void Start()
    {
        SetRandomBackground();
        FitToCamera();
    }

    public void SetRandomBackground()
    {
        if (backgrounds.Count == 0) return;
        int index = Random.Range(0, backgrounds.Count);
        backgroundRenderer.sprite = backgrounds[index];
        FitToCamera();
    }

    void FitToCamera()
    {
        if (backgroundRenderer == null || backgroundRenderer.sprite == null)
            return;

        float height = Camera.main.orthographicSize * 2;
        float width = height * Camera.main.aspect;

        float spriteWidth = backgroundRenderer.sprite.bounds.size.x;
        float spriteHeight = backgroundRenderer.sprite.bounds.size.y;

        backgroundRenderer.transform.localScale = new Vector3(width / spriteWidth, height / spriteHeight, 2.01f);
    }



    void Update()
    {
        
    }
}
