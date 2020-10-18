using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Tests.Mocks;
using System;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        [Fact]
        public void CompanyDataToRequestTest()
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
        public void BusinessLoansToRequestTest()
        {
            var loans = new BusinessLoans
            {
                Id = 1,
                InterestRatePerAnnum = 0.05m,
                LoanAmount = 10000
            };

            var request = loans.ToRequest();

            Assert.Equal(loans.InterestRatePerAnnum, request.InterestRatePerAnnum);
            Assert.Equal(loans.LoanAmount, request.LoanAmount);
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

            Assert.Equal(Constants.InvalidResult, result.ToInt());
        }

        [Fact]
        public void ToIntFailTest()
        {
            var result = new ApplicationResultMock
            {
                Success = false
            };

            Assert.Equal(Constants.InvalidResult, result.ToInt());
        }
    }
}
