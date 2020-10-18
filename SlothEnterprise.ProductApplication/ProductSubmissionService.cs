using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Submitters.Interfaces;
using System;

namespace SlothEnterprise.ProductApplication
{
	class ProductSubmissionService
	{
		private readonly ISubmitterMap _map;

		public ProductSubmissionService(ISubmitterMap map)
		{
			_map = map;
		}

		public int SubmitApplicationFor(ISellerApplication application)
		{
			var product = application.Product;

			try
			{
				var submitter = _map.GetSubmitter(product.GetType());

				return submitter.Submit(application, product);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				throw new InvalidOperationException(ex.Message, ex);
			}
		}
	}
}
