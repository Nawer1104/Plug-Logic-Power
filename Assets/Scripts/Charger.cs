using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public Enum status;

    public GameObject vfxCharge;

    public GameObject vfxTouch;

    public GameObject vfxFail;

    Vector2 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Pin"))
        {
            if (status == Enum.FullyCharge) return;

            status = Enum.FullyCharge;

            GameObject vfx = Instantiate(vfxTouch, transform.position, Quaternion.identity) as GameObject;

            Destroy(vfx, 1f);

            collision.gameObject.SetActive(false);
        }

        if (collision != null && collision.gameObject.CompareTag("Phone"))
        {
            if (status != Enum.FullyCharge)
            {
                GameObject vfx = Instantiate(vfxFail, transform.position, Quaternion.identity) as GameObject;

                Destroy(vfx, 1f);

                transform.position = startPos;

                GetComponent<DragAndDrop>()._dragging = false;

                return;
            }
            else
            {
                GetComponent<DragAndDrop>()._dragging = false;
                GameObject vfx = Instantiate(vfxCharge, transform.position, Quaternion.identity) as GameObject;

                Destroy(vfx, 1f);

                gameObject.SetActive(false);

                collision.gameObject.GetComponent<Phone>().Reduce();
            }
        }
    }
}
