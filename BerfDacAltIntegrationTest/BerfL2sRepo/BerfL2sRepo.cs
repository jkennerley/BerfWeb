namespace Berf.EfRepo
{
    using Berf.Data;
    using Berf.DataEf;

    public class BerfL2sRepo
    {
        public static BerfL2sDal GetRepo()
        {
            var dal = new BerfL2sDal();
            return dal;
        }

        public static MiRet InsertBerfClient(BerfDataContextDal.BerfClient be)
        {
            var ret = new MiRet();

            var dal = GetRepo();

            dal.InsertBerfClient(be);

            return ret;
        }

        public static MiRet UpdateBerfClient(BerfDataContextDal.BerfClient be)
        {
            var ret = new MiRet();

            var dal = GetRepo();

            dal.Update(be);

            return ret;
        }

        public static MiRet DeleteBerfClient(BerfDataContextDal.BerfClient be)
        {
            var ret = new MiRet();

            var repo = GetRepo();

            var beRet = repo.DeleteBerfClient(be);

            return ret;
        }

        public static BerfDataContextDal.BerfClient ReadBerfClient(BerfDataContextDal.BerfClient be)
        {
            var repo = GetRepo();

            var ret = repo.ReadBerfClient(be.Id);

            return ret;
        }
    }
}