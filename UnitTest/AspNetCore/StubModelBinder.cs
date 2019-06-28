// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class StubModelBinder : IModelBinder
    {
        private readonly Func<ModelBindingContext, Task> _callback;

        public StubModelBinder()
        {
            this._callback = context => Task.CompletedTask;
        }

        public StubModelBinder(ModelBindingResult result)
        {
            this._callback = context =>
            {
                context.Result = result;
                return Task.CompletedTask;
            };
        }

        public StubModelBinder(Action<ModelBindingContext> callback)
        {
            this._callback = context =>
            {
                callback(context);
                return Task.CompletedTask;
            };
        }

        public StubModelBinder(Func<ModelBindingContext, ModelBindingResult> callback)
        {
            this._callback = context =>
            {
                var result = callback.Invoke(context);
                context.Result = result;
                return Task.CompletedTask;
            };
        }

        public StubModelBinder(Func<ModelBindingContext, Task<ModelBindingResult>> callback)
        {
            this._callback = async context =>
            {
                var result = await callback.Invoke(context);
                context.Result = result;
            };
        }

        public int BindModelCount { get; set; }

        public IModelBinder Object => this;

        public virtual async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            this.BindModelCount += 1;

            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            Debug.Assert(bindingContext.Result == ModelBindingResult.Failed());
            await this._callback.Invoke(bindingContext);
        }
    }
}
