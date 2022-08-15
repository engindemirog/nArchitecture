﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{ 
    public interface IBrandRepository: IAsyncRepository<Brand>, IRepository<Brand>
    {
    }
}
