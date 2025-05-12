

using UnityEngine;

public class ParticleFactory : Factory
{
    private ObjectPool _pool;

    public ParticleFactory(ObjectPool pool)
    {
        _pool = pool;
    }
    
    public override IProduct GetProduct(Vector3 position)
    {
        var product = (IProduct)(_pool.Release(position));
        product.Initialize(position);
        return product;
    }
}