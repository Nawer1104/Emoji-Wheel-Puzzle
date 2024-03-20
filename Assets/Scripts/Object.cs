using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private int Id;

    [SerializeField] private GameObject base_completed;

    public bool isCompleted;

    Transform baseParent;

    private void Start()
    {
        baseParent = GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].transform;

        SetParentBase();
    }

    public void SetCompleted()
    {
        if (isCompleted) return;

        isCompleted = true;

        base_completed.SetActive(true);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
        GameManager.Instance.CheckLevelUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCompleted) return;

        if (collision != null && collision.gameObject.GetComponent<Base>() != null)
        {
            if (collision.gameObject.GetComponent<Base>().objectList.Contains(this)) return;

            if (collision.gameObject.GetComponent<Base>().objectList.Count < 2)
            {
                GetComponent<DragAndDrop>()._dragging = false;

                collision.gameObject.GetComponent<Base>().AddObject(this);
                return;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.GetComponent<Base>() != null)
        {
            collision.gameObject.GetComponent<Base>().RemoveObject(this);

            transform.SetParent(baseParent);
        }
    }

    public int GetId()
    {
        return Id;
    }

    public void SetParentBase()
    {
        transform.SetParent(baseParent);
    }
}
