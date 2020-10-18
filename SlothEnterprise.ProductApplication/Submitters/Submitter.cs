using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Submitters.Interfaces;
using System;

namespace SlothEnterprise.ProductApplication.Submitters
{
	/// <summary>
	/// Abstract generic product submitter
	/// </summary>
	abstract class Submitter<T> : ISubmitter where T : IProduct
	{
		public int Submit(ISellerApplication application, IProduct product)
		{
			if (product is T actual)
			{
				return ActualSubmit(application, actual);
			}

			throw new InvalidOperationException();
		}

		protected abstract int ActualSubmit(ISellerApplication application, T product);
	}
}
