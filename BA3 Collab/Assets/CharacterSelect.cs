using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;


public class CharacterSelect : MonoBehaviour
{

    public int NumberOfPlayers;
    int spriteIndex;
    int TeamIndex;
    public int CharID = 0;

    PlayerControls control;
    public Transform PlayerCount;
    public Transform CharTeamSelect;
    public TextMeshProUGUI TeamText;
    public Image TeamColor;
    public Image CharImage;
    public Sprite [] CharSprites;
    public Sprite [] TeamSprites;

    GameObject canvas;
    public GameObject ReadyText;
    GameObject player1pos;
    GameObject player2pos;
    GameObject player3pos;
    GameObject player4pos;
    GameObject MenuManager;
    public GameObject UI_InGame;
    public GameObject UI_CharSelection;
   

    private void Awake()
    {
        canvas = GameObject.Find("CharacterSelection");
        player1pos = GameObject.Find("Player1pos");
        player2pos = GameObject.Find("Player2pos");
        player3pos = GameObject.Find("Player3pos");
        player4pos = GameObject.Find("Player4pos");

        control = new PlayerControls();
        MenuManager = GameObject.Find("GameManager");
        NumberOfPlayers = MenuManager.GetComponent<MenuManager>().playerCount;
        DontDestroyOnLoad(this.gameObject);

        if (NumberOfPlayers == 1)
        {
            CharTeamSelect.position = player1pos.transform.position;
            gameObject.name = gameObject.name + " 1";
            player1pos.GetComponent<Image>().enabled = false;
            TeamColor.sprite = TeamSprites[0];
            PlayerCount.GetComponent<TextMeshProUGUI>().text = "P1";
        }
        else if (NumberOfPlayers == 2)
        {
            CharTeamSelect.position = player2pos.transform.position;
            gameObject.name = gameObject.name + " 2";
            player2pos.GetComponent<Image>().enabled = false;
            TeamColor.sprite = TeamSprites[0];
            PlayerCount.GetComponent<TextMeshProUGUI>().text = "P2";

        }
        else if (NumberOfPlayers == 3)
        {
            CharTeamSelect.position = player3pos.transform.position;
            gameObject.name = gameObject.name + " 3";
            player3pos.GetComponent<Image>().enabled = false;
            TeamColor.sprite = TeamSprites[0];
            PlayerCount.GetComponent<TextMeshProUGUI>().text = "P3";
        }
        else if (NumberOfPlayers == 4)
        {
            CharTeamSelect.position = player4pos.transform.position;
            gameObject.name = gameObject.name + " 4";
            player4pos.GetComponent<Image>().enabled = false;
            TeamColor.sprite = TeamSprites[0];
            PlayerCount.GetComponent<TextMeshProUGUI>().text = "P4";
        }

        
    }

    public void TeamRight(InputAction.CallbackContext value) 
    {
        if (value.performed)
        {
            TeamIndex++;
            if (TeamIndex > TeamSprites.Length-1)
            {
                TeamIndex = 0;
              
            }
            TeamColor.sprite = TeamSprites[TeamIndex];
      
           
        }
    }

    public void TeamLeft(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            TeamIndex--;
            if (TeamIndex < 0)
            {
                TeamIndex = TeamSprites.Length - 1;
            }
            TeamColor.sprite = TeamSprites[TeamIndex];
            
        }
    }

    public void CharRight(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            spriteIndex++;
            if (spriteIndex > CharSprites.Length-1)
            {
                spriteIndex = 0; 
            }
            CharImage.sprite = CharSprites[spriteIndex];
            CharID = spriteIndex;
        }
    }

    public void CharLeft(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            spriteIndex--;
            if (spriteIndex < 0)
            {
                spriteIndex = CharSprites.Length-1;
            }
            CharImage.sprite = CharSprites[spriteIndex];
            CharID = spriteIndex;
            Debug.Log(CharID);
        }
    }

    public void ReadyToPlay(InputAction.CallbackContext value) 
    {
        if (value.performed)
        {
            ReadyText.SetActive(true);
            canvas.SetActive(false);
            MenuManager.GetComponent<MenuManager>().playersReady--;
            UI_CharSelection.SetActive(false);
            UI_InGame.SetActive(true);
            gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Movement");
           
        }
    }

    private void OnEnable()
    {
        control.MenuControls.Enable();
    }

    private void OnDisable()
    {
        control.MenuControls.Disable();
    }




}
