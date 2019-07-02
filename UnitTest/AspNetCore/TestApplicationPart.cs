namespace Microsoft.AspNetCore.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc.ApplicationParts;

    public class TestApplicationPart : ApplicationPart, IApplicationPartTypeProvider
    {
        public TestApplicationPart()
        {
            this.Types = Enumerable.Empty<TypeInfo>();
        }

        public TestApplicationPart(params TypeInfo[] types)
        {
            this.Types = types;
        }

        public TestApplicationPart(IEnumerable<TypeInfo> types)
        {
            this.Types = types;
        }

        public TestApplicationPart(IEnumerable<Type> types)
            :this(types.Select(t => t.GetTypeInfo()))
        {
        }

        public TestApplicationPart(params Type[] types)
            : this(types.Select(t => t.GetTypeInfo()))
        {
        }

        public override string Name => "Test part";

        public IEnumerable<TypeInfo> Types { get; }
    }
}
