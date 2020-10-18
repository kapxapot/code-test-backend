using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication
{
	static class Extensions
	{
		public static CompanyDataRequest ToRequest(this ISellerCompanyData companyData) =>
			new CompanyDataRequest
			{
				CompanyFounded = companyData.Founded,
				CompanyNumber = companyData.Number,
				CompanyName = companyData.Name,
				DirectorName = companyData.DirectorName
			};
	}
}
