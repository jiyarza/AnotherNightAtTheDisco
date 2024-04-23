using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    private static DialogController instance;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Text;



    public Dialog Dialog;

    public static DialogController Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
