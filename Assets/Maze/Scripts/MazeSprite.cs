using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSprite : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sRenderer;

    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetSprite(Sprite sprite, int sortingOrder)
    {
        sRenderer.sprite = sprite;
        sRenderer.sortingOrder = sortingOrder;
    }

    public void SetSprite(Sprite sprite)
    {
        SetSprite(sprite, 0);
    }
}
