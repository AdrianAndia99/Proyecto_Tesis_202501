using UnityEngine;

public class ChangeScene: MonoBehaviour
{

    void Start()
    {
       
    }
    void Update()
    {
        
    }
    public void LoadScene(string nameScene)
    {
        SceneGlobalManager.Instance.LoadScene(nameScene);
    }
    public void LoadAsync(string nameScene) 
    { 
     SceneGlobalManager.Instance.LoadSceneAsync(nameScene);
    }
    
    public void Exit()
    {
        SceneGlobalManager.Instance.QuitGame();
    }
}
