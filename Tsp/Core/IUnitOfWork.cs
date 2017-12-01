using System;
using System.Threading.Tasks;

namespace Tsp.Core
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}