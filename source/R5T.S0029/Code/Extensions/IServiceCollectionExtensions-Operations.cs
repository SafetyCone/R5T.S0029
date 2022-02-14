using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0088.I0002;
using R5T.T0063;

using R5T.S0029.Library;


namespace R5T.S0029
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="O999_Scratch"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddO999_Scratch(this IServiceCollection services,
            IServiceAction<ICompilationUnitContextProvider> compilationUnitContextProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .Run(compilationUnitContextProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                .AddSingleton<O999_Scratch>();

            return services;
        }
    }
}