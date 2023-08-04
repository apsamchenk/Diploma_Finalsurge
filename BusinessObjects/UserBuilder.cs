using Bogus;
using BusinessObjects.Models;
using Core.Configuration;

namespace BusinessObjects
{
    public class UserBuilder
    {
        static Faker Faker = new();

        public static UserModel GetStandartUser()
        {
            return new UserModel(AppConfiguration.Browser.FinalSurgeUserLogin, AppConfiguration.Browser.FinalSurgeUserPassword);
        }

        public static UserModel GetRandomUser()
        {
            return new UserModel(Faker.Internet.Email(), Faker.Internet.Password());
        }

        public static UserModel GetRandomPasswordUser()
        {
            return new UserModel(AppConfiguration.Browser.FinalSurgeUserLogin, Faker.Internet.Password());
        }
    }
}
