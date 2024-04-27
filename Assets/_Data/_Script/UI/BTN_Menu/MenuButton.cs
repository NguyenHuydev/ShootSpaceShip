using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] protected Button buttonMenu;
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;


    // Methot of UNITY
    /*****************************************************************/

    protected void Awake()
    {
        LoadButton();
        
    }
    protected void Start()
    {
        AddOnClickEvent();
    }
    /*****************************************************************/
    private void LoadButton()
    {
        if (this.buttonMenu != null) return;
        buttonMenu = GetComponent<Button>();
        if (this.buttonMenu == null) Debug.LogWarning("buttonMenu of scrpit MenuButton Null");
    }

     protected void AddOnClickEvent()
    {
        this.buttonMenu.onClick.AddListener(this.OnClick);

    }

    protected void OnClick()
    {
        Debug.Log("dsadasdas");
    }

}
