using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    IEnumerator cor;

    public GameObject[] cards;

    GameObject[] playerSlots;

    void Start()
    {
        playerSlots = GameObject.FindGameObjectsWithTag("PlayerSlot");
        SetStartCardsPosition();
        MoveCardsFromDeck();
    }

    //установить все карты на начальную точку (колода)
    void SetStartCardsPosition()
    {
        SetRandomArrayElements(cards);
        for (int i = 0; i < cards.Length; i++)
        {
            GameObject cardsInstance = Instantiate(cards[i], transform.position, Quaternion.identity);
            cardsInstance.transform.SetParent(transform, false);
        }
    }

    // рандомный порядок карт 
    void SetRandomArrayElements(GameObject[] cards)
    {
        for (int t = 0; t < cards.Length; t++)
        {
            GameObject tmp = cards[t];
            int r = Random.Range(t, cards.Length);
            cards[t] = cards[r];
            cards[r] = tmp;
        }
    }

    //реализация выдачи карт из колоды игроку
    void MoveCardsFromDeck()
    {
        GameObject ChildGameObject1 = transform.GetChild(cards.Length - 1).gameObject;
        ChildGameObject1.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Slot1Controller");
        cor = Break(ChildGameObject1, "Slot1", "Slot1Controller", playerSlots[0].transform);
        StartCoroutine(cor);

        GameObject ChildGameObject2 = transform.GetChild(cards.Length - 2).gameObject;

        ChildGameObject2.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Slot2Controller");
        cor = Break(ChildGameObject2, "Slot2", "Slot2Controller", playerSlots[1].transform);
        StartCoroutine(cor);

        GameObject ChildGameObject3 = transform.GetChild(cards.Length - 3).gameObject;

        ChildGameObject3.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Slot3Controller");
        cor = Break(ChildGameObject3, "Slot3", "Slot3Controller", playerSlots[2].transform);
        StartCoroutine(cor);

        GameObject ChildGameObject4 = transform.GetChild(cards.Length - 4).gameObject;

        ChildGameObject4.AddComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Slot4Controller");
        cor = Break(ChildGameObject4, "Slot4", "Slot4Controller", playerSlots[3].transform);
        StartCoroutine(cor);
    }

    //ожидание завершения анимации выдачи карты
    IEnumerator Break(GameObject gm, string animatioName, string controllerName, Transform parentTransform)
    {
        gm.GetComponent<Animator>().Play(animatioName);
        int time = Resources.Load<RuntimeAnimatorController>(controllerName).animationClips.Length;

        yield return new WaitForSeconds(time);
        gm.transform.SetParent(parentTransform);
        Destroy(gm.GetComponent<Animator>());
    }
}
