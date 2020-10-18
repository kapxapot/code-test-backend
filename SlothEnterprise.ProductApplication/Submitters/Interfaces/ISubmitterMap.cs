using System;

namespace SlothEnterprise.ProductApplication.Submitters.Interfaces
{
	interface ISubmitterMap
	{
		/// <summary>
		/// Returns a submitter or throws an exception if the submitter is not found
		/// </summary>
		ISubmitter GetSubmitter(Type type);
	}
}
