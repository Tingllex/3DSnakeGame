using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour
{
    private float MoveSpeed = 5;
    private float SteerSpeed = 180;
    private float BodySpeed = 5;
    private int Gap = 30;
    private bool Ate = false;

    private Vector3 Jump;
    private float JumpForce = 3.0f;
    private bool IsGrounded;
    Rigidbody Rb;

    private int Score = 0;
    public Text scoreText;

    public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        IsGrounded = true;
    }

    void Update()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        PositionsHistory.Insert(0, transform.position);

        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap + 20, 0, PositionsHistory.Count - 1)];

            // Move body
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body
            body.transform.LookAt(point);

            index++;
        }

        if (Ate)
        {
            GrowSnake();
            Ate = false;
            Score++;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Rb.AddForce(Jump * JumpForce, ForceMode.Impulse);
            IsGrounded = false;
        }

        scoreText.text = Score.ToString();
    }

    public void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.name.StartsWith("Food")) {
            Ate = true;
            Destroy(collision.gameObject);
        }
        if (collision.collider.name.StartsWith("Border"))
        {
            Debug.Log("Udalo sie uderzyc w BORDER");
            Application.Quit();
        }
        if (collision.collider.name == "Tail")
        {
            Debug.Log("Uderzono w ogon RIP RIP RIP");
            Application.Quit();
        }
        if (collision.collider.name.StartsWith("Anvil"))
        {
            Debug.Log("Zdechlo ci sie RIP RIP RIP RIP RIP RIP");
            Application.Quit();
        }
    }
}