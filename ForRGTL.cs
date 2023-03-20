using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForRGTL : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;

    public GameObject projectilePrefab; // Префаб снаряду
    public float projectileSpeed = 10f; // Швидкість снаряду
    public float projectileSpawnDistance = 1f; // Відстань від персонажа до спавну снаряду

    private void Start()
    {

        losePanel.SetActive(false);
    }


    // Функція для спавну ульти 
    void SpawnProjectile(Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(direction.x, direction.y, 0) * projectileSpawnDistance, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction * projectileSpeed;
    }


    public void Ulta() //Назначити на вашу кнопку
    {
        SpawnProjectile(Vector2.up);
        SpawnProjectile(Vector2.down);
        SpawnProjectile(Vector2.left);
        SpawnProjectile(Vector2.right);
        SpawnProjectile(new Vector2(1, 1).normalized);
        SpawnProjectile(new Vector2(-1, -1).normalized);
        SpawnProjectile(new Vector2(1, -1).normalized);
        SpawnProjectile(new Vector2(-1, 1).normalized);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;

        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("PlatformerDemo");
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
