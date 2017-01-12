using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour
{
    public GameObject page1, page2;

	public void Page1 ()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }

    public void Page2 ()
    {
        page2.SetActive(true);
        page1.SetActive(false);
    }
}
