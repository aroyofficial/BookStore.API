using Shuru.API.Enumerations;
using Shuru.API.Models;

namespace Shuru.API.Tests.TestData
{
    public static class UserRepositoryTestData
    {
        public static IEnumerable<object[]> GetAsyncReturnsObjectDataSet()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new User()
                    {
                        UserName = "aroy02072000",
                        Password = "ArijitRoy007!"
                    },
                    UserPurpose.Login,
                    new User()
                    {
                        Id = 1,
                        RowId = Guid.NewGuid(),
                        UserName = "aroy02072000",
                        Email = "aroy02072000@gmail.com",
                        Password = "trhGWnIozmdJFGlFJ9A8OyVAC5wMmSI6/+2e2EeZoPk=",
                        CreatedAt = DateTime.UtcNow
                    }
                }
            };
        }

        public static IEnumerable<object[]> GetAsyncReturnsNullDataSet()
        {
            return new List<object[]>()
            {
                new object[]
                {
                    new User()
                    {
                        UserName = "ankitadas",
                        Password = "AnkitaDas007!"
                    },
                    UserPurpose.Registration,
                    null
                }
            };
        }
    }
}
