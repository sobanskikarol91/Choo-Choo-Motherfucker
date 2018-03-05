using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite purple;

    [HideInInspector]
    public ColorObject playerColor;
    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerColor = GetComponent<ColorObject>();
    }

    public void ChangeColor()
    {
        playerColor._color = RandomColor();

        if (playerColor._color == COLOR.RED)
            _spriteRenderer.sprite = red;
        else if (playerColor._color == COLOR.BLUE)
            _spriteRenderer.sprite = blue;
        else if (playerColor._color == COLOR.GREEN)
            _spriteRenderer.sprite = green;
        else
            _spriteRenderer.sprite = purple;
    }

    COLOR RandomColor()
    {
        COLOR random = playerColor._color;

        while (random == playerColor._color)
            random = (COLOR)Random.Range(0, 4);

        return random;
    }
}
