using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int m_lives;

    private GameManager gameManager;

    private Rigidbody2D m_rigidbody;
    private float m_speed;

    public AudioSource ShotAudioSource;

    public bool goRight;

    [SerializeField]
    private TargetType type;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        Invoke(nameof(activeRb), 0.5f);
        // Invoke(nameof(GetKilledByLifeSpan), Settings.TargetLifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_lives > 0)
        {
            Vector2 speed;
            if (goRight)
                speed = new Vector2(Settings.TargetSpeed, m_rigidbody.velocity.y);
            else
                speed = new Vector2(-Settings.TargetSpeed, m_rigidbody.velocity.y);

            m_rigidbody.velocity = speed;
        }

    }

    // Being shot at
    private void OnMouseDown()
    {
        ShotAudioSource.Play();
        StartEvent();

        m_lives -= 1;
        if(m_lives == 0)
        {
            GetKilled(byThePlayer: true);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void activeRb()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void StartEvent()
    {
        gameManager.startEvent(type);
    }

    private void GetKilledByLifeSpan()
    {
        GetKilled(false);
    }

    public void GetKilled(bool byThePlayer)
    {
        if (byThePlayer)
            Settings.Score += 1 * Settings.ScoreMultiplier;

        else
        {
            if(Settings.PlayerLife != 0)
            {
                if (type == TargetType.loseLife)
                    Debug.Log(' ');
                else
                    Settings.PlayerLife -= 1;
                m_lives = 0;
            }
        }
        m_rigidbody.velocity = Vector2.zero;
        DeathAnimation();

    }

    private void DeathAnimation()
    {
        Destroy(m_rigidbody);
        transform.DOMoveY(m_rigidbody.position.y - 0.1f, 0.5f).SetEase(Ease.InBack);
        transform.DOScale(0, 1f).onComplete = () => { Destroy(gameObject); };
    }
}
