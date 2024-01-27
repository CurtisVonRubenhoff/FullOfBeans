using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreenUIController : MonoBehaviour
{
    [Header("Button References")] [SerializeField]
    private Button startGameButton;

    [SerializeField] private Button optionsButton;

    [SerializeField] private Button creditsButton;

    [SerializeField] private Button quitButton;

    [Header("Panel References")] [SerializeField]
    private GameObject MainMenuPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnEnable()
    {
        startGameButton.onClick.AddListener(HandleStartGamePressed);
        optionsButton.onClick.AddListener(HandleOptionsButtonPressed);
        creditsButton.onClick.AddListener(HandleCreditsButtonPressed);
        quitButton.onClick.AddListener(HandleQuitButtonPressed);
    }

    private void HandleStartGamePressed()
    {
        Debug.Log("Start Game Button Pressed");
    }

    private void HandleOptionsButtonPressed()
    {
        Debug.Log("Options Button Pressed");

    }

    private void HandleCreditsButtonPressed()
    {
        Debug.Log("Credits Button Pressed");

    }

    private void HandleQuitButtonPressed()
    {
        Debug.Log("Quit Button Pressed");

        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

}
