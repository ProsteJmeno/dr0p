using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
    public float sphereSize = 0.2f;
    public int spheresInRow = 5;

    public float explosionForce;
    public float explosionRadius;
    public float explosionUpward;

    public GameObject deathScreen;
    public GameObject[] HUD;
    public GameObject error;
    public GameObject reviveButton;

    float spheresPivotDistance;
    Vector3 spheresPivot;

    AudioSource sound;

    Animator animator;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("transitionIn").GetComponent<Animator>();

        sound = GetComponent<AudioSource>();

        spheresPivotDistance = sphereSize * spheresInRow / 2;
        spheresPivot = new Vector3(spheresPivotDistance, spheresPivotDistance, spheresPivotDistance);
        deathScreen.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacleCrash")
        {
            if (!PlayerPrefs.HasKey("highscore"))
            {
                PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                //submit highscore to leaderboard
                leaderboard.instance.SubmitScoreToLeaderboard(PlayerPrefs.GetInt("score"));
            }
            else
            {
                if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highscore"))
                {
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                    //submit score to leaderboard
                }
            }
            deathScreen.SetActive(true);
            if (TimeBody.hasBeenRevived)
            {
                reviveButton.SetActive(false);
            }
            foreach (GameObject obj in HUD)
            {
                obj.SetActive(false);
            }
            countdown.isRunning = true;
            TimeBody.gameRunning = false;
            explode();
        }

        
    }

    public void explode()
    {
        sound.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        for (int x = 0; x < spheresInRow; x++)
        {
            for (int y = 0; y < spheresInRow; y++)
            {
                for (int z = 0; z < spheresInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }       
    }

    private void OnLevelWasLoaded(int level)
    {
        TimeBody.hasBeenRevived = false;
        TimeBody.gameRunning = true;
        PlayerPrefs.DeleteKey("score");
    }

    public void createPiece(int x, int y, int z)
    {
        GameObject piece;

        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        piece.GetComponent<Renderer>().material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        piece.transform.position = transform.position + new Vector3(sphereSize * x, sphereSize * y, sphereSize * z) - spheresPivot;
        piece.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = sphereSize;        
    }

    private IEnumerator deadSequence()
    {
        animator.SetTrigger("playerDead");
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.DeleteKey("score");
        if (PlayerPrefs.HasKey("highscore"))
        {
            Debug.Log(PlayerPrefs.GetInt("highscore"));
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayAgain()
    {    
        deathScreen.SetActive(false);
        error.SetActive(false);
        StartCoroutine(deadSequence());
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
