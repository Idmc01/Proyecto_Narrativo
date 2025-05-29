using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animator;

    private List<string> collectedItems = new List<string>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    // Funci�n para marcar un objeto como recogido
    public void CollectItem(string itemName)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            GameManager.instance.AddCollectedItem(itemName);
            Debug.Log("�Objeto recogido! " + itemName);
            Dictionary<string, string> nombreObjetos = new Dictionary<string, string>
        {
            { "Object1", "pick" },
            { "Object2", "crowbar" },
            { "Object3", "scenechanger1" },
            { "Object4", "scenechanger2" }
        };
            if (itemName == "Crowbar")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("TalkingtoBigJustice");
            }
            if (itemName == "Scenechanger1")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Laberinto");
            }
            if (itemName == "Scenechanger2")
            {
                Debug.Log("Aqui se hace el cambio de escena");
                UnityEngine.SceneManagement.SceneManager.LoadScene("GolpesBJ");
            }


            // Obtener el nombre legible del objeto
            //string nombreObjetoLegible = nombreObjetos.ContainsKey(itemName) ? nombreObjetos[itemName] : itemName;


            //dialogo.dialogos = new string[] { "You got the " + nombreObjetoLegible + "!!" }; // Establecer el mensaje del di�logo
            //dialogo.gameObject.SetActive(true); // Activar el cuadro de di�logo
            //dialogo.iniciarDialogo(); // Iniciar el di�logo
            //PausarJuego();
        }
    }

    // Verificar si el jugador ya recogi� un objeto
    public bool HasCollectedItem(string itemName)
    {
        return collectedItems.Contains(itemName);
    }
}


