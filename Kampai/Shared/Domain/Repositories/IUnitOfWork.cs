﻿namespace Kampai.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}