using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T:class
	{
		//CRUD işlemleri için DataAccess katmanından 
		void Add(T t);

		void Delete(T t);

		void Update(T t);

		List<T> GetList();

		T GetById(int id);
	}
}
