using System.Collections;
using System.Collections.Generic;
using CleverCrow.Fluid.Databases;
using Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CreateProfileUIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstNameInputField;
    [SerializeField] private TMP_InputField lastNameInputField;

    [SerializeField] private TMP_Dropdown birthMonthDropDown;
    [SerializeField] private TMP_Dropdown birthDayDropDown;
    [SerializeField] private TMP_Dropdown hometownDropDown;
    
    [SerializeField] private KeyValueDataString firstNameDatabaseEntry;
    

    // Start is called before the first frame update
    void Start()
    {
        firstNameInputField.onValueChanged.AddListener(HandleFirstNameInput);
        lastNameInputField.onValueChanged.AddListener(HandleLastNameInput);

        birthMonthDropDown.onValueChanged.AddListener(HandleBirthMonthInput);
        birthDayDropDown.onValueChanged.AddListener(HandleBirthDayInput);
        hometownDropDown.onValueChanged.AddListener(HandleHometownInput);
    }

    private void HandleBirthMonthInput(int iput)
    {
        
    }
    
    private void HandleBirthDayInput(int iput)
    {
        
    }
    
    private void HandleHometownInput(int iput)
    {
        
    }

    private void HandleFirstNameInput(string input)
    {

    }

    private void HandleLastNameInput(string input)
    {
        
    }


// Update is called once per frame
    void Update()
    {
        
    }
    
}
