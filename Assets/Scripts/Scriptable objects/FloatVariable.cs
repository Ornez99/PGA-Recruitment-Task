using UnityEngine;

[CreateAssetMenu(fileName = "Float", menuName = "ScriptableObjects/Float variable", order = 1)]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float value;

    public float Value { get => value; set => this.value = value; }
}
