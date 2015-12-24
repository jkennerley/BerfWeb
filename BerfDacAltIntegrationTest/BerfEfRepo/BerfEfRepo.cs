namespace Berf.EfRepo
{
    using Berf.Data;
    using Berf.DataEf;
    using global::BerfDacAltIntegrationTest.BerfDataEfContext;
    using System;

    public class BerfEfRepo
    {
        public static BerfEfDal GetDal()
        {
            var berfDbEntities = new BerfDbEntities();

            return new BerfEfDal(berfDbEntities);
        }

        public static MiRet InsertBerfClient(BerfClient model)
        {
            var dal = GetDal();

            var ret = dal.InsertBerfClient(model);

            if (ret != null)
            {
                dal.Save();
            }

            return ret;
        }

        public static MiRet UpdateBerfClient(BerfClient model)
        {
            var dal = GetDal();

            var ret = dal.UpdateBerfClient(model);

            if (ret != null)
            {
                dal.Save();
            }

            return ret;
        }

        public static MiRet DeleteBerfClient(BerfClient model)
        {
            var dal = GetDal();

            var ret = dal.DeleteBerfClient(model);

            if (ret != null)
            {
                dal.Save();
            }

            return ret;
        }

        public static BerfClient SelectBerfClient(Guid id)
        {
            var dal = GetDal();

            var ret = dal.SelectBerfClient(id);

            return ret;
        }
    }
}