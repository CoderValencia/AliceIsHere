using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;

public class DialogueTrigger : MonoBehaviour
{
    public bool playerInSpace;
    public TextAsset inkJson;
    private Story currentStory;
    public bool dialogueIsPlaying;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialoguePrompt;
    public GameObject dialogueBox;

    const string SPEAKER_TAG = "speaker";
    public TextMeshProUGUI speakerName;

    // Start is called before the first frame update
    void Start()
    {
        dialogueIsPlaying = false;
        playerInSpace = false;
        dialogueBox.SetActive(false);
        dialoguePrompt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInSpace == true)
        {
            EnterDialogueMode(inkJson);
        }
        if ((Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)) && playerInSpace == true)
        {
            ContinueStory();
            Debug.Log("Continue Story");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player is in talking space");
            playerInSpace = true;
            dialoguePrompt.gameObject.SetActive(true);
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player is out of talking space");
            playerInSpace = false;
            dialoguePrompt.gameObject.SetActive(false);
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueBox.SetActive(true);
        dialogueIsPlaying = true;


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
        Debug.Log(currentStory.currentText);
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
            Debug.Log(tagValue);
          

        }

    }
}
