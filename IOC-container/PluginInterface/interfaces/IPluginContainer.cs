namespace pluginInterface.interfaces
{
    public interface IPluginContainer
    {
        string ClassName { get; }
        string ID { get; }

        IContainer GetContainer();
    }
}
