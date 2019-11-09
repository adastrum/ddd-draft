﻿using System.Threading;
using System.Threading.Tasks;

namespace Xxx.Domain.Common
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
