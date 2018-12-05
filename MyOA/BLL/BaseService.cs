using DALFactory;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IDbSession GetCurrentDbSession
        {
            get { return DbSessionFactory.CreateDbSession(); }
        }
        public IBaseDal<T> CurrentDal { get; set; }
        //1.没有强制子类继承这个构造方法
        //2.构造方法执行时，要用GetCurrentDbSession获取currentDal
        //public BaseService(IBaseDal<T> currentDal)
        //{
        //    CurrentDal = currentDal;
        //}

        //因为子类要创建特定的Dal,但父类并无法知道是哪个Dal，用这种方式设置Dal。
        public abstract void SetCurrentDal();
        public BaseService()
        {
            SetCurrentDal();
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }
        public IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<s>(pageIdex, pageSize, out toalCount, whereLambda, orderbyLambda, isAsc);
        }
        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            //??? 直接就SaveChanges(),那么前面DbSession中一次性访问的实现，还有意义吗？？
            //另外集中起来一次性访问数据库，会出现 bug（想要改动了的数据，其实前面的改动并没有写入）吗？
            //《只是猜测》这种情况会发生么，感觉不会，ef应该会有种机制，可能是，改动的是缓存中的数据，而使用的也是，所以没写入也没关系。
            return this.GetCurrentDbSession.SaveChanges();
        }
        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return this.GetCurrentDbSession.SaveChanges();
        }
        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            this.GetCurrentDbSession.SaveChanges();
            return entity;
        }
    }
}
