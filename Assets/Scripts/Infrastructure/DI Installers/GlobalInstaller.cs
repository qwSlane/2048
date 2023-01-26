using Infrastructure.Kernel;
using Zenject;

namespace Infrastructure.DI_Installers {

    public class GlobalInstaller : MonoInstaller, ICoroutineRunner {

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings() {
            BindStateMachine();
        }

        private void BindStateMachine() {
            Container.Bind<GameStateMachine>()
                .AsSingle().WithArguments(new SceneLoader(this));
        }

    }

}