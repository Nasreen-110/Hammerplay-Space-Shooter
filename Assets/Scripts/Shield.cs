using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public SpriteRenderer shield;

    void Start()
    {
       

    }

    void Update()
    {
        if (shield != null)

        {
            shield.enabled = !shield.enabled;
        }
    }

}
