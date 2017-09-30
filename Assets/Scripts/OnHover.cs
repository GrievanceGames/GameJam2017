using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour {

    SpriteRenderer oldSprite;
    Sprite newSprite;
    Sprite oriSprite;

    // Use this for initialization
    void Start () {
        oldSprite = GetComponent<SpriteRenderer>();
        newSprite = GetComponent<Sprite>();
        oriSprite = GetComponent<Sprite>();

    }

    void OnMouseOver()
    {
        oldSprite.sprite = newSprite;
        print("in");
    }

    void OnMouseExit()
    {
        oldSprite.sprite = oriSprite;
        print("out");
    }

}
