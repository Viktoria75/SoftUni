using ItKarieraProjectTest.Models;

namespace ItKarieraProjectTest.DAO
{
    public interface IProfileDAO
    {
        PersonInfo LogIn(string username, string password);
        void RegisterUser(PersonInfo loginInfo);
    }
}
