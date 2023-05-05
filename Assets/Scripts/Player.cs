using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public UIManager uimanager;
    private Touch touch;
    [Range(20, 60)]
    public int speed;
    public int forwardSpeed;

    public GameObject LvlTxt;
    public GameObject ShopButton;
    public GameObject AdButton;
    public GameObject DragToMoveText;
    public GameObject Parmak;
    public GameObject RestartPanel;


    private void Update()
    {

        if (Variables.firsttouch == 1)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);//Ekrana dokunuldugunda top hareket etmeye başlar
            LvlTxt.SetActive(false);
            ShopButton.SetActive(false);
            AdButton.SetActive(false);
            DragToMoveText.SetActive(false);
            Parmak.SetActive(false);
        }



        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Variables.firsttouch = 1;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(touch.deltaPosition.x * speed * Time.deltaTime,  //touch.deltaPosition sadece dokunulan yerdeki pozisyonu
                transform.position.y,
                 touch.deltaPosition.y * speed * Time.deltaTime);

            }

            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }

        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            uimanager.StartCoroutine("WhiteEffect");
            gameObject.SetActive(false);
            RestartPanel.SetActive(true);

        }
    }
}
