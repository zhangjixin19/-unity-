using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTogglesManager : MonoBehaviour {
    [HideInInspector]
    public List<MyToggleBehaviour> selectedToggles = new List<MyToggleBehaviour>();
    public int maxSelectCount;
    int currentSelectCount;
	void Start () {
		
	}
	
	public void SelectToggle(MyToggleBehaviour mt,bool isSelected,bool isAuto)
    {
        if (isAuto)
            return;
        if (isSelected)
        {
            if (currentSelectCount < maxSelectCount)
            {
                mt.ToBeSelected();
                currentSelectCount++;
                selectedToggles.Add(mt);
            }
            else
            {
                mt.ToBeSelected();
                selectedToggles.Add(mt);

                selectedToggles[0].BeDisSelected();
                selectedToggles.RemoveAt(0);
            }
        }
        else
        {
            selectedToggles.Remove(mt);
            currentSelectCount--;
        }
    }
}
