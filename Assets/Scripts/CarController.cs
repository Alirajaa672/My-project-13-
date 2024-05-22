using Photon.Pun;
using UnityEngine;

public class CarController : MonoBehaviourPunCallbacks, IPunObservable
{
    public float speed = 5f; // Define a speed variable
    public float turnSpeed = 200f; // Define a turnSpeed variable

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            float moveInput = Input.GetAxis("Vertical");
            float steerInput = Input.GetAxis("Horizontal");

            rb.velocity = transform.up * moveInput * speed;
            rb.angularVelocity = steerInput * turnSpeed; // Use the 'turnSpeed' variable here
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rb.position);
            stream.SendNext(rb.rotation);
            stream.SendNext(rb.velocity);
            stream.SendNext(rb.angularVelocity);
        }
        else
        {
            rb.position = (Vector2)stream.ReceiveNext();
            rb.rotation = (float)stream.ReceiveNext();
            rb.velocity = (Vector2)stream.ReceiveNext();
            rb.angularVelocity = (float)stream.ReceiveNext();
        }
    }
}
