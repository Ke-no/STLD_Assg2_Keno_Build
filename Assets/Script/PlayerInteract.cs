using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float distance = 5f;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private AudioSource audioSource;
    private PlayerUI playerUI;

    void Start()
    {
        playerUI = GetComponent<PlayerUI>();

        if (cam == null)
        {
            Debug.LogError("Missing Camera");
        }

        if (playerUI == null)
        {
            Debug.LogWarning("PlayerUI not found");
        }
    }

    void Update()
    {
        if(playerUI != null)
        playerUI.UpdateText("");

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, mask))
        {

            Interactable interactable = hit.collider.GetComponentInParent<Interactable>();

            if (interactable != null)
            {
                if (playerUI != null)
                playerUI.UpdateText(interactable.promptMessage);

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {

                    if (audioSource != null)
                    audioSource.Play();

                    interactable.BaseInteract();
                }
            }
        }
    }
}