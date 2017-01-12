using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlsScript : MonoBehaviour
{
    public RectTransform controllerTransform;
    public Image controller;
    public Sprite up, down, left, right, normal;
    public Animator wash;
    int activeHash = Animator.StringToHash("wash");
    public Vector3 offset;

    public bool moveUp, moveDown, moveLeft, moveRight, Wash;
    public float speedUp, speedDown, speedLeftRight;
    public int distance = 10;
    public Transform player;
    public SphereOverlapScript SphereScript;
    public ScoreScript scorescript;
    private bool washing = false;

    private float strainProgress;

    void Start()
    {
        moveUp = false;
        moveDown = false;
        moveRight = false;
        moveLeft = false;
    }

    void FixedUpdate()
    {
        if (moveUp == true)
        {
            controller.sprite = up;
            player.transform.position += Vector3.up * Time.deltaTime * speedUp;
        }

        if (moveDown == true)
        {
            controller.sprite = down;
            player.transform.position += Vector3.down * Time.deltaTime * speedDown;
        }

        if (moveLeft == true)
        {
            controller.sprite = left;
            player.transform.position += Vector3.left * Time.deltaTime * speedLeftRight;
        }

        if (moveRight == true)
        {
            controller.sprite = right;
            player.transform.position += Vector3.right * Time.deltaTime * speedLeftRight;
        }

        if (washing == true)
        {
            Color color = SphereScript.currentStain.GetComponent<SpriteRenderer>().material.color;
            color.a -= 0.05f;
            SphereScript.currentStain.GetComponent<SpriteRenderer>().material.color = color;

            if (SphereScript.currentStain.GetComponent<SpriteRenderer>().material.color.a < 0f)
            {
                scorescript.scoreCount += 1;
                Destroy(SphereScript.currentStain);
                washing = false;
            }
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            Vector2 center = controllerTransform.position + offset;

            Vector2 direction = touchPosition - center;

            float distance = direction.magnitude;

            float ang1 = Vector2.Angle(direction, Vector2.right);
            Vector3 cross = Vector3.Cross(direction, Vector2.right);

            if (cross.z > 0)
            {
                ang1 = 360 - ang1;
            }

           // Debug.DrawLine(center, touchPosition);
           // Debug.Log(ang1);

            //UP

            if (distance <= 5)
            {

                if (ang1 >= 45f && ang1 <= 135f)
                {
                    moveUp = true;
                    moveRight = false;
                }

                else
                {
                    moveUp = false;
                }

                //DOWN
                if (ang1 >= 225f && ang1 <= 315f)
                {
                    moveDown = true;
                    moveRight = false;
                }

                else
                {
                    moveDown = false;
                }

                //LEFT
                if (ang1 >= 135f && ang1 <= 225f)
                {
                    moveLeft = true;
                    moveRight = false;
                }

                else
                {
                    moveLeft = false;
                }

                //RIGHT
                if (ang1 >= 0 && ang1 <= 45f)
                {
                    moveRight = true;
                }

                //RIGHT
                if (ang1 >= 315f && ang1 <= 360)
                {
                    moveRight = true;
                }
            }

            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Ended)
                {
                    ang1 = 500;
                    AnyUp();
                    //Debug.Log("Stopping all movements.");
                }
            }

           
        }

    }
    public void AnyUp()
    {
        moveUp = false;
        moveDown = false;
        moveLeft = false;
        moveRight = false;
        controller.sprite = normal;
    }

    public void WashOn ()
    {
        wash.SetBool(activeHash, true);

        if (SphereScript.onStain == true)
        {
            washing = true;
        }
    }

    public void WashOff ()
    {
        washing = false;
        wash.SetBool(activeHash, false);
    }

    

    

}
