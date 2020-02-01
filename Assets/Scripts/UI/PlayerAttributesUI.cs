using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributesUI : MonoBehaviour
{

    public Text HealthText;

    public Text AttackText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.PlayerAttributes != null)
        {
            HealthText.text = $"{GameManager.GM.PlayerAttributes.CurrentHP} / {GameManager.GM.PlayerAttributes.Attributes.MaxHP}";
            AttackText.text = $"{GameManager.GM.PlayerAttributes.GetDamage()}"; 
        }
    }
}
