using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject square;
    public GameObject rectangle;
    public GameObject cylinder;
    private Rigidbody rb;
    private int count;
    public float speed;
    public Text countText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();

        Instantiate(square, new Vector3(5.420f, .5f, 1.938f), Quaternion.identity);  
        Instantiate(square, new Vector3(-5.420f, .5f, -1.938f), Quaternion.identity);
        Instantiate(square, new Vector3(-3.076f, .5f, 5.372f), Quaternion.identity);
        Instantiate(square, new Vector3(3.076f, .5f, -5.372f), Quaternion.identity);

        Instantiate(cylinder, new Vector3(3.076f, .5f, 5.372f), Quaternion.identity);
        Instantiate(cylinder, new Vector3(-3.076f, .5f, -5.372f), Quaternion.identity);
        Instantiate(cylinder, new Vector3(-5.420f, .5f, 1.938f), Quaternion.identity);
        Instantiate(cylinder, new Vector3(5.420f, .5f, -1.938f), Quaternion.identity);

        Instantiate(rectangle, new Vector3(0, .5f, 6.7f), Quaternion.identity);
        Instantiate(rectangle, new Vector3(0, .5f,-6.7f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Square"))
        {
            other.gameObject.SetActive (false);
            count = count +1;
            SetCountText();
        }
        else if(other.gameObject.CompareTag("Rectangle"))
        {
            other.gameObject.SetActive (false);
            count = count +3;
            SetCountText();
        }
        else if(other.gameObject.CompareTag("Cylinder"))
        {
            other.gameObject.SetActive (false);
            count = count +2;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: "+ count.ToString();
        if(count == 18){
            winText.text = "You Win";
            Invoke("Restart", 2);
        }
    }
    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}