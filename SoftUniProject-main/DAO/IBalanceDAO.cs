using ItKarieraProjectTest.Models;

namespace ItKarieraProjectTest.DAO
{
    public interface IBalanceDAO
    {
        PersonInfo GetBalance(decimal money);
    }
}
