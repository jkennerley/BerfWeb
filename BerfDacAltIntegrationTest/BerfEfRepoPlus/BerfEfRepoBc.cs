namespace Berf.EfRepo
{
    using Berf.Data;
    using Berf.DataEf;

    using global::BerfDacAltIntegrationTest.BerfDataEfContext;

    public class BerfEfRepo
    {
        public static BerfEfDac GetRepo()
        {
            var berfDbEntities = new BerfDbEntities();

            var repo = new BerfEfDac(berfDbEntities);

            return repo;
        }

        public static MiRet InsertBerfClient(BerfClient model)
        {
            var repo = GetRepo();

            var ret = repo.InsertBerfClient(model);

            if (ret != null)
            {
                repo.Save();
            }

            return ret;
        }

        public static MiRet UpdateBerfClient(BerfClient model)
        {
            var repo = GetRepo();

            var ret = repo.UpdateBerfClient(model);

            if (ret != null)
            {
                repo.Save();
            }

            return ret;
        }

        public static MiRet DeleteBerfClient(BerfClient model)
        {
            var repo = GetRepo();

            var ret = repo.DeleteBerfClient(model);

            if (ret != null)
            {
                repo.Save();
            }

            return ret;
        }
    }
}