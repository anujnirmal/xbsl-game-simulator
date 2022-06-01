using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBoxManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameObjectiveBox;    

    public void ObjectiveButtonClicked(){

        GameObjectiveBox.SetActive(!GameObjectiveBox.active);
        
        //GameObject go3 = new GameObject("Plane New", typeof(RectTransform));

    }


}
