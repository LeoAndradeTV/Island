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

    public override void InitializeMineable()
    {
        mineTimer = 2.7f;
    }
}
