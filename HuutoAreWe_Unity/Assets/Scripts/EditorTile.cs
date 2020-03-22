using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTile : MonoBehaviour
{
    public SpriteRenderer CurrentImage;

    public void SetSprite(Sprite sprite)
    {
        CurrentImage.sprite = sprite;
    }
}
