using UnityEngine;


public class WotahSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject _prefab;

    [SerializeField, Range( 0, 100 )]
    private int _xAmount = 10, _yAmount = 1, _zAmount = 10;

    [SerializeField]
    private float _distance = 0.2f;

    [SerializeField]
    private float _secondLayerOffset = 0.1154700538379252f;

    [SerializeField]
    private bool _randomizePositions = false;

    private float _randomOffset = 0.04f;



    private void Start() {
        
        for ( int x = 0; x < _xAmount; ++x ) {
            for ( int y = 0; y < _yAmount; ++y ) {
                for ( int z = 0; z < _zAmount; ++z ) {
                    SpawnWotah(x, y, z);
                }
            }
        }
    }


    private void SpawnWotah( int x, int y, int z ) {
        Vector3 offset = ( _secondLayerOffset > Mathf.Epsilon && y % 2 == 1 ) ? new Vector3( _secondLayerOffset, 0, _secondLayerOffset ) : Vector3.zero;
        if ( _randomizePositions ) offset += new Vector3( Random.Range( -_randomOffset, _randomOffset ), Random.Range( -_randomOffset, _randomOffset ), Random.Range( -_randomOffset, _randomOffset ) );
        GameObject.Instantiate( _prefab, transform.position + new Vector3( x * _distance, y * _distance, z * _distance ) + offset, Quaternion.identity, transform );
    }
}
