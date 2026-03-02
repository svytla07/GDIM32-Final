using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EventClick : MonoBehaviour, IPointerClickHandler
{
   public void OnPointerClick(PointerEventData pointerEventData)
   {
     Debug.Log("the object hath been clicked");
     Destroy(gameObject);

   }


}
