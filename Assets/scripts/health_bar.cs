using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class health_bar : MonoBehaviour
{
    health playerHealth;

    public Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


            playerHealth   = gameObject.GetComponent<health>();
        bar.value = playerHealth.valueOfHealth;
        if (playerHealth.valueOfHealth <= 0)
        {
            SceneManager.LoadScene("Dead");
        }
    }
}
