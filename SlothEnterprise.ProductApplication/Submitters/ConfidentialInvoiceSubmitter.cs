using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Submitters
{
	class ConfidentialInvoiceSubmitter : Submitter<ConfidentialInvoiceDiscount>
	{
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;

        public ConfidentialInvoiceSubmitter(IConfidentialInvoiceService confidentialInvoiceWebService)
        {
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
        }

        protected override int ActualSubmit(ISellerApplication application, ConfidentialInvoiceDiscount product)
		{
            var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                application.CompanyData.ToRequest(),
                product.TotalLedgerNetworth,
                product.AdvancePercentage,
                product.VatRate);

            return result.ToInt();
        }
    }
}
