using Common;
using DAL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    /// <summary>
    /// 工厂类（数据会话层），创建数据类的实例，业务层通过Dbsession调用相应的数据操作类实例，将数据层和业务层解耦
    /// </summary>
    public class DbSession : IDbSession
    {
        //DbContext Db = new MyContext();
        //DbContext Db = DbContextFactory.CreateDbContext();
        public DbContext Db
        {
            get { return DbContextFactory.CreateDbContext(); }
        }
        private IUserInfoDal _userInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get {
                if (_userInfoDal == null)
                {
                    //_userInfoDal = new UserInfoDal();
                    _userInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _userInfoDal;
            }
            set
            {
                _userInfoDal = value;
            }
        }

        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
