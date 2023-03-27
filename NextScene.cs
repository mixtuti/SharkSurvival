using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class NextScene : MonoBehaviour
{
    [Header("次のシーン")] public SceneReference next_scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            // var fishEye = new FishEyeTransition()
			// {
			// 	nextScene = SceneManager.GetSceneByName( next_scene ).buildIndex == 1 ? 2 : 0,
			// 	duration = 1.0f,
			// 	size = 0.08f,
			// 	zoom = 10.0f,
			// 	colorSeparation = 3.0f
			// };
			// TransitionKit.instance.transitionWithDelegate( fishEye );
            SceneManager.LoadScene(next_scene);
        }
    }
}
