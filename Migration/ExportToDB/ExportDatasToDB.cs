using Data.Context;
using Data.Entities.Person;
using Data.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExportToDB
{
    public class ExportDatasToDB
    {
        private IFactory _factory;

        public bool Success { get; private set; }

        private void Init()
        {
            _factory = new Factory();            
            Success = false;
        }


        public void SetToDb(string gender)
        {
            
        }
    }
}
