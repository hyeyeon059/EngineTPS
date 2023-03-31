using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxCracked : MonoBehaviour
{
    [SerializeField] GameObject crackedBox;
    private float moveSpeed = 3f;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            //Debug.Log(0);
            //crackedBox.transform.position = gameObject.transform.position;
            //Destroy(gameObject);
            //crackedBox.SetActive(true);

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 dir = new Vector3(h, 0, v);

            GameObject obj = Instantiate(crackedBox, transform.position, transform.rotation);
            //obj.GetComponentInChildren<Rigidbody>().ToList().
            //    ForEach(r => r.AddForce(dir.normalized * 10f + new Vector3(0, 2f, 0), ForceMode.Impulse));
            Destroy(gameObject);
        }
    }
}
