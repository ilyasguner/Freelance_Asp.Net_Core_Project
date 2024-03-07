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
	public class OfferManager : IGenericService<Offer>
	{
		IOfferDal _offerDal;

		public OfferManager(IOfferDal offerDal)
		{
			_offerDal = offerDal;
		}

		public void TAdd(Offer t)
		{
			_offerDal.Add(t);
		}

		public void TDelete(Offer t)
		{
			_offerDal.Delete(t);
		}

		public Offer TGetById(int id)
		{
			return _offerDal.GetById(id);
		}

		public List<Offer> TGetList()
		{
			return _offerDal.GetList();
		}

		public void TUpdate(Offer t)
		{
			_offerDal.Update(t);
		}
	}
}
