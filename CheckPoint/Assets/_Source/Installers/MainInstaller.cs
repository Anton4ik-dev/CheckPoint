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
    [SerializeField] private SoundsSO _soundsSo;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private PassportTemplate _passportTemplate;
    [SerializeField] private PhotoTemplate _passportPhotoTemplate;
    [SerializeField] private PhotoTemplate _guestPhotoTemplate;
    [SerializeField] private PhotoHolderSO _photoHolderSo;
    [SerializeField] private TextMeshProUGUI _book;
    [SerializeField] private TextMeshProUGUI _clocks;
    [SerializeField] private TextMeshProUGUI _guestSexMessage;
    [SerializeField] private int _howMuchYears;

    [SerializeField] private TextAsset _names;
    [SerializeField] private TextAsset _surnames;
    [SerializeField] private TextAsset _countries;

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
        Container.Bind<SoundService>().AsSingle().NonLazy();

        Container.Bind<TextAsset>().WithId(BindId.NAMES_ID).FromInstance(_names);
        Container.Bind<TextAsset>().WithId(BindId.SURNAMES_ID).FromInstance(_surnames);
        Container.Bind<TextAsset>().WithId(BindId.COUNTRIES_ID).FromInstance(_countries);

        Container.Bind<TextMeshProUGUI>().WithId(BindId.PASSPORT_ID).FromInstance(_book);
        Container.Bind<TextMeshProUGUI>().WithId(BindId.GUEST_ID).FromInstance(_clocks);
        Container.Bind<TextMeshProUGUI>().WithId(BindId.SEX_ID).FromInstance(_guestSexMessage);

        Container.Bind<AudioSource>().FromInstance(_audioSource).AsSingle();
        Container.Bind<SoundsSO>().FromInstance(_soundsSo).AsSingle();

        Container.Bind<PhotoHolderSO>().FromInstance(_photoHolderSo).AsSingle();
        Container.Bind<PassportTemplate>().FromInstance(_passportTemplate).AsSingle();

        Container.Bind<PhotoTemplate>().WithId(BindId.PASSPORT_ID).FromInstance(_passportPhotoTemplate);
        Container.Bind<PhotoTemplate>().WithId(BindId.GUEST_ID).FromInstance(_guestPhotoTemplate);

        Container.Bind<int>().FromInstance(_howMuchYears).AsSingle();
    }
}

public static class BindId
{
    public const int GUEST_ID = 0;
    public const int PASSPORT_ID = 1;
    public const int SEX_ID = 2;
    public const int COUNTRIES_ID = 3;
    public const int NAMES_ID = 4;
    public const int SURNAMES_ID = 5;
}