using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CtrolObjectStore3D))]
public class MovementStore3D : MonoBehaviour
{
    [SerializeField] Vector3 directioMovementVector = Vector3.zero;
    [SerializeField] GameObject GOcameraInStore = null;
    [SerializeField] float movementPeriod = 0.2f;
    [SerializeField] float maxTimeToChangePosition = 1.3f;

    private bool m_ITerminatedAnimationMovement = true;
    private float m_timeToChangeAnimation = 0;
    private int m_actualPositionInArratGO = 0;
    private int m_maxCountGameObjects = 0;

    Vector3 pos = Vector3.zero;
    ItemInfo3D[] gameObjectInStore;

    private void Start()
    {
        CtrolObjectStore3D controlObjectStore3D = GetComponent<CtrolObjectStore3D>();
        m_maxCountGameObjects = controlObjectStore3D.GetMaxCountOfGameObjectsInStore();
        gameObjectInStore = new ItemInfo3D[controlObjectStore3D.GetMaxCountOfGameObjectsInStore()];
        gameObjectInStore = controlObjectStore3D.GetObjectsItems();

        print(gameObjectInStore[1].name);
    }

    public void StartAnimationWithButton(int actualDirection)
    {
        if (!m_ITerminatedAnimationMovement) return;
        if (actualDirection == -1)
        {
            if (m_actualPositionInArratGO > 0)
            {
                //pos = GOcameraInStore.transform.position - directioMovementVector;
                ChangePosAndCallACoroutine(-1);
            }
        }
        else if (actualDirection >= 1)
        {
            if (m_actualPositionInArratGO < m_maxCountGameObjects - 1)
            {
                ChangePosAndCallACoroutine(+1);
            }
        }
    }

    public int GetActualIndexPosition() {
        return m_actualPositionInArratGO;
    }

    private void ChangePosAndCallACoroutine(int directionIndex) {
        m_actualPositionInArratGO = m_actualPositionInArratGO + directionIndex;
        pos = new Vector3(gameObjectInStore[m_actualPositionInArratGO].transform.localPosition.x, GOcameraInStore.transform.localPosition.y, GOcameraInStore.transform.localPosition.z);
        StartCoroutine(StartAnimationTranformPosition());
    }

    IEnumerator StartAnimationTranformPosition( )
    {
        m_ITerminatedAnimationMovement = false;

        while (m_timeToChangeAnimation < maxTimeToChangePosition)
        {
            m_timeToChangeAnimation += Time.deltaTime / movementPeriod;
            GOcameraInStore.transform.localPosition = Vector3.Lerp(GOcameraInStore.transform.localPosition, pos, movementPeriod);

            yield return null;
        }
        //solution error in mobile, not set exactly position
        GOcameraInStore.transform.localPosition = pos;

        m_timeToChangeAnimation = 0;
        m_ITerminatedAnimationMovement = true;
    }
}
