using Ninject;

namespace TodoApp.MVVM
{
    public interface INinjectConfiguration
    {
        IKernel Configure();
    }
}