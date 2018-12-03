using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDal<T> where T : class, new()
    {
        //待修改
        MyContext Db = new MyContext();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isAsc">true:升序 false:降序</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex,int pageSize, out int totalCount,Expression<Func<T,bool>> whereLambda,Expression<Func<T,s>> orderByLambda, bool isAsc)
        {
            IQueryable<T> temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                return temp.OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return temp.OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }

        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }
    }
}
