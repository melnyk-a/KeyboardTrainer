using KeyboardTrainer.Models;
using KeyboardTrainer.Models.KeyChars;
using KeyboardTrainer.Presenters;
using KeyboardTrainer.Views;
using Ninject;
using System;
using System.Windows;

namespace KeyboardTrainer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Lazy<IKernel> container;

        public App()
        {
            container = new Lazy<IKernel>(CreateContainer);
        }

        private IKernel CreateContainer()
        {
            var container = new StandardKernel();

            container.Bind<IPresenter>().To<KeyboardTrainerPresenter>().InSingletonScope();
            container.Bind<IKeyboardTrainerView>().To<MainWindow>().InSingletonScope();
            container.Bind<SpeedCalculator>().To<SpeedCalculator>().InSingletonScope();
            container.Bind<SourceString>().To<SourceString>().InSingletonScope();
            container.Bind<KeyCharsProvider>().To<KeyCharsProvider>().InSingletonScope();

            return container;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IPresenter presenter = container.Value.Get<IPresenter>(); ;
            presenter.Run();
        }
    }
}