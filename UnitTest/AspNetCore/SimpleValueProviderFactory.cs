namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    using System;
    using System.Threading.Tasks;

    public class SimpleValueProviderFactory : IValueProviderFactory
    {
        private readonly IValueProvider _valueProvider;

        public SimpleValueProviderFactory()
        {
            this._valueProvider = new SimpleValueProvider();
        }

        public SimpleValueProviderFactory(IValueProvider valueProvider)
        {
            if (valueProvider == null)
            {
                throw new ArgumentNullException(nameof(valueProvider));
            }

            this._valueProvider = valueProvider;
        }

        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            context.ValueProviders.Add(this._valueProvider);
            return Task.CompletedTask;
        }
    }
}
