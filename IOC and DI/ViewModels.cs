namespace SOLID.DIP
{
    public class SimpleIOC
    {
        private readonly Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public void Register<TFrom, TTo>()
        {
            _map.Add(typeof(TFrom), typeof(TTo));
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            Type resolvedType = null;

            try
            {
                resolvedType = _map[type];
            }
            catch
            {
                throw new ArgumentException($"Coud not rsolve type {type}");
            }

            var ctor = resolvedType.GetConstructors().First();
            var ctorParamaters = ctor.GetParameters();
            if (ctorParamaters.Length == 0)
            {
                return Activator.CreateInstance(resolvedType);
            }

            var paramaters = new List<object>();

            foreach (var paramaterResolve in ctorParamaters)
            {
                paramaters.Add(Resolve(paramaterResolve.ParameterType));
            }
            return ctor.Invoke(paramaters.ToArray());
        }
    }



}