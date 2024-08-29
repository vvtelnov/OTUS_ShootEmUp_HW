using System;

namespace GameSystem.DependencySystem.DI
{
    // Такое решение сделал, в целях оптимизации. Не знаю вообще есть ли в нем смысл.
    // Добавил, что бы когда Dependency Injector рефлексией пробегается по классам,
    // не приходилось пробегаться по всем методам MonoBehavior.
    // А так, он сразу смотрит, нужна инъекция данному классу или нет.
    // Поэтому, если У метода или поля есть аттрибут [Inject], а у класса нет аттрибута [InjectionNeeded],
    // То инъекция не пройдет.
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class InjectionNeeded : Attribute {}

    public enum DependencyResolvePrinciple
    {
        FROM_MONO_BEHAVIOR = 0,
        CREATE_NEW_INSTANCE = 1,
        FROM_CASHED_INSTANCE = 2,
        FROM_PREFAB = 3,
        FROM_GAME_OBJECT = 4,
        FROM_INACTIVE_GAME_OBJECT = 5,
        FROM_CONFIG = 6,
        DO_NOT_INJECT = 7
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
        public readonly DependencyResolvePrinciple ResolvePrinciple;
        public readonly string ObjectName; 
        
        // You need to specify objectName when you want to inject dependency from Prefab or GameObject ServiceLocator.
        public InjectAttribute(
            DependencyResolvePrinciple resolvePrinciple = DependencyResolvePrinciple.FROM_MONO_BEHAVIOR,
            string objectName = null
            )
        {
            ResolvePrinciple = resolvePrinciple;
            ObjectName = objectName;

            ValidateData();
        }

        public void ValidateData()
        {
            if (ObjectName is not null)
            {
                return;
            }

            switch (ResolvePrinciple)
            {
                case DependencyResolvePrinciple.FROM_PREFAB:
                    throw new ArgumentException(
                        "If ResolvePrinciple is implicitly set to 'FROM_PREFAB'" +
                        "then objectName must be provided" +
                        "In order for DI can make out what prefab you actually need."
                    );
                case DependencyResolvePrinciple.FROM_GAME_OBJECT:
                    throw new ArgumentException(
                        "If ResolvePrinciple is implicitly set to 'FROM_GAME_OBJECT'" +
                        "then objectName must be provided" +
                        "In order for DI can make out what gameObject you actually need."
                    );
                case DependencyResolvePrinciple.FROM_INACTIVE_GAME_OBJECT:
                    throw new ArgumentException(
                        "If ResolvePrinciple is implicitly set to 'FROM_INACTIVE_GAME_OBJECT'" +
                        "then objectName must be provided" +
                        "In order for DI can make out what gameObject you actually need."
                    );
                case DependencyResolvePrinciple.FROM_CONFIG:
                    throw new ArgumentException(
                        "If ResolvePrinciple is implicitly set to 'FROM_CONFIG'" +
                        "then objectName must be provided" +
                        "In order for DI can make out what gameObject you actually need."
                    );
                default:
                    return;
            }
        }
    }

}