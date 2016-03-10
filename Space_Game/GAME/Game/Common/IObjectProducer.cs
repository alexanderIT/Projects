namespace Game.Common
{
    using System.Collections.Generic;

    public interface IObjectProducer
    {
        IEnumerable<GameObject> ProduceObjects();
    }
}
