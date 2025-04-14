using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    private PlayerRPG player;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "" + player.health;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
