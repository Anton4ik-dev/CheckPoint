using DataFactories;
using System;
using Random = UnityEngine.Random;

namespace Guest
{
    public class GuestModel
    {
        public Action OnGuestEnter;
        public Func<bool, bool> OnGuestExit;

        private DataFactory _dataFactory;
        private int _repeatingRight = 0;
        private int _repeatingFake = 0;
        private bool _isFake;

        public GuestModel(DataFactory dataFactory)
        {
            _dataFactory = dataFactory;
            Bind();
        }

        private void Bind()
        {
            OnGuestEnter += CreateData;
            OnGuestExit += CheckExit;
        }

        private void CreateData()
        {
            if (Random.Range(0, 2) == 0)
                CreateRight();
            else
                CreateFake();
        }

        private bool CheckExit(bool playerResult)
        {
            return playerResult == !_isFake;
        }

        private void CreateRight()
        {
            if (_repeatingRight < 3)
            {
                _repeatingRight++;
                _isFake = false;
                _dataFactory.CreateData(_isFake);
                _repeatingFake = 0;
            }
            else
                CreateFake();
        }

        private void CreateFake()
        {
            if (_repeatingFake < 3)
            {
                _repeatingFake++;
                _isFake = true;
                _dataFactory.CreateData(_isFake);
                _repeatingRight = 0;
            }
            else
                CreateRight();
        }
    }
}