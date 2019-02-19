using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    private int count;
    public Text countText;
    public Camera first;
    public Camera third;
    private Rigidbody rb;
    int state;
    Animator anim;
    public GameObject bridge;
    public ParticleSystem ps;
    public Animator doorAnim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        state = 0;
        bridge.GetComponent<MeshRenderer>().enabled = false;
        bridge.GetComponent<MeshCollider>().enabled = false;
        
        //Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 5f, 0));


        float Hor = Input.GetAxis("Horizontal");
        float Ver = Input.GetAxis("Vertical");

        Vector3 Movement = (Hor * transform.right + Ver * transform.forward).normalized;
        if (Movement == Vector3.zero)
        {
            state = 0;
            anim.SetTrigger("Idle");
        }
        else if (state != 1)
        {
            state = 1;
            anim.SetTrigger("Walk");
        }
        else
        {

        }
        //transform.position += Movement * speed * Time.deltaTime;
        rb.AddForce(Movement * speed);

        if(count == 4)
        {
            bridge.GetComponent<MeshRenderer>().enabled = true;
            bridge.GetComponent<MeshCollider>().enabled = true;
            count = 0;
            SetText();
            doorAnim.SetTrigger("open");
        }


    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision with " + collision.gameObject.name);
        if(collision.gameObject.tag == "collectable")
        {
    
            //em.enabled = true;
            //em.SetBursts(
            //new ParticleSystem.Burst[]{
            //new ParticleSystem.Burst(0.0f, 25)});
            Debug.Log("collision with box");
            Destroy(collision.gameObject);
            count++;
            SetText();
            Instantiate(ps.gameObject, collision.transform.position, Quaternion.Euler(Vector3.left));
        }
    }

    void SetText()
    {
        countText.text = count.ToString() + "x Wood";
    }

    public void onToggle()
    {
        if (first.enabled == false)
        {
            first.enabled = true;
            third.enabled = false;
        }
        else
        {
            first.enabled = false;
            third.enabled = true;
        }

    }
}
