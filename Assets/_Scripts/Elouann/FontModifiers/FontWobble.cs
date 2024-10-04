using UnityEngine;
using TMPro;

// Made by Madalaski (https://github.com/Madalaski/TextTutorial/blob/master/Assets/CharacterWobble.cs)
public class CharacterWobble : MonoBehaviour
{
    private TMP_Text _textMesh;
    private Mesh _mesh;
    private Vector3[] _vertices;

    [SerializeField] private float _xMagnitude;
    [SerializeField] private float _yMagnitude;

    void Start()
    {
        _textMesh = GetComponent<TMP_Text>();
    }

    // Le but est de mettre � jour les vertices qui composent chaque caract�re � chaque frame
    void Update()
    {
        _textMesh.ForceMeshUpdate();
        _mesh = _textMesh.mesh;
        _vertices = _mesh.vertices;

        // Iterate over the TextMesh
        for (int i = 0; i < _textMesh.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = _textMesh.textInfo.characterInfo[i];

            int index = c.vertexIndex;

            Vector3 offset = Wobble(Time.time + i);
            _vertices[index] += offset;
            _vertices[index + 1] += offset;
            _vertices[index + 2] += offset;
            _vertices[index + 3] += offset;
        }

        _mesh.vertices = _vertices;
        _textMesh.canvasRenderer.SetMesh(_mesh);
    }

    private Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * _xMagnitude) * _xMagnitude, Mathf.Cos(time * _yMagnitude) * _yMagnitude);
    }
}