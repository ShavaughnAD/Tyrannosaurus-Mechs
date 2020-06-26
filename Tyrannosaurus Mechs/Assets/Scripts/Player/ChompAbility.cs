using UnityEngine;

public class ChompAbility : MonoBehaviour
{
    public float damage;
    public float actualDamage;
    public Animator chompAnim;

    public AudioSource auSource;
    public AudioClip CrunchAbility;

    #region Initialzation Protocals

    void Start()
    {
        actualDamage = damage;
    }

    void OnEnable()
    {
        actualDamage = damage;
    }

    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            auSource.PlayOneShot(CrunchAbility);
            actualDamage++;
            chompAnim.SetBool("Crunch", true);
            collision.GetComponent<Health>().TakeDamage(actualDamage);
        }
    }

    public void StopCrunch()
    {
        actualDamage = damage;
        chompAnim.SetBool("Crunch", false);
    }
}
