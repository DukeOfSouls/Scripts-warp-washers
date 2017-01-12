using UnityEngine;
using System.Collections;

public class GuideScript : MonoBehaviour
{
    public Animator flip;
    int activeHash = Animator.StringToHash("flip");
    int activeHash2 = Animator.StringToHash("flip2");

    public GameObject page1, page2, page3, page4, page5;
    public int pageNumber;
    private bool flipPage;
    private bool wait;


    void Start ()
    {
        wait = false;
        flipPage = true;
        pageNumber = 1;
    }

    void Update ()
    {
        if (pageNumber <= 0) pageNumber = 1;
        if (pageNumber >= 6) pageNumber = 5;

        if (flipPage == true)
        {
            if (pageNumber == 1)
            {
                page1.SetActive(true);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(false);
            }

            else if (pageNumber == 2)
            {
                page1.SetActive(false);
                page2.SetActive(true);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(false);
            }

            else if (pageNumber == 3)
            {
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(true);
                page4.SetActive(false);
                page5.SetActive(false);
            }

            else if (pageNumber == 4)
            {
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(true);
                page5.SetActive(false);
            }

            else if (pageNumber == 5)
            {
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(true);
            }

        }
    }

    public void Next ()
    {
        if (wait == false)
        {
            if (pageNumber < 5)
            {
                wait = true;
                flipPage = false;
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(false);
                flip.SetTrigger(activeHash);
                Invoke("NextNumber", 0.8f);
            }
        }
    }

    void NextNumber ()
    {
        wait = false;
        flipPage = true;
        pageNumber++;
    }

    public void Previous ()
    {
        if (wait == false)
        {
            if (pageNumber > 1)
            {
                wait = true;
                flipPage = false;
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(false);
                page4.SetActive(false);
                page5.SetActive(false);
                flip.SetTrigger(activeHash2);
                Invoke("PreviousNumber", 0.8f);
            }
        }
    }

    void PreviousNumber ()
    {
        wait = false;
        flipPage = true;
        pageNumber--;
    }
}
