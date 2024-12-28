using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameClockUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField]private Image progressImage;
    [SerializeField]private TextMeshProUGUI timeText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = Mathf.CeilToInt(PlayerManager.Instance.time).ToString();
        progressImage.fillAmount = PlayerManager.Instance.time / PlayerManager.Instance.PlayTimeTotal;
    }
}
