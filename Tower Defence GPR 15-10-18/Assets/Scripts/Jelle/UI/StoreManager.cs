using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {
    [SerializeField]
    Text storeText;
    [SerializeField]
    Canvas storeCanvas;
    private bool storeCanvasEnabled = false;

    private void Awake()
    {
        storeCanvas.enabled = storeCanvasEnabled;
        storeText.text = "Store";
    }


    public void SwitchCanvas()
    {
        storeCanvasEnabled = !storeCanvasEnabled;
        storeCanvas.enabled = storeCanvasEnabled;
        if (storeCanvasEnabled)
        {
            storeText.text = "Back";
        }
        else
        {
            storeText.text = "Store";
        }
    }
    
    
}
