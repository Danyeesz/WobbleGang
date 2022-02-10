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
    public int TeamIndex;
    public int CharID = 0;
   
    PlayerControls control;
    public Transform PlayerCount;
    public Transform CharTeamSelect;
    public TextMeshProUGUI TeamText;
    public Image CharSelect_TeamColor;
    public Image CharSelect_CharImage;
    public Image InGame_TeamColor;
    public Image InGame_CharImage;
    public Sprite [] CharSelect_CharSprites;
    public Sprite [] CharSelect_TeamSprites;
    public Sprite[] InGame_CharSprites;
    public Sprite[] InGame_TeamSprites;

    public GameObject Lighty;
    public GameObject Strongy;
    public GameObject Speedy;
    public GameObject Breaky;

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
            CharSelect_TeamColor.sprite = CharSelect_TeamSprites[0];
            InGame_TeamColor.sprite = InGame_TeamSprites[0];
            PlayerCount.GetComponent<TextMeshProUGUI>().text = "P1";
            UI_InGame.transform.position = GameObject.Find("InGame1pos").transform.position;
            UI_InGame.GetComponentInChildren<TextMeshProUGUI>().text = "P1";


        }
        else if (NumberOfPlayers == 2)
        {
            CharTeamSelect.position = player2pos.transform.position;
            gameObject.name = gameObject.name + " 2";
            player2pos.GetComponent<Image>().enabled = false;
            CharSelect_TeamColor.sprite = CharSelect_TeamSprites[0];
            PlayerCount.GetComponent<TextMeshProUGUI>().text = "P2";
            UI_InGame.transform.position = GameObject.Find("InGame2pos").transform.position;
            UI_InGame.GetComponentInChildren<TextMeshProUGUI>().text = "P2";


        }
        else if (NumberOfPlayers == 3)
        {
            CharTeamSelect.position = player3pos.transform.position;
            gameObject.name = gameObject.name + " 3";
            player3pos.GetComponent<Image>().enabled = false;
            CharSelect_TeamColor.sprite = CharSelect_TeamSprites[0];
            PlayerCount.GetComponent<TextMeshProUGUI>().text = "P3";
            UI_InGame.transform.position = GameObject.Find("InGame3pos").transform.position;
            UI_InGame.GetComponentInChildren<TextMeshProUGUI>().text = "P3";

        }
        else if (NumberOfPlayers == 4)
        {
            CharTeamSelect.position = player4pos.transform.position;
            gameObject.name = gameObject.name + " 4";
            player4pos.GetComponent<Image>().enabled = false;
            CharSelect_TeamColor.sprite = CharSelect_TeamSprites[0];
            PlayerCount.GetComponent<TextMeshProUGUI>().text = "P4";
            UI_InGame.transform.position = GameObject.Find("InGame4pos").transform.position;
            UI_InGame.GetComponentInChildren<TextMeshProUGUI>().text = "P4";

        }


    }

    public void Update()
    {
        if (MenuManager.GetComponent<MenuManager>().GameStarted == true)
        {
            UI_CharSelection.SetActive(false);
        }
        
    }

    public void TeamRight(InputAction.CallbackContext value) 
    {
        if (value.performed)
        {
            TeamIndex++;
            if (TeamIndex > CharSelect_TeamSprites.Length-1)
            {
                TeamIndex = 0;
              
            }
            CharSelect_TeamColor.sprite = CharSelect_TeamSprites[TeamIndex];
            InGame_TeamColor.sprite = InGame_TeamSprites[TeamIndex];

        }
    }

    public void TeamLeft(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            TeamIndex--;
            if (TeamIndex < 0)
            {
                TeamIndex = CharSelect_TeamSprites.Length - 1;
            }
            CharSelect_TeamColor.sprite = CharSelect_TeamSprites[TeamIndex];
            InGame_TeamColor.sprite = InGame_TeamSprites[TeamIndex];



        }
    }

    public void CharRight(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            spriteIndex++;
            if (spriteIndex > CharSelect_CharSprites.Length-1)
            {
                spriteIndex = 0; 
            }
            CharSelect_CharImage.sprite = CharSelect_CharSprites[spriteIndex];
            InGame_CharImage.sprite = InGame_CharSprites[spriteIndex];
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
                spriteIndex = CharSelect_CharSprites.Length-1;
            }
            CharSelect_CharImage.sprite = CharSelect_CharSprites[spriteIndex];
            InGame_CharImage.sprite = InGame_CharSprites[spriteIndex];
            CharID = spriteIndex;
        }
    }

    public void ReadyToPlay(InputAction.CallbackContext value) 
    {
        if (value.performed)
        {
            Debug.Log(TeamIndex);
            ReadyText.SetActive(true);
            MenuManager.GetComponent<MenuManager>().playersReady++;
            UI_InGame.SetActive(true);
            gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Movement");
          

            if (CharID == 0)
            {
                Lighty.SetActive(true);
            }
            else if (CharID == 1)
            {
                Strongy.SetActive(true);
            }
            else if (CharID == 2)
            {
                Speedy.SetActive(true);
            }
            else if (CharID == 3)
            {
                Breaky.SetActive(true);
            }
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
