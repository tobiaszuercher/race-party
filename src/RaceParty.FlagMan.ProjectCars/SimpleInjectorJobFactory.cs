using FluentScheduler;

using SimpleInjector;

namespace RaceParty.FlagMan.ProjectCars
{
    public class SimpleInjectorJobFactory : IJobFactory
    {
        private readonly Container _container;

        public SimpleInjectorJobFactory(Container container)
        {
            _container = container;
        }

        /// <exception cref="ActivationException">Thrown when there are errors resolving the service instance.</exception>
        public IJob GetJobInstance<T>() where T : IJob
        {
            return _container.GetInstance(typeof(T)) as IJob;
        }
    }
}