using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MyToggleBehaviour : MonoBehaviour,IPointerDownHandler {

    public MyTogglesManager myToggles;
    Toggle toggle;
    bool isAuto;
    public void ToBeSelected()
    {
      //  toggle.isOn = true;
        print("选择了");
    }
    public void BeDisSelected()
    {
        isAuto = true;
        toggle.isOn = false;
        print("勾掉了");
    }
    void Awake () {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener( on=> { myToggles.SelectToggle(this, toggle.isOn,isAuto);});
        //toggle.interactable = false;
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        isAuto = false;
    }
}
