using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication
{
	public static class Extensions
	{
		public static CompanyDataRequest ToRequest(this ISellerCompanyData companyData) =>
			new CompanyDataRequest
			{
				CompanyFounded = companyData.Founded,
				CompanyNumber = companyData.Number,
				CompanyName = companyData.Name,
				DirectorName = companyData.DirectorName
			};

		public static int ToInt(this IApplicationResult result) =>
			result.Success
				? result.ApplicationId ?? Constants.InvalidResult
				: Constants.InvalidResult;
	}
}
