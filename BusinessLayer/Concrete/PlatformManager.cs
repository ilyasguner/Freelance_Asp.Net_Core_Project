using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class PlatformManager : IPlatformService
	{
		IPlatformDal _platformDal;

		public PlatformManager(IPlatformDal platformDal)
		{
			_platformDal = platformDal;
		}

		public void TAdd(Platform t)
		{
			_platformDal.Add(t);
		}

		public void TDelete(Platform t)
		{
			_platformDal.Delete(t);
		}

		public Platform TGetById(int id)
		{
			return _platformDal.GetById(id);
		}

		public List<Platform> TGetList()
		{
			return _platformDal.GetList();
		}

		public void TUpdate(Platform t)
		{
			_platformDal.Update(t);
		}
	}
}
