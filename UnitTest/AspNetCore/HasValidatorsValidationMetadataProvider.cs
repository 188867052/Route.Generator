// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

    internal class HasValidatorsValidationMetadataProvider : IValidationMetadataProvider
    {
        private readonly bool _hasOnlyMetadataBasedValidators;
        private readonly IMetadataBasedModelValidatorProvider[] _validatorProviders;

        public HasValidatorsValidationMetadataProvider(IList<IModelValidatorProvider> modelValidatorProviders)
        {
            if (modelValidatorProviders.Count > 0 && modelValidatorProviders.All(p => p is IMetadataBasedModelValidatorProvider))
            {
                this._hasOnlyMetadataBasedValidators = true;
                this._validatorProviders = modelValidatorProviders.Cast<IMetadataBasedModelValidatorProvider>().ToArray();
            }
        }

        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!this._hasOnlyMetadataBasedValidators)
            {
                return;
            }

            for (var i = 0; i < this._validatorProviders.Length; i++)
            {
                var provider = this._validatorProviders[i];
                if (provider.HasValidators(context.Key.ModelType, context.ValidationMetadata.ValidatorMetadata))
                {
                    context.ValidationMetadata.HasValidators = true;
                    return;
                }
            }

            if (context.ValidationMetadata.HasValidators == null)
            {
                context.ValidationMetadata.HasValidators = false;
            }
        }
    }
}
