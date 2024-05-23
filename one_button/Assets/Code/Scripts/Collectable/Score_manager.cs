using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score_manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CollectableText;
    private int collectablecount;
    // Start is called before the first frame update
    void Start()
    {
        collectablecount = 0;
        UpdateCollectableText();
    }
    public void CollectablePickedup()
    {
        collectablecount++;
        UpdateCollectableText();
    }
    private void UpdateCollectableText()
    {
        CollectableText.text = "Score " + collectablecount + "00";
    }
  
    
}
