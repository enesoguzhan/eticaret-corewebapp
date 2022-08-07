using Castle.DynamicProxy;

namespace AOP.Utilities.Interceptors
{
    //IInvocation => Tetiklenen metot hakkındaki tüm bilgileri içerisinde barındırıp kullanmamıza olanak sağlayan bir interface yapısıdır.
    public abstract class MethodInterception : MethodIncterceptorBaseAttribute
    {
        /// <summary>
        /// Belirtilen metot tetilendiğinde,Metot çalışmadan önce devreye giren yapımızdır.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnBefore(IInvocation invocation)
        {

        }
        /// <summary>
        /// Belirtilen metot tetilendiğinde,Metot çalışması bittikten sonra devreye giren yapımızdır.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnAfter(IInvocation invocation)
        {

        }
        /// <summary>
        /// Belirtilen metot çalışırken , Hata alındığında devreye giren yapımızdır.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnException(IInvocation invocation, Exception ex)
        {

        }
        /// <summary>
        /// Belirtilen metot çalışırken , Sorunsuz bir şekilde işlem tamamlandıysa devreye giren yapımızdır.
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnSuccess(IInvocation invocation)
        {

        }

        // Çok biçimlilik : Üst sınıftaki metotu alıp , alt sınıfta yapacağı işlemi değiştirerek kullanma olayı
        // Bu metot içerisinde hangi işlemlerde hangi metotların çalışacağını belirtiriz.
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation); // İlk çalışıcak metot
            try
            {
                invocation.Proceed(); // tetiklenen metot içerisinde ilerlemeye başla
                if (invocation.ReturnValue is Task returnValueTask)
                {
                    returnValueTask.GetAwaiter().GetResult();
                }
                OnSuccess(invocation);//İşlem sorunsuz şekilde devam ettiyse bu metot çalışıcak
            }
            catch (Exception ex)
            {
                OnException(invocation, ex);
            }
            finally
            {
                OnAfter(invocation);
            }
        }
    }
}
