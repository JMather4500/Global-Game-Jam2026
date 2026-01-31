using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Queue<string> sentenceQueue;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentenceQueue = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;
        //Debug.Log("Started conversation with " + dialog.name);
        sentenceQueue.Clear();

        foreach (string sentence in dialog.sentenceQueue)
        {
            sentenceQueue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentenceQueue.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentenceQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogText.text = sentence;
        //Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;

            //    for (int i = 0; i == 2; i ++)
            //    {
            //        yield return null;
            //    }
            }
        }

        void EndDialog()
    {
        animator.SetBool("IsOpen", false);

        Debug.Log("End of Convosation");
    }
}
