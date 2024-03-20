using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject gameObjectBase;

    public void CheckObject()
    {
        gameObjectBase.GetComponent<Base>().CheckId();
    }

    private void OnMouseDown()
    {
        CheckObject();
    }
}
