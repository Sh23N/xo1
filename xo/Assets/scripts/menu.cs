
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour
{

  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnplayClick()
    {
        SceneManager.LoadScene("Game");
    } 
  
  
    
}
