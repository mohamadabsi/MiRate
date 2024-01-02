using System;

namespace Framework.Core.Ddd.VMs
{
    [Serializable]
    public abstract class EntityVM : IEntityVM //TODO: Consider to delete this class
    {
        public override string ToString()
        {
            return $"[DTO: {GetType().Name}]";
        }
    }

    [Serializable]
    public abstract class EntityVM<TKey> : EntityVM, IEntityVM<TKey>
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        public TKey Id { get; set; }

        public override string ToString()
        {
            return $"[DTO: {GetType().Name}] Id = {Id}";
        }
    }
}