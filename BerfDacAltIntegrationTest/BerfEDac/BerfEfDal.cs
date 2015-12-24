namespace Berf.Data
{
    using System;

    using Berf.DataEf;
    using BerfDacAltIntegrationTest.BerfDataEfContext;
    using System.Data.Entity;
    using System.Linq;

    public class BerfEfDal
    {
        public BerfDbEntities Ctx { get; set; }

        public BerfEfDal(BerfDbEntities ctx)
        {
            this.Ctx = ctx;

            // anything that is lazy loaded will attempt to create the object that is behind them
            // watch out for circular dependencies, Topic gets replies but may also get Topics that they belong to
            // must eager load
            this.Ctx.Configuration.LazyLoadingEnabled = false;

            // handle change management in straightforward way ;
            // proxy gen can cause problems with serialization, can get props that are not really part of your models
            this.Ctx.Configuration.ProxyCreationEnabled = false;
        }

        public MiRet InsertBerfClient(BerfClient be)
        {
            var miRet = new MiRet { };

            try
            {
                this.Ctx.BerfClients.Add(be);
                miRet.IsOK = true;
            }
            catch (System.Exception ex)
            {
                miRet.IsOK = false;
            }

            return miRet;
        }

        public MiRet UpdateBerfClient(BerfClient be)
        {
            // Declaration
            var miRet = new MiRet { };

            // Code
            this.Ctx.BerfClients.Attach(be);

            this.Ctx.Entry(be).State = EntityState.Modified;

            // Return
            return miRet;
        }

        public MiRet DeleteBerfClient(BerfClient be)
        {
            // Declaration
            var miRet = new MiRet { };

            // Code
            this.Ctx.BerfClients.Attach(be);

            this.Ctx.Entry(be).State = EntityState.Deleted;

            // Return
            return miRet;
        }

        // public IQueryable<BerfClient> SelectBerfClient(Guid id)
        public BerfClient SelectBerfClient(Guid id)
        {
            var xs = Ctx.BerfClients.Where(x => x.id == id);
            var b = xs.FirstOrDefault();
            return b ;
        }

        public MiRet Save()
        {
            var miRet = new MiRet { IsOK = false };

            try
            {
                miRet.IsOK = Ctx.SaveChanges() > 0;
            }
            catch (System.Exception ex)
            {
                var exMsg = ex.Message;
                miRet.IsOK = false;
            }

            return miRet;
        }
    }
}