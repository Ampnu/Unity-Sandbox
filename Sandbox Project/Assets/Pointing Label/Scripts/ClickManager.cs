using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ClickManager : MonoBehaviour
{
    // The DataBase that gives us the description of a clicked object
    public DataBase dataBase;

    // The Drawer of the line
    public LineDrawer theLineDrawer;

    // The Info Message Panel GameObject
    public GameObject panel;

    // The Title of the Info Message Panel
    public Text panelTitle;

    // The Description of the Info Message Panel
    public Text panelDescription;

    // The Scroll Bar of the Info Message Pane
    public Scrollbar scrollBar;

    // The GameObject that we put on the click point (very small sphere for exemple)
    public GameObject spherePointer;


    private bool dragging = false;

    private bool mouseButtonDown = false;

    private string lastClickedPartname = "";

    // Use this for initialization
    void Start () {
        panel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        bool acceptClick = false;
        if (mouseButtonDown)
        {
            if (mouseIsMoving())
            {
                dragging = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseButtonDown = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            if (!dragging)
                acceptClick = true;
            mouseButtonDown = false;
            dragging = false;
        }

        if (acceptClick)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Vector3 clickPosition = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(clickPosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                   
                    spherePointer.SetActive(false);

                    float signX = 1;
                    float signY = 1;

                    if (clickPosition.x > Screen.width / 2.0f) signX = -1;
                    if (clickPosition.y > Screen.height / 2.0f) signY = -1;

                    RectTransform panelToPosition = panel.GetComponent<RectTransform>();


                    panelToPosition.position = new Vector3(clickPosition.x + signX * (Screen.width * 35.0f / 100.0f), clickPosition.y + signY * (Screen.height * 15 / 100.0f), 0);

                    float limitPercent = 30.0f;

                    float lowPxLimit = (limitPercent / 100.0f) * Screen.width;
                    float highPxLimit = ((100.0f - limitPercent) / 100.0f) * Screen.width;

                    if (panelToPosition.position.x > highPxLimit) { 
                        panelToPosition.position = new Vector3(highPxLimit, panelToPosition.position.y, panelToPosition.position.z);
                    } else if (panelToPosition.position.x < lowPxLimit)
                    {
                        panelToPosition.position = new Vector3(lowPxLimit, panelToPosition.position.y, panelToPosition.position.z);
                    }


                    spherePointer.transform.position = hit.point;
                    spherePointer.transform.SetParent(hit.transform);
                    Vector2 startpointPosition = new Vector2(panelToPosition.position.x - signX * panelToPosition.sizeDelta.x/2.0f, panelToPosition.position.y);
                    theLineDrawer.setObjectToPointAt(spherePointer, startpointPosition);
                    panel.SetActive(true);
                    lastClickedPartname = hit.transform.name;
                    panelTitle.text = lastClickedPartname;
                    panelDescription.text = dataBase.getText(lastClickedPartname);
                    scrollBar.value = 1;

                }
                else
                {
                    theLineDrawer.setObjectToPointAt(null, panel.GetComponent<RectTransform>().position);
                    panel.SetActive(false);
                    spherePointer.SetActive(false);

                }
            }
        }

    }

    bool mouseIsMoving()
    {
        float moveX = Input.GetAxis("Mouse X");
        float moveY = Input.GetAxis("Mouse Y");

        return moveX > 0 || moveX < 0 || moveY > 0 || moveY < 0;
    }
}
