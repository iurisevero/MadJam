using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public const string FireNotification = "InputController.FireNotification";
    private const float ClickDeltaTime = 0.2F;
    private const int _fire_number = 0;
    private float downClickTime;


    void Update(){
        if(Input.GetMouseButtonDown(_fire_number)){
            downClickTime = Time.time;
        }

        if(Input.touchCount <= 1){  // One touch or mouse
            if(Input.GetMouseButtonUp(_fire_number)){
                if(Time.time - downClickTime <= ClickDeltaTime){  // Click
                    this.PostNotification(FireNotification, new Info<int>(_fire_number));
                }
            }
        }
        // if(Input.GetKeyDown(KeyCode.Return)){
        //     this.PostNotification(FireNotification, new Info<int>(_fire_number));
        // }
    }

    /// <summary>
    /// Cast a ray to test if Input.mousePosition is over any UI object in EventSystem.current. This is a replacement
    /// for IsPointerOverGameObject() which does not work on Android in 4.6.0f3
    /// </summary>
    private bool IsPointerOverUIObject() {
        // Referencing this code for GraphicRaycaster https://gist.github.com/stramit/ead7ca1f432f3c0f181f
        // the ray cast appears to require only eventData.position.
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    
        List<RaycastResult> results = new List<RaycastResult>();
        if(EventSystem.current != null)
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}