using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;


public class CharacterSelect : MonoBehaviour
{
    
    PlayerControls control;
    public Transform canvas;
    public Transform PlayerCount;
    int NumberOfPlayers;
    public Transform CharTeamSelect;
    public TextMeshProUGUI TeamText;
    public Image TeamColor;
    public Image CharImage;
    public Sprite [] sprites;
    int spriteIndex;
    public GameObject ReadyText;
    public int joyId;
    public int CharID;

    private void Awake()
    {
        control = new PlayerControls();
        NumberOfPlayers = GameObject.Find("MenuManager").GetComponent<MenuManager>().playerCount;

        Debug.Log(NumberOfPlayers);
        DontDestroyOnLoad(this.gameObject);

        PlayerCount.GetComponent<TextMeshProUGUI>().text = "Player " + NumberOfPlayers.ToString();
        if (NumberOfPlayers == 1)
        {
            CharTeamSelect.position = GameObject.Find("Player1pos").transform.position;
            gameObject.name = gameObject.name + " 1";
        }
        else if (NumberOfPlayers == 2)
        {
            CharTeamSelect.position = GameObject.Find("Player2pos").transform.position;
            gameObject.name = gameObject.name + " 2";

        }
       Debug.Log(Gamepad.current.deviceId);

    }

    public void TeamRight(InputAction.CallbackContext value) 
    {
        if (value.performed)
        {
            TeamColor.color = new Color(1, 0, 0, 1);
            TeamText.text = "Red Team";
        }
    }

    public void TeamLeft(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            TeamColor.color = new Color(0,0,1,1);
            TeamText.text = "Blue Team";
        }
    }

    public void CharRight(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            spriteIndex++;
            if (spriteIndex > sprites.Length-1)
            {
                spriteIndex = 0; 
            }
            CharImage.sprite = sprites[spriteIndex];
        }
    }

    public void CharLeft(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            spriteIndex--;
            if (spriteIndex < 0)
            {
                spriteIndex = sprites.Length-1;
            }
            CharImage.sprite = sprites[spriteIndex];
        }
    }

    public void ReadyToPlay(InputAction.CallbackContext value) 
    {
        if (value.performed)
        {
            ReadyText.SetActive(true);
            joyId = Gamepad.current.deviceId;
            SceneManager.LoadScene("Level1_Daniel");
            gameObject.GetComponent<PlayerInput>().enabled = false;
            canvas.GetComponent<Canvas>().enabled = false;
            CharID = spriteIndex;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
