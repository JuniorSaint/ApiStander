using System;
namespace Api.Domain.Exceptions
{
	public class DomainException : ApplicationException
	{
		public DomainException(string message) : base (message)
		{

		}
	}
}

