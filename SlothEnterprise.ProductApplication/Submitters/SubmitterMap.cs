using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Submitters.Interfaces;
using System;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.Submitters
{
	class SubmitterMap : ISubmitterMap
	{
		protected readonly Dictionary<Type, ISubmitter> _map;

		public SubmitterMap()
		{
			_map = new Dictionary<Type, ISubmitter>();
		}

		public void Register<T>(ISubmitter submitter) where T : IProduct
		{
			_map[typeof(T)] = submitter;
		}

		public ISubmitter GetSubmitter(Type type)
		{
			if (_map.TryGetValue(type, out var submitter))
			{
				return submitter;
			}

			throw new ArgumentOutOfRangeException($"No submitter for type {type} found.");
		}
	}
}
