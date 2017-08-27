using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class TitlescreenScript : MonoBehaviour
{
    [SerializeField]
    Animator startAnimator = null, menuAnimator = null, characterSelectAnimator = null;

    private bool startedMenu = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !startedMenu)
            PressStart();

        if (Input.GetButtonDown("Cancel_1") && Characters.Count > 0 && !Characters.Exists(c => c.PlayerNumber == PlayerNumber.Player_1 && c.IsReady))
        {
            ExitCharacterSelection();
        }
    }

    private void ActivateMenu()
    {
        menuAnimator.SetBool("Visible", true);
        GameObject button = menuAnimator.gameObject.GetComponentInChildren<Button>(true).gameObject;
        EventSystem.current.SetSelectedGameObject(button);
    }

    public void EnterCharacterSelection()
    {
        menuAnimator.SetBool("Visible", false);
        characterSelectAnimator.SetBool("Visible", true);
    }

    public void ExitCharacterSelection()
    {
        characterSelectAnimator.SetBool("Visible", false);
        characterSelectAnimator.GetComponentsInChildren<CharacterSelect>().ToList().ForEach(c => c.UnReadyPlayer());
        ActivateMenu();
    }

    public void PressStart()
    {
        startedMenu = true;

        startAnimator.SetTrigger("Disappear");
        ActivateMenu();
    }

    public void StartGame()
    {
        // Clear the list of active players
        GameInformation.Instance.ActivePlayers.Clear();

        // Add all the readied players to the list of active players
        foreach (CharacterSelect character in Characters)
        {
            if (character.IsReady)
                GameInformation.Instance.ActivePlayers.Add(character.PlayerNumber);
        }

        SceneManager.LoadScene("Main");
    }

    private List<CharacterSelect> Characters
    {
        get { return GetComponentsInChildren<CharacterSelect>().ToList(); }
    }
}
