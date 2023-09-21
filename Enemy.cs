using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerVelocity = 10;
    public PlayerAnimationController playerAnim;

    private bool isWalking = false;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            // O personagem está andando
            SetIsWalking(true);

            Vector3 movementDirection = new Vector3(horizontalInput, 0f, 0f);
            transform.position += movementDirection * (Time.deltaTime * playerVelocity);

            // Flip o personagem para a direção do movimento
            FlipCharacter(horizontalInput);
        }
        else
        {
            // O personagem não está andando
            SetIsWalking(false);
        }

        // Verifique a entrada de atirar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Tocar a animação de SHOOT
        playerAnim.PlayAnimation("SHOOT");
        Debug.Log("Shooting");
        // Adicione a lógica de atirar aqui, por exemplo, instanciar uma bala e configurar suas propriedades.
    }

    private void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }

        // Atualize a escala local dos filhos também
        foreach (Transform child in transform)
        {
            child.localScale = transform.localScale;
        }
    }

    private void SetIsWalking(bool value)
    {
        // Se a animação está sendo trocada
        if (value != isWalking)
        {
            if (value)
            {
                Debug.Log("Walking");
                playerAnim.PlayAnimation("WALK");
            }
            else
            {
                // A animação deve mudar para IDLE quando não estiver andando
                playerAnim.PlayAnimation("IDLE");
                Debug.Log("Idle");
            }
        }
        isWalking = value;
    }
}
