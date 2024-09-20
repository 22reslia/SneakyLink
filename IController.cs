using System.Windows.Input;
using SneakyLink;

public interface IController<T>
{
    void RegisterCommand(T input, ICommand command);
    void Update();
}