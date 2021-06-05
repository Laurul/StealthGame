using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHandler : MonoBehaviour
{
    public PlayerStats Player;
    [SerializeField] Canvas m_canvas;
    private bool m_seeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (m_canvas)
            {
                m_seeCanvas = !m_seeCanvas;
                m_canvas.gameObject.SetActive(m_seeCanvas);
            }
        }
    }
}
