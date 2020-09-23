using Repository.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IBaseRepository
    {
        IUnitOfWork UnitOfWork { get; set; }
    }
}
