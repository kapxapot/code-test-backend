using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Submitters
{
	class BusinessLoansSubmitter : Submitter<BusinessLoans>
	{
		private readonly IBusinessLoansService _businessLoansService;

		public BusinessLoansSubmitter(IBusinessLoansService businessLoansService)
		{
			_businessLoansService = businessLoansService;
		}

		protected override int ActualSubmit(ISellerApplication application, BusinessLoans product)
		{
			var result = _businessLoansService.SubmitApplicationFor(
				application.CompanyData.ToRequest(),
				product.ToRequest());

			return result.ToInt();
		}
	}
}
