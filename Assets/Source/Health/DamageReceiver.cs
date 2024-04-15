using System.Collections;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private float _flashTime;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _originalColor = Color.white;

    private void OnEnable()
    {
        if (!_spriteRenderer)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        _spriteRenderer.color = _originalColor;
    }

    public void DamageEffect()
    {
        if (_spriteRenderer && _spriteRenderer.gameObject.activeInHierarchy)
        {
            StartCoroutine(FlashColor(_flashTime));
        }
    }

    private IEnumerator FlashColor(float flashTime)
    {
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(flashTime);
        _spriteRenderer.color = _originalColor;
    }
}
