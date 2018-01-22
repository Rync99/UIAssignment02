using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyScript : MonoBehaviour {

    [SerializeField]
    GameObject joyObj = null;


    Image joyBG;
    Image joyFG;

    public Vector3 direction;
    Vector3 startPosition;

    public bool isStopDragging = true;


	// Use this for initialization
	void Start () {
        joyBG = joyObj.GetComponent<Image>();
        joyFG = joyBG.transform.GetChild(0).GetComponent<Image>();

	}
	
    public void StartPosition()
    {
        startPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
    }
    public void Dragging()
    {

#if UNITY_EDITOR || UNITY_WINDOWS
        //Vector3 screenPos = UICamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPosition = new Vector3(Input.mousePosition.x - startPosition.x, Input.mousePosition.y - startPosition.y, 1);

#elif UNITY_ANDROID
        Touch mytouch = Input.GetTouch(0);
        Vector3 tempPos = new Vector3(mytouch.position.x - startPosition.x, mytouch.position.y - startPosition.y, 1);

#endif
  
        isStopDragging = false;
        Vector2 temporaryPosition = new Vector2(Input.mousePosition.x - startPosition.x, Input.mousePosition.y - startPosition.y);
        Vector2 clampPos = Vector2.ClampMagnitude(temporaryPosition, 50);
        Vector3 newPos = new Vector3(clampPos.x, clampPos.y, 1);
        joyFG.rectTransform.localPosition = newPos;
        direction = joyFG.rectTransform.localPosition;

    }
    public void StopDrag()
    {
        joyFG.rectTransform.localPosition = new Vector3(0,0,1);
        isStopDragging = true;
    }
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (Application.platform == RuntimePlatform.Android)
                Application.Quit();
        }

	}
}
