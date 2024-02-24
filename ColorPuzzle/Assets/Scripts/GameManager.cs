using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    Debug.LogError("GameManager instance not found in the scene.");
                }
            }
            return _instance;
        }
    }

    public GameObject squarePrefab;
    public int rowCount = 5; 
    public int columnCount = 5; 
    public List<GameObject> blocks;
    public GameObject btnColor;
    [SerializeField] List<Color> colors;
    [SerializeField] List<Color> colors2;

    void Awake()
    {
        CreateBoard();
        CreateButton();
    }

    void CreateBoard()
    {
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                Vector3 position = new Vector3(j * 1, i * 1, 0);
                GameObject square = Instantiate(squarePrefab, position, Quaternion.identity);
                square.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                blocks.Add(square);
            }

        }
    }
    void CreateButton()
    {
        for (int i = -1; i < columnCount + 1; i++)
        {
            if (i == -1)
            {
                for (int ii = 0; ii < columnCount; ii++)
                {
                    Vector3 pos = new Vector3(ii, i, 0);
                    GameObject b = Instantiate(btnColor, pos, Quaternion.identity);
                    b.GetComponent<ButtonHand>().buttonType = ButtonType.X;
                    b.GetComponent<ButtonHand>()._color = colors[ii];
                    b.GetComponentInChildren<SpriteRenderer>().color = colors[ii];
                }
            }
            if (i == columnCount)
            {
                for (int ii = 0; ii < rowCount; ii++)
                {
                    Vector3 pos = new Vector3(i, ii, 0);
                    GameObject b = Instantiate(btnColor, pos, Quaternion.identity);
                    b.GetComponent<ButtonHand>().buttonType = ButtonType.Y;
                    b.GetComponent<ButtonHand>()._color = colors2[ii];
                    b.GetComponentInChildren<SpriteRenderer>().color = colors2[ii];
                }

            }
        }
    }
}
