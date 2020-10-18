using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Submitters.Interfaces
{
	/// <summary>
	/// Product submitter interface
	/// </summary>
	interface ISubmitter
	{
		int Submit(ISellerApplication application, IProduct product);
	}
}
