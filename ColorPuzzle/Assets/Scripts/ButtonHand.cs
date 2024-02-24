using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum ButtonType
{
    X, Y
}
public class ButtonHand : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _btnColor;
    public ButtonType buttonType;
    int pos;
    public Color _color;
    private void Start()
    {

        if (buttonType == ButtonType.X)
        {
            pos = (int)gameObject.GetComponent<Transform>().transform.position.x;
        }
        if (buttonType == ButtonType.Y)
        {
            pos = (int)gameObject.GetComponent<Transform>().transform.position.y;
        }
        _btnColor.onClick.AddListener(ChangeColorsAccordingToButtonType);

    }

    void ChangeColorsAccordingToButtonType()
    {
        Debug.Log("OnClick");
        List<GameObject> yeni = GameManager.Instance.blocks;
        foreach (var item in yeni)
        {
            if (buttonType == ButtonType.X)
            {
                for (int i = 0; i < GameManager.Instance.rowCount; i++)
                {

                    if (item.transform.position.x == pos && item.transform.position.x == i)
                    {
                        item.gameObject.GetComponentInChildren<SpriteRenderer>().color = _color;
                    }
                }
            }
            if (buttonType == ButtonType.Y)
            {
                for (int i = 0; i < GameManager.Instance.columnCount; i++)
                {

                    if (item.transform.position.y == pos && item.transform.position.y == i)
                    {
                        item.gameObject.GetComponentInChildren<SpriteRenderer>().color = _color;
                    }
                }
            }


        }
    }
}
