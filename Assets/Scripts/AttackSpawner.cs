using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    [SerializeField] bool Loop;
    [SerializeField] float Delay;
    [SerializeField] List<Attack> Attacks;
    void Start()
    {
        StartCoroutine(nameof(SpawnAttacks));
    }

    IEnumerator SpawnAttacks(){
        yield return new WaitForSeconds(Delay);
        do {
            foreach(Attack currentAttack in Attacks){
                Instantiate(currentAttack.Object,currentAttack.transform.position,currentAttack.transform.rotation,transform);
                yield return new WaitForSeconds(currentAttack.Duration);
            }
        } while(Loop);
    }
}
