using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour {
    public int sortOrder;
    public string sortLayerName;
    private void Start() {
        SetLayer();
    }

    //use to set 2dLayer ,bigger sortingOrder ,draw upper  
    void SetLayer() {
        SpriteRenderer r = this.GetComponent<SpriteRenderer>();
        r.sortingLayerName = sortLayerName;
        r.sortingOrder = sortOrder;
    }
 
}
