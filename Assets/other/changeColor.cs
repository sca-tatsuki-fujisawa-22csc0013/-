using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour
{
    enum RGB
    {
        R = 0,
        G,
        B,
    }
    RGB _color = RGB.R;

    Text text;
    float[] rgb = new float[3];
    // Start is called before the first frame update
    void Start()
    {
        rgb[0] = 1.0f;
        rgb[1] = 0.0f;
        rgb[2] = 0.0f;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_color)
        {
            case RGB.R:
                ChangeColor(_color, _color + 1);
                break;
            case RGB.G:
                ChangeColor(_color, _color + 1);
                break;
            case RGB.B:
                ChangeColor(_color, RGB.R);
                break;
        }
        text.color = new Color(rgb[0],rgb[1],rgb[2]);
        //Debug.Log(text.color);
    }

    void ChangeColor(RGB nowColor, RGB toColor)
    {
        if(rgb[(int)toColor] < 1.0f)
        {
            rgb[(int)toColor] += Time.deltaTime;
            if(rgb[(int)toColor] >= 1.0f)
            {
                rgb[(int)toColor] = 1.0f;
            }
        }
        else
        {
            rgb[(int)nowColor] -= Time.deltaTime;
            if (rgb[(int)nowColor] <= 0.0f)
            {
                rgb[(int)nowColor] = 0.0f;
                _color = toColor;
            }
        }
    }
}
