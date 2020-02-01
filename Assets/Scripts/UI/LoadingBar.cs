using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Image Outline; 

    public Image LoadingImage; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProgress(float percentage)
    {
        var width = Outline.rectTransform.rect.width * percentage;
        var theBarRectTransform = LoadingImage.transform as RectTransform;
        theBarRectTransform.sizeDelta = new Vector2(width, theBarRectTransform.sizeDelta.y); 
    }
}
