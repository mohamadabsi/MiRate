namespace Framework.Core.Ddd.VMs
{
    public interface IEntityVM
    {

    }

    public interface IEntityVM<TKey> : IEntityVM
    {
        TKey Id { get; set; }
    }
}