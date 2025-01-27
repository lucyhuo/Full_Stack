﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    // base interface that all your repository interfaces will inherit 
    public interface IAsyncRepository<T> where T: class 
    {
        //CRUD

        // get by id 
        Task<T> GetById(int id);
        // get all
        Task<IEnumerable<T>> GetAll();
        // get data by condition 
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> predicate);

        //get count 
        Task<int> GetCount(Expression<Func<T, bool>> predicate);

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);


    }
}
