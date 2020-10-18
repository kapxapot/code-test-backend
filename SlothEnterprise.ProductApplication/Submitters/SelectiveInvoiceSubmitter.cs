using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Submitters
{
	class SelectiveInvoiceSubmitter : Submitter<SelectiveInvoiceDiscount>
	{
		private readonly ISelectInvoiceService _selectInvoiceService;

		public SelectiveInvoiceSubmitter(ISelectInvoiceService selectInvoiceService)
		{
			_selectInvoiceService = selectInvoiceService;
		}

		protected override int ActualSubmit(ISellerApplication application, SelectiveInvoiceDiscount product)
		{
			return _selectInvoiceService.SubmitApplicationFor(
				application.CompanyData.Number.ToString(),
				product.InvoiceAmount,
				product.AdvancePercentage);
		}
	}
}
