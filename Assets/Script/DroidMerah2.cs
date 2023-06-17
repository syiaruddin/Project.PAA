using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidMerah2 : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform upPos;
    public Transform downPos;
    public Transform rightPos;
    public Transform leftPos;

    public RaycastHit2D hitinfoRight;
    public RaycastHit2D hitinfoLeft;
    public RaycastHit2D hitinfoUp;
    public RaycastHit2D hitinfoDown;

    public bool stopMove;
    public GameObject droidHijau;
    public GameObject[] hijau;
    public DroidHijau2[] stophijau;

    public float Movetime;
    public float movedelay;
    public float distanceLine = 1f;
    int RandomArah;

    void Start()
    {
        InvokeRepeating("moveRed", Movetime, movedelay);

        Physics2D.queriesStartInColliders = false;

        hijau = GameObject.FindGameObjectsWithTag("DroidHijau");
    }

    public void gerak()
    {
        InvokeRepeating("moveRed", Movetime, movedelay);
        Physics2D.queriesStartInColliders = false;

    }

    void Update()
    {

        hitinfoRight = Physics2D.Raycast(rightPos.position, transform.right, distanceLine);
        hitinfoLeft = Physics2D.Raycast(leftPos.position, leftPos.transform.right, distanceLine);
        hitinfoUp = Physics2D.Raycast(upPos.position, upPos.transform.right, distanceLine);
        hitinfoDown = Physics2D.Raycast(downPos.position, downPos.transform.right, distanceLine);

        stophijau = FindObjectsOfType<DroidHijau2>();

        foreach (GameObject green in hijau)
        {
            if (transform.position == green.transform.position)
            {
                CancelInvoke("moveRed");

                foreach (DroidHijau2 move in stophijau)
                {
                    move.CancelInvoke("moveGreen");
                }
            }
        }
    }

    private void moveRed()
    {
        if (stopMove)
        {
            RandomArah = Random.Range(1, 5);
            if (RandomArah == 1 && hitinfoUp.collider == null)
            {
                transform.Translate(0, 1, 0);
            }
            else if (RandomArah == 2 && hitinfoDown.collider == null)
            {
                transform.Translate(0, -1, 0);
            }
            else if (RandomArah == 3 && hitinfoRight.collider == null)
            {
                transform.Translate(1, 0, 0);
            }
            else if (RandomArah == 4 && hitinfoLeft.collider == null)
            {
                transform.Translate(-1, 0, 0);
            }
        }

        if (hitinfoUp.collider != null && hitinfoUp.collider.gameObject == droidHijau)
        {
            transform.Translate(0, 1, 0);
        }
        else if (hitinfoDown.collider != null && hitinfoDown.collider.gameObject == droidHijau)
        {
            transform.Translate(0, -1, 0);
        }
        else if (hitinfoRight.collider != null && hitinfoRight.collider.gameObject == droidHijau)
        {
            transform.Translate(1, 0, 0);
        }
        else if (hitinfoLeft.collider != null && hitinfoLeft.collider.gameObject == droidHijau)
        {
            transform.Translate(-1, 0, 0);
        }
    }

}
