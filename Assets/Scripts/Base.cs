using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Base : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;

    public List<Object> objectList = new List<Object>();
    [SerializeField] private GameObject vfxAdded;

    private bool canCheck;

    private void Start()
    {
        canCheck = false;
    }

    private void SetPos()
    {
        foreach(Object obj in objectList)
        {
            if(obj != null)
                obj.transform.position = transforms[objectList.IndexOf(obj)].position;
        }
    }

    public void CheckId()
    {
        if (objectList.Count != 2) return;

        if (objectList[0].GetId() == objectList[1].GetId() && objectList.Count == 2 && !objectList[0].isCompleted && !objectList[1].isCompleted)
        {
            objectList[0].SetCompleted();
            objectList[1].SetCompleted();

            objectList[0].SetParentBase();
            objectList[1].SetParentBase();
        }
        

    }

    public void AddObject(Object obj)
    {
        if (objectList.Count < 2)
        {
            objectList.Add(obj);

            obj.transform.SetParent(gameObject.transform);

            obj.transform.position = transforms[objectList.IndexOf(obj)].position;

            GameObject vfx = Instantiate(vfxAdded, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            SetPos();

            return;
        }
    }

    public void RemoveObject(Object obj)
    {
        if (objectList.Contains(obj))
        {
            objectList.Remove(obj);

            SetPos();
        }
        else return;
    }
}
