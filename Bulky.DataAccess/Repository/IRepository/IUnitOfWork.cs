﻿using System;
namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }

		void Save();
	}
}

