using UnityEngine;


public class KillUnderDepth : MonoBehaviour {
    [SerializeField]
    private float _depth = -0.5f;



    void Update() {
        if ( transform.position.y < _depth ) {
            Destroy( gameObject );
        }
    }
}
