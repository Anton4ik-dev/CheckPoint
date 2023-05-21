using DataFactories;
using Guest;
using Services;
using System.Collections.Generic;
using Templates;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private PassportTemplate _passportTemplate;
    [SerializeField] private PhotoTemplate _passportPhotoTemplate;
    [SerializeField] private PhotoTemplate _guestPhotoTemplate;
    [SerializeField] private List<Sprite> _faceSprites;
    [SerializeField] private List<Sprite> _glassesSprites;
    [SerializeField] private List<Sprite> _haircutSprites;
    [SerializeField] private List<Sprite> _mouthSprites;
    [SerializeField] private List<Sprite> _beardSprites;
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

        Container.Bind<PassportTemplate>().FromInstance(_passportTemplate).AsSingle();
        Container.Bind<PhotoTemplate>().WithId(BindId.PASSPORT_ID).FromInstance(_passportPhotoTemplate);
        Container.Bind<PhotoTemplate>().WithId(BindId.GUEST_ID).FromInstance(_guestPhotoTemplate);

        Container.Bind<List<Sprite>>().WithId(BindId.FACE_ID).FromInstance(_faceSprites);
        Container.Bind<List<Sprite>>().WithId(BindId.GLASSES_ID).FromInstance(_glassesSprites);
        Container.Bind<List<Sprite>>().WithId(BindId.HAIRCUT_ID).FromInstance(_haircutSprites);
        Container.Bind<List<Sprite>>().WithId(BindId.MOUTH_ID).FromInstance(_mouthSprites);
        Container.Bind<List<Sprite>>().WithId(BindId.BEARD_ID).FromInstance(_beardSprites);
        Container.Bind<int>().FromInstance(_howMuchYears);
    }
}

public static class BindId
{
    public const int FACE_ID = 0;
    public const int GLASSES_ID = 1;
    public const int HAIRCUT_ID = 2;
    public const int MOUTH_ID = 3;
    public const int BEARD_ID = 4;
    public const int GUEST_ID = 5;
    public const int PASSPORT_ID = 6;
}