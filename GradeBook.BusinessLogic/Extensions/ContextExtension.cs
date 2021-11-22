﻿using GradeBook.BusinessLogic.Constants;
using GradeBook.BusinessLogic.Exceptions;
using GradeBook.DataAccess.Entities.Base.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Extensions
{
    public static class ContextExtension
    {
        public async static Task<T> GetEntityById<T>(this DbContext context, int id) where T: class, IEntityBase
        {
            var model = await context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);

            return model ?? throw new NotFoundException(Constants.Constants.ExceptionMessages.Global.NotFoundException);
        }
    }
}
