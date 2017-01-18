using UnityEngine;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    public GameObject[] Boss;

    private SpriteRenderer spriteRen;
    private RuntimeAnimatorController animcontroller;
    private int i = 0;

    // Use this for initialization
    private void Start()
    {
        i = Random.Range(0, Boss.Length);
        spriteRen = Boss[i].GetComponent<SpriteRenderer>();
        animcontroller = Boss[i].GetComponent<Animator>().runtimeAnimatorController;

        gameObject.GetComponent<SpriteRenderer>().sprite = spriteRen.sprite;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = animcontroller;
        gameObject.GetComponent<Animator>().Stop();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}