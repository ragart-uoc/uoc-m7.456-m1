using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public TextMeshProUGUI HistoryText;
    public Transform AnswersParent;
    public GameObject AnswersButtonPrefab;
    public AudioSource ButtonSound;

    private StoryNode currentNode;

    private void Start()
    {
        currentNode = StoryFiller.FillStory();
        HistoryText.text = string.Empty;
        FillUi();
    }
    private void FillUi()
    {
        if (HistoryText.text != string.Empty)
        {
            HistoryText.text += "\n\n";
        }
        HistoryText.text += currentNode.History;

        foreach (Transform child in AnswersParent.transform)
        {
            Destroy(child.gameObject);
        }

        var index = 0;
        foreach (var answer in currentNode.Answers)
        {
            var buttonAnswerCopy = Instantiate(AnswersButtonPrefab, AnswersParent, true);
            buttonAnswerCopy.GetComponent<RectTransform>().transform.localScale = Vector3.one;
            FillListener(buttonAnswerCopy.GetComponent<Button>(), index);
            buttonAnswerCopy.GetComponentInChildren<TextMeshProUGUI>().text = answer;
            index++;
        }
    }

    private void FillListener(Button button, int index)
    {
        button.onClick.AddListener(() => { AnswerSelected(index); });
        button.onClick.AddListener(() => { ButtonSound.Play(); });
    }

    private void AnswerSelected(int index)
    {
        HistoryText.text += "\n\n" + currentNode.Answers[index];
        if (!currentNode.IsFinal)
        {
            currentNode = currentNode.NextNode[index];
            currentNode.OnNodeVisited?.Invoke();
            FillUi();
        }
        else
        {
            HistoryText.text += "\n\nPress ESC to continue";
        }

        if (HistoryText.GetComponent<RectTransform>().pivot.y == 0) return;
        HistoryText.GetComponent<RectTransform>().pivot = new Vector2(1, 0);
        HistoryText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}
