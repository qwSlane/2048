using Infrastructure.Kernel;
using Zenject;

namespace Infrastructure.Foundation {

    public class SceneKernel : MonoInstaller, ICoroutineRunner {

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