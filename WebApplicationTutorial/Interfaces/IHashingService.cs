using Microsoft.AspNetCore.Mvc;
using WebApplicationTutorial.Models;

namespace WebApplicationTutorial.Interfaces
{
    public interface IHashingService
    {
        public string GetHash(Object o);

        public Boolean VerifyHash(string hashed,Object o);

    }
}
