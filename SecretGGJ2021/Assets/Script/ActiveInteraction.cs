using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInteraction : MonoBehaviour
{
    [SerializeField] int indexPoster = 0;
    [SerializeField] GameObject m_gameObject_Button_Activated;
    [SerializeField] bool activePoster = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activePoster) return;
        if (other.tag == "Player") {
            m_gameObject_Button_Activated.SetActive(true);
            m_gameObject_Button_Activated.GetComponent<ActiveUIPoster>().indexPosterActual = indexPoster;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_gameObject_Button_Activated.SetActive(false);
        }
    }
}
