using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcakMap : MonoBehaviour
{
    public Button button;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(RepeatScript);
    }

    private void RepeatScript()
    {
        map.GetComponent<MazeGenerator>().AcakPeta();
    }
}
