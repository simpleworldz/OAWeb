using DAL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public class DBSession : IDBSession
    {
        MyContext Db = new MyContext();
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
