namespace System.Reflection
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal static class MemberInfoExtensions
    {
        public static Type GetMemberType(this MemberInfo memberInfo)
            => (memberInfo as PropertyInfo)?.PropertyType ?? ((FieldInfo)memberInfo)?.FieldType;

        public static bool IsSameAs(this MemberInfo propertyInfo, MemberInfo otherPropertyInfo)
            => propertyInfo == null
                ? otherPropertyInfo == null
                : (otherPropertyInfo == null
                    ? false
                    : Equals(propertyInfo, otherPropertyInfo)
                      || (propertyInfo.Name == otherPropertyInfo.Name
                          && (propertyInfo.DeclaringType == otherPropertyInfo.DeclaringType
                              || propertyInfo.DeclaringType.GetTypeInfo().IsSubclassOf(otherPropertyInfo.DeclaringType)
                              || otherPropertyInfo.DeclaringType.GetTypeInfo().IsSubclassOf(propertyInfo.DeclaringType)
                              || propertyInfo.DeclaringType.GetTypeInfo().ImplementedInterfaces.Contains(otherPropertyInfo.DeclaringType)
                              || otherPropertyInfo.DeclaringType.GetTypeInfo().ImplementedInterfaces.Contains(propertyInfo.DeclaringType))));

        public static MemberInfo OnInterface(this MemberInfo targetMember, Type interfaceType)
        {
            var declaringType = targetMember.DeclaringType;
            if (declaringType == interfaceType
                || declaringType.IsInterface
                || !declaringType.GetInterfaces().Any(i => i == interfaceType))
            {
                return targetMember;
            }

            if (targetMember is MethodInfo targetMethod)
            {
                return targetMethod.OnInterface(interfaceType);
            }

            if (targetMember is PropertyInfo targetProperty)
            {
                var targetGetMethod = targetProperty.GetMethod;
                var interfaceGetMethod = targetGetMethod.OnInterface(interfaceType);
                if (interfaceGetMethod == targetGetMethod)
                {
                    return targetProperty;
                }

                return interfaceType.GetProperties().First(p => Equals(p.GetMethod, interfaceGetMethod));
            }

            Debug.Fail("Unexpected member type: " + targetMember.MemberType);

            return targetMember;
        }

        public static MethodInfo OnInterface(this MethodInfo targetMethod, Type interfaceType)
        {
            var declaringType = targetMethod.DeclaringType;
            if (declaringType == interfaceType
                || declaringType.IsInterface
                || declaringType.GetInterfaces().All(i => i != interfaceType))
            {
                return targetMethod;
            }

            var map = targetMethod.DeclaringType.GetInterfaceMap(interfaceType);
            var index = map.TargetMethods.IndexOf(targetMethod, MemberInfoComparer.Instance);

            return index != -1
                ? map.InterfaceMethods[index]
                : targetMethod;
        }

        public static string GetSimpleMemberName(this MemberInfo member)
        {
            var name = member.Name;
            var index = name.LastIndexOf('.');
            return index >= 0 ? name.Substring(index + 1) : name;
        }

        private class MemberInfoComparer : IEqualityComparer<MemberInfo>
        {
            public static readonly MemberInfoComparer Instance = new MemberInfoComparer();

            public bool Equals(MemberInfo x, MemberInfo y)
                => x.IsSameAs(y);

            public int GetHashCode(MemberInfo obj)
                => obj.GetHashCode();
        }

        private static int IndexOf<T>(this IEnumerable<T> source, T item, IEqualityComparer<T> comparer)
            => source.Select(
                    (x, index) =>
                        comparer.Equals(item, x) ? index : -1)
                .FirstOr(x => x != -1, -1);

        private static T FirstOr<T>(this IEnumerable<T> source, T alternate)
            => source.DefaultIfEmpty(alternate).First();

        private static T FirstOr<T>(this IEnumerable<T> source, Func<T, bool> predicate, T alternate)
            => source.Where(predicate).FirstOr(alternate);

    }
}
