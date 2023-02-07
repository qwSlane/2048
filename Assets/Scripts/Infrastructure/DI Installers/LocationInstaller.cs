using Entities;
using Infrastructure.Kernel;
using Infrastructure.Kernel.Field;
using Services;
using Services.Assets;
using UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.DI_Installers {

    public class LocationInstaller : MonoInstaller {

        [SerializeField] private GameObject inputService;
        [SerializeField] private GameObject HUD;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings() {
            BindInput();
            BindGameData();
            BindHUD();
            BindAssetProvider();
            BindFactory();
            BindCellMover();
        }
        

        private void BindCellMover() {
            Container
                .Bind<CellMover>()
                .AsSingle()
                .NonLazy();
        }

        private void BindHUD() {
            ScoreCounter counter = 
                Container.InstantiatePrefabForComponent<ScoreCounter>(HUD);
        }

        private void BindGameData() {
            Container
                .Bind<GameData>()
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