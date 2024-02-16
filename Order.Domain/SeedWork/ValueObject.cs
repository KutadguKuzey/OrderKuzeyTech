using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }

        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }
    }
}




/*Bu C# kodu, değer nesneleri (value objects) için temel bir sınıf olan ValueObject'i tanımlar. Değer nesneleri, genellikle değer tabanlı ve değişmez (immutable) nesnelerdir ve genellikle birbirleriyle karşılaştırılabilir ve eşitlik kontrolü yapılabilir olmalıdırlar. Bu sınıf, bu tür işlemleri kolaylaştırmak için geliştirilmiştir.

Aşağıda, bu sınıfın ana özelliklerinin açıklamalarını bulabilirsin:

EqualOperator ve NotEqualOperator Metodları:
EqualOperator ve NotEqualOperator metodları, iki ValueObject'in eşitlik durumunu kontrol etmek için kullanılır.
ReferenceEquals fonksiyonu, referansların aynı olup olmadığını kontrol eder. XOR (^) operatörü, biri null ise ve diğeri null değilse true döndürür. Bu durumda, referanslar eşit değilse false döndürülür.
GetEqualityComponents Metodu:
Bu soyut metod, türetilen sınıflar tarafından uygulanmalıdır. Eşitlik kontrolü için gereken bileşenleri sağlamak amacıyla kullanılır.
Equals Metodu:
Equals metodunda, objenin null olup olmadığı ve türünün doğru olup olmadığı kontrol edilir. Daha sonra, GetEqualityComponents metodunun döndürdüğü bileşenlerin karşılaştırılması ile eşitlik kontrolü yapılır.
GetHashCode Metodu:
GetHashCode metodu, nesnenin karma bir hash değeri döndürmesini sağlar. Bu, nesnelerin koleksiyonlarda kullanılabilmesi için önemlidir. GetEqualityComponents metodunun döndürdüğü bileşenlerin hash değerleri kullanılarak bir XOR işlemi gerçekleştirilir.
GetCopy Metodu:
GetCopy metodu, MemberwiseClone metodunu kullanarak bir kopya oluşturur. Bu, değer nesnelerinin değişmez olması durumunda kullanışlı olabilir.
Bu sınıf, türetilen sınıflar tarafından implemente edilen GetEqualityComponents metodunu kullanarak eşitlik kontrolü ve hash hesaplama işlemlerini sağlayarak, değer nesneleri arasında genel bir eşitlik kontrolü gerçekleştirmeyi amaçlamaktadır.*/