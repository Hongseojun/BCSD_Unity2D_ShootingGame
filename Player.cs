using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public float speed;
    public float power;
    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletObjA;
    public GameObject bulletObjB;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Fire();
        Reload();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)h);
        }
    }

    void Fire()
    {
        if(!Input.GetButton("Fire3"))
        {
            return;
        }

        if(curShotDelay < maxShotDelay)
        {
            return;
        }

        switch (power)
        {
            case 1:
                GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 2:
                GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.1f, transform.rotation);
                GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.1f, transform.rotation);
                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                rigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 3:
                GameObject bulletRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletCC = Instantiate(bulletObjA, transform.position, transform.rotation);
                GameObject bulletLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.25f, transform.rotation);
                Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                rigidRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 4:
                GameObject bulletRRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.4f, transform.rotation);
                GameObject bulletCCC1 = Instantiate(bulletObjA, transform.position + Vector3.right * 0.125f, transform.rotation);
                GameObject bulletCCC2= Instantiate(bulletObjA, transform.position + Vector3.left * 0.125f, transform.rotation);
                GameObject bulletLLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.4f, transform.rotation);
                Rigidbody2D rigidRRR = bulletRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCC1 = bulletCCC1.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCCC2 = bulletCCC2.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidLLL = bulletLLL.GetComponent<Rigidbody2D>();
                rigidRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCC1.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCCC2.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 5:
                GameObject bulletB = Instantiate(bulletObjB, transform.position, transform.rotation);
                Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
                rigidB.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 6:
                GameObject bulletBR = Instantiate(bulletObjB, transform.position + Vector3.right * 0.2f, transform.rotation);
                GameObject bulletBL = Instantiate(bulletObjB, transform.position + Vector3.left * 0.2f, transform.rotation);
                Rigidbody2D rigidBR = bulletBR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidBL = bulletBL.GetComponent<Rigidbody2D>();
                rigidBR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidBL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 7:
                GameObject bulletBRR = Instantiate(bulletObjB, transform.position + Vector3.right * 0.35f, transform.rotation);
                GameObject bulletBCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                GameObject bulletBLL = Instantiate(bulletObjB, transform.position + Vector3.left * 0.35f, transform.rotation);
                Rigidbody2D rigidBRR = bulletBRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidBCC = bulletBCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidBLL = bulletBLL.GetComponent<Rigidbody2D>();
                rigidBRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidBCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidBLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;

            case 8:
                GameObject bulletBRRR = Instantiate(bulletObjB, transform.position + Vector3.right * 0.5f, transform.rotation);
                GameObject bulletBCCC1 = Instantiate(bulletObjB, transform.position + Vector3.right * 0.15f, transform.rotation);
                GameObject bulletBCCC2 = Instantiate(bulletObjB, transform.position + Vector3.left * 0.15f, transform.rotation);
                GameObject bulletBLLL = Instantiate(bulletObjB, transform.position + Vector3.left * 0.5f, transform.rotation);
                Rigidbody2D rigidBRRR = bulletBRRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidBCCC1 = bulletBCCC1.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidBCCC2 = bulletBCCC2.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidBLLL = bulletBLLL.GetComponent<Rigidbody2D>();
                rigidBRRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidBCCC1.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidBCCC2.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidBLLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
        }

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D collosion)
    {
        if (collosion.gameObject.tag == "Border")
        {
            switch (collosion.gameObject.name)
            {
                case "Top":
                    isTouchTop = true; 
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collosion)
    {
        if (collosion.gameObject.tag == "Border")
        {
            switch (collosion.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }
}
