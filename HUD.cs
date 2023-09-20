using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //basicamente é só pegar a vida do personagem e fazer uma regrinha de 3
        GetComponent<Image>().fillAmount -= Time.deltaTime * 0.1f;
    }
}
