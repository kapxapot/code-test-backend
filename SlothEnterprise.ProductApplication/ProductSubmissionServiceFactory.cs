using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Submitters;

namespace SlothEnterprise.ProductApplication
{
	class ProductSubmissionServiceFactory
	{
        private readonly ISelectInvoiceService _selectInvoiceService;
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;
        private readonly IBusinessLoansService _businessLoansService;

        public ProductSubmissionServiceFactory(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _selectInvoiceService = selectInvoiceService;
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
            _businessLoansService = businessLoansService;
        }

        public ProductSubmissionService Make()
		{
			var map = new SubmitterMap();

            map.Register<SelectiveInvoiceDiscount>(
                new SelectiveInvoiceSubmitter(_selectInvoiceService));

            map.Register<ConfidentialInvoiceDiscount>(
                new ConfidentialInvoiceSubmitter(_confidentialInvoiceWebService));

            map.Register<BusinessLoans>(
                new BusinessLoansSubmitter(_businessLoansService));

            return new ProductSubmissionService(map);
        }
    }
}
