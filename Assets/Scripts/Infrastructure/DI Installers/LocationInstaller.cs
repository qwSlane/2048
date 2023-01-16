using Entities;
using Services;
using Services.Assets;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace Infrastructure.DI_Installers {

    public class LocationInstaller : MonoInstaller {

        [SerializeField] private GameObject inputService;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings() {
            BindInput();
            BindAssetProvider();
            BindRandomService();
            BindFactory();
        }

        private void BindRandomService() {
            Container
                .Bind<Random>()
                .AsSingle();
        }

        private void BindFactory() {
            Container
                .Bind<GameFactory>()
                .AsSingle();
        }

        private void BindAssetProvider() {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindInput() {
            IInputService instance =
                Container.InstantiatePrefabForComponent<InputService>(inputService);

            Container
                .Bind<IInputService>()
                .FromInstance(instance)
                .AsSingle();
        }

    }

}