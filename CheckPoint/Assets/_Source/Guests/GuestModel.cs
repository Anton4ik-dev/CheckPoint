using DataFactories;
using System;

namespace Guest
{
    public class GuestModel
    {
        public Action OnGuestEnter;

        private DataFactory _dataFactory;

        public GuestModel(DataFactory dataFactory)
        {
            _dataFactory = dataFactory;
            Bind();
        }

        private void Bind()
        {
            OnGuestEnter += CreateData;
        }

        private void CreateData()
        {
            _dataFactory.CreateData();
        }
    }
}