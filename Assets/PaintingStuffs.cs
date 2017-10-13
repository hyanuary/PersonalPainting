using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingStuffs : MonoBehaviour {

    public Texture2D tex;
    public Texture2D stencil;
    public GameObject canvas;
    public GameObject stencilObj;
    int x;
    int y;
    int r;

    // Use this for initialization
    void Start () {

        tex = new Texture2D(1024, 1024);
        stencil = new Texture2D(1024, 1024);
        canvas.GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
        stencilObj.GetComponent<Renderer>().material.SetTexture("_MainTex", stencil);
        
    }
	
	// Update is called once per frame
	void Update () {

        //for (int x = 0; x < 1024; x++)
        //    for (int y = 0; y < 1024; y++)
        //        tex.SetPixel(x, y, Color.red);

        //coloring the canvas
        if (Input.GetKeyDown(KeyCode.Space))
        {
            x = Random.Range(1, 1023);
            y = Random.Range(1, 1023);
            r = Random.Range(1, 10);
            DrawCircle(x, y, r, Color.red);
            Debug.Log("press");
        }
        tex.Apply();
    }

    //Detecting the stencil if working or not
    void StencilDetection()
    {

    }

    //drawing the circle 
    void DrawCircle(int cx, int cy, int rad, Color col)
    {
        for (int x = Mathf.Max(cx - rad, 0); x <= Mathf.Min(cx + rad, tex.width - 1); x++)
        {
            for (int y = Mathf.Max(cy - rad, 0); y <= Mathf.Min(cy + rad, tex.height - 1); y++)
            {
                tex.SetPixel(x, y, col);
            }

        }

    }


}
