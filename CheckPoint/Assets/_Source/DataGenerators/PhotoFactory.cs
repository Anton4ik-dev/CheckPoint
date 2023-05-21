using System.Collections.Generic;
using Templates;
using UnityEngine;
using Zenject;

namespace DataFactories
{
    public class PhotoFactory
    {
        private const string MALE = "Мужской";
        private const string FEMALE = "Женский";
        private bool _sex;
        private PhotoTemplate _passportPhotoTemplate;
        private PhotoTemplate _guestPhotoTemplate;
        private List<Sprite> _faceSprites;
        private List<Sprite> _glassesSprites;
        private List<Sprite> _haircutSprites;
        private List<Sprite> _mouthSprites;
        private List<Sprite> _beardSprites;

        public PhotoFactory(
            [Inject(Id = BindId.PASSPORT_ID)] PhotoTemplate passportPhotoTemplate,
            [Inject(Id = BindId.GUEST_ID)] PhotoTemplate guestPhotoTemplate,
            [Inject(Id = BindId.FACE_ID)] List<Sprite> faceSprites,
            [Inject(Id = BindId.GLASSES_ID)] List<Sprite> glassesSprites,
            [Inject(Id = BindId.HAIRCUT_ID)] List<Sprite> haircutSprites,
            [Inject(Id = BindId.MOUTH_ID)] List<Sprite> mouthSprites,
            [Inject(Id = BindId.BEARD_ID)] List<Sprite> beardSprites)
        {
            _passportPhotoTemplate = passportPhotoTemplate;
            _guestPhotoTemplate = guestPhotoTemplate;
            _faceSprites = faceSprites;
            _glassesSprites = glassesSprites;
            _haircutSprites = haircutSprites;
            _mouthSprites = mouthSprites;
            _beardSprites = beardSprites;
        }

        public string CreateSex(bool isError = false)
        {
            if(isError)
                _sex = !_sex;
            else
            {
                if (Random.Range(0, 2) == 0)
                    _sex = true;
                else
                    _sex = false;
            }

            if (_sex)
                return MALE;
            else
                return FEMALE;
        }

        public void CreatePhoto(bool isError = false)
        {
            _guestPhotoTemplate.Face = CreateSprite(_faceSprites);
            _guestPhotoTemplate.Glasses = CreateSprite(_glassesSprites);
            _guestPhotoTemplate.Haircut = CreateSprite(_haircutSprites);
            _guestPhotoTemplate.Mouth = CreateSprite(_mouthSprites);
            _guestPhotoTemplate.Beard = CreateSprite(_beardSprites);
            _passportPhotoTemplate.Face = _guestPhotoTemplate.Face;
            _passportPhotoTemplate.Glasses = _guestPhotoTemplate.Glasses;
            _passportPhotoTemplate.Haircut = _guestPhotoTemplate.Haircut;
            _passportPhotoTemplate.Mouth = _guestPhotoTemplate.Mouth;
            _passportPhotoTemplate.Beard = _guestPhotoTemplate.Beard;
            if (isError)
            {
                switch (Random.Range(0, 5))
                {
                    case 0:
                        _passportPhotoTemplate.Face = CreateSprite(_faceSprites, _guestPhotoTemplate.Face, isError);
                        break;
                    case 1:
                        _passportPhotoTemplate.Glasses = CreateSprite(_glassesSprites, _guestPhotoTemplate.Glasses, isError);
                        break;
                    case 2:
                        _passportPhotoTemplate.Haircut = CreateSprite(_haircutSprites, _guestPhotoTemplate.Haircut, isError);
                        break;
                    case 3:
                        _passportPhotoTemplate.Mouth = CreateSprite(_mouthSprites, _guestPhotoTemplate.Mouth, isError);
                        break;
                    case 4:
                        _passportPhotoTemplate.Beard = CreateSprite(_beardSprites, _guestPhotoTemplate.Beard, isError);
                        break;
                }
            }
        }

        private Sprite CreateSprite(List<Sprite> sprites, Sprite changeSprite = null, bool isError = false)
        {
            if(isError)
            {
                Sprite errorSprite = sprites[Random.Range(0, sprites.Count)];
                while (errorSprite == changeSprite)
                    errorSprite = sprites[Random.Range(0, sprites.Count)];
                return errorSprite;
            }
            return sprites[Random.Range(0, sprites.Count)];
        }
    }
}