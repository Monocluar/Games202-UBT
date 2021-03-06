// Copyright Epic Games, Inc. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tools.DotNETCommon
{
	/// <summary>
	/// Attribute to indicate the name of a command line argument
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class CommandLineAttribute : Attribute
	{
		/// <summary>
		/// Prefix for the option, with a leading '-' and trailing '=' character if a value is expected.
		/// </summary>
		public string Prefix;

		/// <summary>
		/// Specifies a fixed value for this argument. Specifying an alternate value is not permitted.
		/// </summary>
		public string Value = null;

		/// <summary>
		/// Whether this argument is required
		/// </summary>
		public bool Required;

		/// <summary>
		/// For collection types, specifies the separator character between multiple arguments
		/// </summary>
		public char ListSeparator = '\0';

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Prefix">Prefix for this argument</param>
		public CommandLineAttribute(string Prefix = null)
		{
			this.Prefix = Prefix;

			if(Prefix != null)
			{
				if(!Prefix.StartsWith("-"))
				{
					throw new Exception("Command-line arguments must begin with a '-' character");
				}
			}
		}
	}
}
