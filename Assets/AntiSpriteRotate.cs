using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSpriteRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.up = Vector2.up;
    }
}
