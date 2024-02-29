using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public List<Transform> teleportPoints;
    int lastTeleport = -1;

    float secondsToTeleport = 3f;
    float secondsToWaitAttack1 = 1.5f;
    float secondsToWaitAttack2 = 0.8f;

    HealthComponent enemyHealth;
    Transform player;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<HealthComponent>();
        player = FindObjectOfType<Player>().transform;
        StartCoroutine(nameof(Attack1));
    }

    void ChooseAttack()
    {
        int attack;
        if (lastTeleport == 4 || lastTeleport == 5)
        {
            attack = Random.Range(1, 4);
        } else
        {
            attack = Random.Range(1, 5);
        }

        switch (attack)
        {
            case 1:
            default:
                StartCoroutine(nameof(Attack1));
                break;
            case 2:
                StartCoroutine(nameof(Attack2));
                break;
            case 3:
                StartCoroutine(nameof(Attack4));
                break;
            case 4:
                StartCoroutine(nameof(Attack3));
                break;
        }
    }

    IEnumerator Teleport(int teleportLocation = -1)
    {
        yield return new WaitForSeconds(secondsToTeleport);
        if(teleportLocation != -1)
        {
            transform.position = teleportPoints[teleportLocation].position;
        } else
        {
            int teleportPosition = Random.Range(0, teleportPoints.Count);
            while (teleportPosition == lastTeleport)
            {
                teleportPosition = Random.Range(0, teleportPoints.Count);
            }
            Vector3 newPosition = teleportPoints[teleportPosition].position;
            lastTeleport = teleportPosition;
            transform.position = newPosition;
        }
        ChooseAttack();
    }

    IEnumerator Attack1()
    {
        List<GameObject> bullets = new();
        for (int i = 0; i < 4; i++)
        {
            bullets.Add(Instantiate(bullet, new Vector2(transform.position.x + (-1.5f + (i * 1f)), transform.position.y + 1f), Quaternion.identity));
        }
        yield return new WaitForSeconds(secondsToWaitAttack1);

        foreach (GameObject bullet in bullets)
        {
            VelocityComponent bulletVelocity = bullet.GetComponent<VelocityComponent>();
            bulletVelocity.Direction =  Vector3.Normalize(player.position - bullet.transform.position);
            bulletVelocity.Velocity = 20f;
            Destroy(bullet, 2f);
        }
        StartCoroutine(Teleport());
    }


    IEnumerator Attack2()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject bulletIns = (Instantiate(bullet, new Vector2(transform.position.x + (-1.5f + (i * 1f)), transform.position.y + 1f), Quaternion.identity));
            yield return new WaitForSeconds(secondsToWaitAttack2);
            VelocityComponent bulletVelocity = bulletIns.GetComponent<VelocityComponent>();
            bulletVelocity.Direction = Vector3.Normalize(player.position - bulletIns.transform.position);
            bulletVelocity.Velocity = 20f;
            Destroy(bulletIns, 2f);
        }
        StartCoroutine(Teleport());
    }

    IEnumerator Attack3()
    {
        List<GameObject> bullets = new();
        bullets.Add(Instantiate(bullet, new Vector2(transform.position.x -1.5f, transform.position.y + 1f), Quaternion.identity));
        bullets.Add(Instantiate(bullet, new Vector2(transform.position.x - 0.5f, transform.position.y + 1f), Quaternion.identity));
        bullets.Add(Instantiate(bullet, new Vector2(transform.position.x + .5f, transform.position.y + 3f), Quaternion.identity));
        bullets.Add(Instantiate(bullet, new Vector2(transform.position.x + 1.5f, transform.position.y + 3f), Quaternion.identity));
        yield return new WaitForSeconds(secondsToWaitAttack1);

        foreach (GameObject bullet in bullets)
        {
            VelocityComponent bulletVelocity = bullet.GetComponent<VelocityComponent>();
            bulletVelocity.Direction = Vector3.Normalize((player.position.x - bullet.transform.position.x) * Vector3.right);
            bulletVelocity.Velocity = 20f;
            Destroy(bullet, 2f);
        }
        StartCoroutine(Teleport());
    }


    IEnumerator Attack4()
    {
        int numOfBullets = Random.Range(3, 7);
        for (int i = 0; i < numOfBullets; i++)
        {
            GameObject bulletIns = (Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 3f), Quaternion.identity));
            yield return new WaitForSeconds(secondsToWaitAttack2);
            VelocityComponent bulletVelocity = bulletIns.GetComponent<VelocityComponent>();
            bulletVelocity.Direction = Vector3.Normalize(player.position - bulletIns.transform.position);
            bulletVelocity.Velocity = 20f;
            Destroy(bulletIns, 2f);
        }
        StartCoroutine(Teleport());
    }


}
