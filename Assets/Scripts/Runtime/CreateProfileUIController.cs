using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using CleverCrow.Fluid.Databases;
using Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : EventData
{
    public string firstName;
    public string LastName;
    public string birthMonth;
    public string birthDate;
}

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
//        hometownDropDown.onValueChanged.AddListener(HandleHometownInput);
    }

    private void HandleBirthMonthInput(int input)
    {
        var daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, input + 1);

        birthDayDropDown.ClearOptions();

        for (var i = 0; i < daysInMonth; i++)
        {
            birthDayDropDown.options.Add(new TMP_Dropdown.OptionData($"{i + 1}"));
        }
    }
    
    private void HandleBirthDayInput(int input)
    {
        
    }
    
    private void HandleHometownInput(int input)
    {
        
    }

    private void HandleFirstNameInput(string input)
    {

    }

    private void HandleLastNameInput(string input)
    {
        
    }

    private void HandleSubmitPressed()
    {
        DateTime dt = new DateTime(1, birthMonthDropDown.value + 1, 1);

        // Get the DateTimeFormatInfo for the current culture
        DateTimeFormatInfo dtfi = CultureInfo.CurrentCulture.DateTimeFormat;

        // Get the full month name using the GetMonthName method
        string monthName = dtfi.GetMonthName(dt.Month);

        var profile = new PlayerProfile()
        {
            firstName = firstNameInputField.text,
            LastName = lastNameInputField.text,
            birthMonth = monthName,
            birthDate = $"{birthDayDropDown.value + 1}"
        };
        
        EventBus.Invoke(profile);
        DataBus.Set("PlayerProfile", profile);
    }
    
    


// Update is called once per frame
    void Update()
    {
        
    }
    
}
