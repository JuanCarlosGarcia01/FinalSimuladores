using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController moveCharacterController;

    [Header("MovePlayer")]
    float moveHorizontal;
    float moveVertical;
    public float PlayerSpeed = 0.015f;

    [Header("Imán")]
    public GameObject PuntoDeAgarre;
    private GameObject ObjetoAgarrado = null;


    void Start()
    {
        moveCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 movePlayer = new Vector3(moveHorizontal, 0f, moveVertical) * PlayerSpeed;

        moveCharacterController.Move(movePlayer);

        if (ObjetoAgarrado != null)
        {
            if (Input.GetKey("t"))
            {
                ObjetoAgarrado.GetComponent<Rigidbody>().useGravity = true;
                ObjetoAgarrado.GetComponent<Rigidbody>().isKinematic = false;
                ObjetoAgarrado.gameObject.transform.SetParent(null);

                ObjetoAgarrado = null;

                PlayerSpeed = 0.015f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if (Input.GetKey("e") && ObjetoAgarrado == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = PuntoDeAgarre.transform.position;
                other.gameObject.transform.SetParent(PuntoDeAgarre.gameObject.transform);

                ObjetoAgarrado = other.gameObject;

                PlayerSpeed = 0.015f;
            }
        }

        if (other.gameObject.CompareTag("Pesado"))
        {
            if (Input.GetKey("e") && ObjetoAgarrado == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = PuntoDeAgarre.transform.position;
                other.gameObject.transform.SetParent(PuntoDeAgarre.gameObject.transform);

                ObjetoAgarrado = other.gameObject;

                PlayerSpeed = PlayerSpeed/2;
            }
        }
    }
}