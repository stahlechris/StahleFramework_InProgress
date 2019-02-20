using UnityEngine;
namespace Stahle.Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float bulletSpeed;
        [SerializeField] float bulletTimeToLive;
        private const string METHOD = "PutBulletBackIntoObjectPool";

        private void OnEnable()
        {
            //Add a relative force to the rb on the Projectile to send it
            rb.AddRelativeForce(Vector3.up * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
            //after 2 sec, de activate bullet and put it back in the pool for reuse
            Invoke(METHOD, bulletTimeToLive);
        }
        private void PutBulletBackIntoObjectPool()
        {
            gameObject.SetActive(false);
        }
        private void OnDisable()
        {
            //...so it doesn't add onto its previous velocity
            rb.velocity = Vector3.zero;
            //... so it doesnt turn off right away
            CancelInvoke();
            //... so we can re-use the bullet
            PutBulletBackIntoObjectPool();
        }
    }
}