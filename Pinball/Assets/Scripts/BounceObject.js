#pragma strict

float explosionStrength = 100f;

function OnCollisionEnter (_other : Collision)
{
    _other.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
}