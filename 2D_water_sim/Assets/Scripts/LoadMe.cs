using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadMe : MonoBehaviour {
    [SerializeField]
    private KeyCode _key = KeyCode.Space;


    private int _sceneIndex = 0;
    private bool _isLoading = false;



    private void Awake() {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    private void Update() {
        if ( Input.GetKeyDown( _key ) && !_isLoading ) {
            _isLoading = true;
            SceneManager.LoadSceneAsync(_sceneIndex);
        }
    }
}
