using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KokkaDeath : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    [SerializeField] Text CurrentScore;
    int tempscore=0;
    [SerializeField] Text FinalScore;
    public GameObject player;
    public Vector3 pos;
    public void SetGameOver()
    {
        player.SetActive(false);
        GameOver.SetActive(true);
        CurrentScore.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (tempscore<pos.z)
        {
            pos.z=tempscore=(int)pos.z;
            CurrentScore.text=pos.z.ToString();
        }
        pos = player.transform.position;
        if (pos.y<-9)
        {
            SetGameOver();
            FinalScore.text = CurrentScore.text;
        }
    }
}
