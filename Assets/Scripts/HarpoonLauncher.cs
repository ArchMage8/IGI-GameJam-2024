using UnityEngine;
using System.Collections;

public class HarpoonLauncher : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform player;
    public float harpoonSpeed = 5f;
    public float maxHarpoonLength = 10f;
    public float recastDelay = 2f;

    private Vector2 targetPosition;
    private bool isHarpoonActive = false;
    private bool isRetracting = false;
    private bool canCastHarpoon = true;
    private float currentLength = 0f;

    private GetMaterials getMaterials;
    private TopDownMovement topDownMovement;

    private void Start()
    {
        getMaterials = player.GetComponent<GetMaterials>();
        topDownMovement = player.GetComponent<TopDownMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canCastHarpoon)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LaunchHarpoon(mousePosition);
        }

        if (isHarpoonActive)
        {
            if (isRetracting)
            {
                RetractHarpoon();
            }
            else
            {
                ExtendHarpoon();
            }
            topDownMovement.enabled = false;
        }
        else
        {
            topDownMovement.enabled = true;
        }
    }

    void LaunchHarpoon(Vector2 target)
    {
        targetPosition = target;
        isHarpoonActive = true;
        isRetracting = false;
        currentLength = 0f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, player.position);
        lineRenderer.SetPosition(1, player.position);
        canCastHarpoon = false;
    }

    void ExtendHarpoon()
    {
        currentLength += harpoonSpeed * Time.deltaTime;
        Vector2 direction = (targetPosition - (Vector2)player.position).normalized;
        Vector2 currentPos = (Vector2)player.position + direction * currentLength;

        lineRenderer.SetPosition(1, currentPos);

        if (Vector2.Distance(player.position, currentPos) >= maxHarpoonLength ||
            Vector2.Distance(currentPos, targetPosition) < 0.1f)
        {
            StartRetracting();
        }

        RaycastHit2D[] hits = Physics2D.RaycastAll(player.position, direction, currentLength);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.CompareTag("Debris"))
            {
                Collect(hit.collider.gameObject);
                HideHarpoon();
                StartRetracting();
                StartCoroutine(ResetHarpoonAfterDelay());
                break;
            }
        }
    }

    void RetractHarpoon()
    {
        currentLength -= harpoonSpeed * Time.deltaTime;
        if (currentLength <= 0f)
        {
            isHarpoonActive = false;
            lineRenderer.positionCount = 0;
            canCastHarpoon = true;
            return;
        }

        Vector2 direction = (targetPosition - (Vector2)player.position).normalized;
        Vector2 currentPos = (Vector2)player.position + direction * currentLength;
        lineRenderer.SetPosition(1, currentPos);
    }

    void StartRetracting()
    {
        isRetracting = true;
    }

    void Collect(GameObject debris)
    {
        getMaterials.ProcessMaterials(debris);
    }

    IEnumerator ResetHarpoonAfterDelay()
    {
        yield return new WaitForSeconds(recastDelay);
        canCastHarpoon = true;
    }

    void HideHarpoon()
    {
        isHarpoonActive = false;
        lineRenderer.positionCount = 0;
    }
}
