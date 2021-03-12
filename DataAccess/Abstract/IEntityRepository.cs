using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint yani generic Kısıt, Buradaki T yi kısıtlamamız gerekiyor.
    //class: Referans tip olabilir demek. class olabilir değil.
    // Ama buraya herhangi bir class'ta yazabilir. Bu classları da sınırlandırmamız gerekiyor.
    // Biz Entities-Concrete'de ki Product, Category, Customer için Ientity'den bunun için implemente ediyoruz.
    // IEntity : Ientity olabilir veya IEntity implemende eden bir nesne olabilir.
    // new() : new'lenebilir olmalı. 
    // diğer taraflardan buraya IEntity'de gönderebiliyorduk fakat bunun da önüne geçebilmemiz lazım. new() yapıyoruz ki, bu IEntity zaten newlenemiyor. Bu sistem gerçekten veritabanı nesneleriyle çalışan
    // reposityoru oldu.
   public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);  //filtre vermeyedebilirsin demek filtre=null. Bunu bir kere yazarız daha da yazmayız. 
        T Get(Expression<Func<T, bool>> filter);               // ürünleri şuna göre listele, hani ürünleri listelediğimiz yapı bu yapıdır. 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        // List<T> GetAllByCategory(int categoryId); üsttekini yaptığımızda bu koda asla ihtiyacımız yok.
    }
}
