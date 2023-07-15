using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class retry : MonoBehaviour
{
    public TMP_Text winer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnRetryclick()
    {
        SceneManager.LoadScene("menu");
    }
}
