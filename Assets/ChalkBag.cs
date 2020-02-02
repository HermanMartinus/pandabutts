using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalkBag : MonoBehaviour
{
    public int chalkLevel = 3;
    public Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(chalkLevel <= 0) return;

        if(collision.tag == "hand") {
            chalkLevel -= 1;
            if (character)
                character.ChalkUp();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
