using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerCamera : MonoBehaviour
{
	public Texture2D rainbowMap;
	public Camera cam;
	public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;
    // Start is called before the first frame update
    void Start()
    {
         cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        int x = Mathf.FloorToInt(Mathf.Lerp(0, rainbowMap.width, t));
        cam.backgroundColor = rainbowMap.GetPixel(x,0);
    }
}
