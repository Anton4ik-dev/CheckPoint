using DataFactories;
using Guest;
using ScriptableObjects;
using Services;
using Templates;
using TMPro;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private PassportTemplate _passportTemplate;
    [SerializeField] private PhotoTemplate _passportPhotoTemplate;
    [SerializeField] private PhotoTemplate _guestPhotoTemplate;
    [SerializeField] private PhotoHolderSO _photoHolderSo;
    [SerializeField] private TextMeshProUGUI _book;
    [SerializeField] private TextMeshProUGUI _clocks;
    [SerializeField] private int _howMuchYears;

    public override void InstallBindings()
    {
        Container.Bind<DataFactory>().AsSingle().NonLazy();
        Container.Bind<DateFactory>().AsSingle().NonLazy();
        Container.Bind<NameFactory>().AsSingle().NonLazy();
        Container.Bind<CityFactory>().AsSingle().NonLazy();
        Container.Bind<PhotoFactory>().AsSingle().NonLazy();
        Container.Bind<GuestModel>().AsSingle().NonLazy();

        Container.Bind<SQLDataLoader>().AsSingle().NonLazy();
        Container.Bind<LayerService>().AsSingle().NonLazy();

        Container.Bind<TextMeshProUGUI>().WithId(BindId.PASSPORT_ID).FromInstance(_book);
        Container.Bind<TextMeshProUGUI>().WithId(BindId.GUEST_ID).FromInstance(_clocks);

        Container.Bind<PhotoHolderSO>().FromInstance(_photoHolderSo).AsSingle();
        Container.Bind<PassportTemplate>().FromInstance(_passportTemplate).AsSingle();
        Container.Bind<PhotoTemplate>().WithId(BindId.PASSPORT_ID).FromInstance(_passportPhotoTemplate);
        Container.Bind<PhotoTemplate>().WithId(BindId.GUEST_ID).FromInstance(_guestPhotoTemplate);

        Container.Bind<int>().FromInstance(_howMuchYears);
    }
}

public static class BindId
{
    public const int GUEST_ID = 0;
    public const int PASSPORT_ID = 1;
}