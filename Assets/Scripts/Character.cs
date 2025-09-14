using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement Settings")]
    public float jumpForce = 8f;          // Сила прыжка
    public float jumpDistance = 2f;       // Дистанция прыжка
    public float jumpCooldown = 0.5f;     // Задержка между прыжками
    
    [Header("Physics Settings")]
    public LayerMask groundLayer;         // Слой земли для проверки
    public float groundCheckDistance = 0.1f; // Дистанция проверки земли
    
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private float lastJumpTime = 0f;
    private bool facingRight = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D не найден на объекте!");
        }
    }
    
    void Update()
    {
        CheckGrounded();
        HandleInput();
    }
    
    void CheckGrounded()
    {
        // Проверяем, стоит ли персонаж на земле
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 
                                           groundCheckDistance, groundLayer);
        isGrounded = true; //hit.collider != null;
    }
    
    void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // Проверяем, можно ли совершить прыжок
        if (horizontalInput != 0 && CanJump())
        {
            PerformJump(horizontalInput);
        }
        
        // Поворот персонажа в направлении движения
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }
    
    bool CanJump()
    {
        // Проверяем условия для прыжка: стоит на земле и прошел кд
        return isGrounded && Time.time - lastJumpTime >= jumpCooldown;
    }
    
    void  PerformJump(float direction)
    {
        // Рассчитываем вектор прыжка
        Vector2 jumpVector = new Vector2(direction * jumpDistance, jumpForce);
        
        // Применяем силу прыжка
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Сбрасываем горизонтальную скорость
        rb.AddForce(jumpVector, ForceMode2D.Impulse);
        
        lastJumpTime = Time.time;
    }
    
    void Flip()
    {
        // Поворачиваем персонажа
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    // Визуализация луча для отладки
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}