using UnityEngine;


public class SpawnOnKeyPress : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;



    private void Update() {
        if ( Input.GetKeyDown( KeyCode.Space ) ) {
            DestroyOld();
            Spawn();
        }
    }


    private void DestroyOld() {
        foreach ( Transform form in transform.GetComponentsInChildren<Transform>() ) {
            if ( form != transform ) {
                Destroy( form.gameObject );
            }
        }
    }


    private void Spawn() {
        GameObject.Instantiate(_prefab, transform);
    }
}
