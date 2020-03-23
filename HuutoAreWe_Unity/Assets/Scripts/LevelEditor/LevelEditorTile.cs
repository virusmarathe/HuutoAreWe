using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorTile : MonoBehaviour
{
    public SpriteRenderer CurrentImage;
    public TextMesh Text;
    int entityIndex = -1;
    Vector2 coords;
    bool isText = false;

    public void SetSprite(Sprite sprite, int index)
    {
        CurrentImage.enabled = true;
        CurrentImage.sprite = sprite;
        entityIndex = index;
        isText = false;
    }

    public void SetText(string textVal, int index)
    {
        CurrentImage.enabled = false;
        Text.text = textVal.ToUpper();
        isText = true;
    }

    public void SetCoords(int x, int y)
    {
        coords = new Vector2(x, y);
    }

    public string GetExportString()
    {
        int isTextVal = isText ? 1 : 0;
        return coords.x + "," + coords.y + "," + entityIndex + "," + isTextVal;
    }
}
