using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{

    public Sprite emptyChest;
    public int coinsAmount = 5;

    // Start is called before the first frame update
    protected override void OnCollect()
    {
        if (! base.isCollected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+ " + coinsAmount + " coins!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.0f);
        }
    }
}
