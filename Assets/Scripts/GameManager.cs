using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Arkanoid
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _blocks;
        [SerializeField]
        private Rigidbody _ball;
        [SerializeField]
        private Rigidbody _playerOne;
        [SerializeField]
        private Rigidbody _playerTwo;
        private Vector2 _playerOneVelocity;
        private Vector2 _playerTwoVelocity;

        private void FixedUpdate()
        {
            _playerOne.velocity = _playerOneVelocity * 6f;
            _playerTwo.velocity = _playerTwoVelocity * 6f;

            if (_playerOneVelocity.magnitude > 0.01)
                _playerOneVelocity = _playerOneVelocity * 0.9f;
            else
                _playerOneVelocity = Vector2.zero;

            if (_playerTwoVelocity.magnitude > 0.01)
                _playerTwoVelocity = _playerTwoVelocity * 0.9f;
            else
                _playerTwoVelocity = Vector2.zero;
        }

        public void Loose()
        {
            Debug.LogWarning("LOSE");
            _ball.velocity = Vector3.zero;
        }

        public void CheckWin()
        {
            if (_blocks.Where(block => block.activeInHierarchy).Count() <= 0)
                Debug.LogWarning("WIN!");
        }

        public void OnMovePlayer1(InputAction.CallbackContext value)
        {
            Debug.Log("MOVE");
            _playerOneVelocity += value.ReadValue<Vector2>();
        }

        public void OnMovePlayer2(InputAction.CallbackContext value)
        {
            var vector = value.ReadValue<Vector2>();
            _playerTwoVelocity += new Vector2(-vector.x, vector.y);
        }
    }
}
