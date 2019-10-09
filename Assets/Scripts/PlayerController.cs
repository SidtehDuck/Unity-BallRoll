using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    public Text counterText;
    public float seconds, minutes;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        counterText = counterText.GetComponent<Text>() as Text;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = "Time: " + minutes.ToString("00") + " : " + seconds.ToString("00");

/*        if (count >= 8)
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;

            Time.fixedDeltaTime = 0.00f * Time.timeScale;
        }
*/
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You've Won!";
        }
    }
}