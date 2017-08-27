using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlescreenScript : MonoBehaviour
{
    [SerializeField]
    Animator titleAnimator, startAnimator, menuAnimator, characterSelectAnimator;

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

        if (Input.GetButtonDown("Cancel_1"))
        {
            ExitCharacterSelection();
        }
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

        menuAnimator.SetBool("Visible", true);
    }

    public void PressStart()
    {
        startedMenu = true;

        startAnimator.SetTrigger("Disappear");
        menuAnimator.SetBool("Visible", true);
    }

    public void StartGame()
    {
        CharacterSelect[] characters = GetComponentsInChildren<CharacterSelect>();
        // Clear the list of active players
        GameInformation.Instance.ActivePlayers.Clear();

        // Add all the readied players to the list of active players
        foreach (CharacterSelect character in characters)
        {
            if (character.IsReady)
                GameInformation.Instance.ActivePlayers.Add(character.PlayerNumber);
        }

        SceneManager.LoadScene("Main");
    }
}
