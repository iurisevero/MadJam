using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Image portal;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Button button;


    public void Display(WorldData wd)
    {
        title.text = wd.title;
        description.text = wd.description;
        portal.sprite = wd.sprite;
    }
}
