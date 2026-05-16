using UnityEngine;

public class MaskFuente : MonoBehaviour
{
    public SpriteRenderer animatedSprite;
    public SpriteMask spriteMask;

    public Sprite sprite1;
    public Sprite sprite2;

    public Sprite mask1;
    public Sprite mask2;

    void LateUpdate()
    {
        if (animatedSprite.sprite == sprite1)
            spriteMask.sprite = mask1;
        else if (animatedSprite.sprite == sprite2)
            spriteMask.sprite = mask2;
    }
}
