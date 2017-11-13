using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : Tower {

    void Update()
    {
        Rotation = 35;
        transform.Rotate(Vector3.up * Time.deltaTime * Rotation, Space.World);
    }
}
