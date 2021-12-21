using UnityEngine;
using Animancer.FSM;

public abstract class CharacterState : StateBehaviour
{
    [SerializeField] private Character character;
    public Character Character { get => character; }
}
