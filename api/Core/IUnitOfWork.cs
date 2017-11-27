using System;
using System.Threading.Tasks;

namespace api.Core
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}