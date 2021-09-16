using UnityEngine;

public class BrickRandomTexture : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjectsWithMaterial;
    [SerializeField] private Texture[] _normalTextures;
    [SerializeField] private Texture[] _brokenTextures;
    private MeshRenderer[] _materials = new MeshRenderer[2];

    private void Awake()
    {
        for (int receivedMaterial = 0; receivedMaterial < _gameObjectsWithMaterial.Length; receivedMaterial++)
        {
            _materials[receivedMaterial] = _gameObjectsWithMaterial[receivedMaterial].GetComponent<MeshRenderer>();
        }
    }

    private void Start()
    {
        SetRandomTexture();
    }

    private void SetRandomTexture()
    {
        int randomID = Random.Range(0, _normalTextures.Length);
        Texture _newNormalTexture = _normalTextures[randomID];
        Texture _newBrokenTexture = _brokenTextures[randomID];
        _materials[0].material.SetTexture("_MainTex", _newNormalTexture);
        _materials[1].material.SetTexture("_MainTex", _newBrokenTexture);
    }
}
