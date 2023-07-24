using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.EventSystems;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public bool playerInSpace;
    public TextAsset inkJson;
    private Story currentStory;
    public bool dialogueIsPlaying;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialoguePrompt;
    public GameObject dialogueBox;
    public GameObject dialogueChoices;

    const string SPEAKER_TAG = "speaker";
    public TextMeshProUGUI speakerName;

    public GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    // Start is called before the first frame update
    void Start()
    {
        dialogueIsPlaying = false;
        playerInSpace = false;
        dialogueBox.SetActive(false);
        dialoguePrompt.gameObject.SetActive(false);
        dialogueChoices.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInSpace == true)
        {
            EnterDialogueMode(inkJson);

            DisplayChoices();
        }
        if (Input.GetKeyDown(KeyCode.Return) && playerInSpace == true)
        {
            ContinueStory();
            Debug.Log("Continue Story");
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            playerInSpace = true;
            dialoguePrompt.gameObject.SetActive(true);
          ;
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInSpace = false;
            dialoguePrompt.gameObject.SetActive(false);

        }
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueBox.SetActive(true);
        dialogueIsPlaying = true;
   

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        DisplayChoices();

        

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            HandleTags(currentStory.currentTags);
        }
        else
        {

            ExitDialogue();
        }
    }

    void ExitDialogue()
    {
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }

    void ContinueStory()
    {

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogue();

        }
    }

    void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.Log(splitTag.Length);
                Debug.LogError("Tag could not be parsed:" + tag);
            }
            string tagKey = splitTag[0];
            string tagValue = splitTag[1];
            speakerName.text = tagValue;

          

        }

    }

    private void DisplayChoices()
    {
        dialogueChoices.gameObject.SetActive(true);
        
        List<Choice> currentChoices = currentStory.currentChoices;

       
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        int index = 0;
        
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());

       
    }

    private IEnumerator SelectFirstChoice()
    {
 
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }


    public void MakeChoice(int choiceIndex)
    {
        
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
       
    }

}
