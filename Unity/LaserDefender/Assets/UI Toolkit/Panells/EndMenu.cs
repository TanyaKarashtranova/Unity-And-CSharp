using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndMenu : MonoBehaviour
{
    private VisualElement root;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("PlayAgain").clicked += () => SceneManager.GetInstance().LoadGameScene();
        root.Q<Button>("MainMenu").clicked += () => SceneManager.GetInstance().LoadStartScene();
    }

    private void Start()
    {
        if (GameManager.GetInstance().IsBossDead())
        {
            root.Q<Label>("EndTitle").text = "Congratulations!\n You Win!";
            GameManager.GetInstance().SetIsBossDead(false);
        }
        root.Q<Label>("Score").text = "Your Score: \n" + GameManager.GetInstance().GetScore().ToString();
    }
}
