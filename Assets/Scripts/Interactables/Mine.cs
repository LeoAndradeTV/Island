using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : BaseMineable
{
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        startingMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
