using UnityEngine;

public class BrickState : MonoBehaviour
{
    [SerializeField] private GameObject _normalModel;
    [SerializeField] private GameObject _brokenModel;
    [SerializeField] private _durabilityStates _durabilityState = _durabilityStates.Normal;

    private void Start()
    {
        SetState();
    }

    public void GetDamage()
    {
        _durabilityState++;
        SetState();
    }

    private void SetState()
    {
        switch (_durabilityState)
        {
            case _durabilityStates.Normal:
                ChangeActiveModel(_normalModel, _brokenModel);
                break;
            case _durabilityStates.Broken:
                ChangeActiveModel(_brokenModel, _normalModel);
                break;
            case _durabilityStates.Destroyed:
                DestroySelf();
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }

    private void ChangeActiveModel(GameObject activeModel, GameObject deactiveModel)
    {
        activeModel.SetActive(true);
        deactiveModel.SetActive(false);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private enum _durabilityStates
    {
        Normal,
        Broken,
        Destroyed
    }
}
