using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Tests.Mocks;
using System;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        [Fact]
        public void ToRequestTest()
        {
            var companyData = new SellerCompanyData
            {
                Founded = DateTime.Now,
                Number = 123,
                Name = "Apple",
                DirectorName = "Tim Cook"
            };

            var request = companyData.ToRequest();

            Assert.Equal(companyData.Founded, request.CompanyFounded);
            Assert.Equal(companyData.Number, request.CompanyNumber);
            Assert.Equal(companyData.Name, request.CompanyName);
            Assert.Equal(companyData.DirectorName, request.DirectorName);
        }

        [Fact]
        public void ToIntSuccessWithAppIdTest()
        {
            var appId = 1;

            var result = new ApplicationResultMock
            {
                Success = true,
                ApplicationId = appId
            };

            Assert.Equal(appId, result.ToInt());
        }

        [Fact]
        public void ToIntSuccessWithoutAppIdTest()
        {
            var result = new ApplicationResultMock
            {
                Success = true
            };

            Assert.Equal(-1, result.ToInt());
        }

        [Fact]
        public void ToIntFailTest()
        {
            var result = new ApplicationResultMock
            {
                Success = false
            };

            Assert.Equal(-1, result.ToInt());
        }
    }
}
