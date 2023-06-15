using Core.IEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposab1e pattern implementation of c#
            //using içine yazılan nesneler using bitinci anında garbage collector gelir
            using (TContext context = new TContext())
            {
                //git benim gönderdiğim product'dan bir tane nesneyi eşitle
                var addedEntity = context.Entry(entity);//1-referansı yakala
                addedEntity.State = EntityState.Added;//2-o aslında eklenecek bir nesne
                context.SaveChanges();//3-ve ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        //bize tek data getirecek
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null//filtre null mı
                    ? context.Set<TEntity>().ToList() //eğer null ise hepsini getir
                    : context.Set<TEntity>().Where(filter).ToList();//değilse ben sana filtre vericem onu listele
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
