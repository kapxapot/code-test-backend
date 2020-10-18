using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using System;

namespace SlothEnterprise.ProductApplication
{
	public class ProductApplicationService
    {
        private readonly ISelectInvoiceService _selectInvoiceService;
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;
        private readonly IBusinessLoansService _businessLoansService;

        public ProductApplicationService(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _selectInvoiceService = selectInvoiceService;
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
            _businessLoansService = businessLoansService;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var product = application.Product;
            var companyData = application.CompanyData;

            if (product is SelectiveInvoiceDiscount sid)
            {
                return _selectInvoiceService.SubmitApplicationFor(
                    companyData.Number.ToString(),
                    sid.InvoiceAmount,
                    sid.AdvancePercentage);
            }

            if (product is ConfidentialInvoiceDiscount cid)
            {
                var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                    companyData.ToRequest(),
                    cid.TotalLedgerNetworth,
                    cid.AdvancePercentage,
                    cid.VatRate);

                return result.ToInt();
            }

            if (product is BusinessLoans loans)
            {
                var result = _businessLoansService.SubmitApplicationFor(
                    companyData.ToRequest(),
                    loans.ToRequest());

                return result.ToInt();
            }

            throw new InvalidOperationException();
        }
    }
}
